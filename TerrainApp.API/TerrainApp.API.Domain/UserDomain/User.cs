using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TerrainApp.API.Domain.UserDomain
{
    public class User
    {
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

  
        public string Email { get; set; } = string.Empty;

   
        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public EnumUser Role { get; set; } = EnumUser.Regular;
        public EnumLang Language { get; set; } = EnumLang.English;
        public EnumTheme Theme { get; set; } = EnumTheme.light;
        public bool IsActive { get; set; } = true;

        public DateTime LastLoginAt { get; set; }
        public DateTime ExpireDate { get; set; }

        public List<int> OwnedTerrains { get; set; } = new List<int>();
        public List<int> FavoriteTerrains { get; set; } = new List<int>();
        public bool ReceiveNotifications { get; set; } = true;
        public List<string> PurchaseHistory { get; set; } = new List<string>();

       
        public Location UserLocation { get; set; } = new Location("", "", "", 0, 0);

        
        public int FailedLoginAttempts { get; set; } = 0;
        public DateTime? AccountLockoutTime { get; set; }


        public User()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
        public void UpdateProfile(string firstName, string lastName, string email, string phoneNumber)
        {
            ValidateEmail(email);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

      
        public void ChangePassword(string currentPassword, string newPassword)
        {
            if (!VerifyPassword(currentPassword))
                throw new InvalidOperationException("Current password is incorrect.");

            if (!IsPasswordStrong(newPassword))
                throw new InvalidOperationException("New password is not strong enough.");

            Password = HashPassword(newPassword);
        }

      
        public void DeactivateAccount()
        {
            IsActive = false;
            ExpireDate = DateTime.UtcNow.AddMonths(6); 
        }

   
        public void ReactivateAccount()
        {
            if (IsActive)
                throw new InvalidOperationException("Account is already active.");

            IsActive = true;
            ExpireDate = DateTime.MaxValue; 
        }

       
        public void AddToFavorites(int terrainId)
        {
            if (FavoriteTerrains.Contains(terrainId))
                throw new InvalidOperationException("Terrain already in favorites.");

            FavoriteTerrains.Add(terrainId);
        }

     
        public void Logout()
        {
            LastLoginAt = DateTime.UtcNow;
        }

       
        public bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => "!@#$%^&*()".Contains(ch));
        }

       
        private string HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16]; 
                rng.GetBytes(salt); 

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000)) 
                {
                    byte[] hash = pbkdf2.GetBytes(20); 
                    return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
                }
            }
        }

        private bool VerifyPassword(string password)
        {
            var parts = Password.Split(':');
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = Convert.FromBase64String(parts[1]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                return storedHash.SequenceEqual(hash);
            }
        }

    
        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
                throw new InvalidOperationException("Invalid email format.");
        }


        public void UpdateLocation(string country, string city, string address, double latitude, double longitude)
        {
            UserLocation = new Location(country, city, address, latitude, longitude);
        }


        public void IncrementFailedLoginAttempts()
        {
            FailedLoginAttempts++;
            if (FailedLoginAttempts >= 5)
            {
                AccountLockoutTime = DateTime.UtcNow.AddMinutes(15);
            }
        }

        public bool IsAccountLocked()
        {
            if (AccountLockoutTime.HasValue && DateTime.UtcNow < AccountLockoutTime.Value)
            {
                return true;
            }
            return false;
        }

        public void SaveUser()
        {
            Console.WriteLine($"User {Email} saved to the database.");
        }
    }
}