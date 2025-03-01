using System.Net;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Database.DataBase;
using TerrainApp.API.Repositories;

internal class Program
{
   
    private static Assembly[] Assemblies;
    private static Assembly[] RegisterServices(IServiceCollection services)
    {
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => assembly.GetName().Name.Contains("TerrainApp.API") ||
                               assembly.GetName().Name.Contains("CommonDomain"))
            .ToList();

        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var allAssemblyFiles = Directory.GetFiles(assemblyPath, "*.dll");

        foreach (var assemblyFile in allAssemblyFiles)
        {
            var assemblyName = Path.GetFileNameWithoutExtension(assemblyFile);

            if (!loadedAssemblies.Any(a => a.GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase)))
            {
                if (assemblyName.Contains("TerrainApp.API") || assemblyName.Contains("CommonDomain"))
                {
                    try
                    {
                        var assembly = Assembly.LoadFrom(assemblyFile);
                        loadedAssemblies.Add(assembly);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not load assembly {assemblyFile}: {ex.Message}");
                    }
                }
            }
        }

        return loadedAssemblies.ToArray();
    }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Assemblies = RegisterServices(builder.Services);
        builder.Services.AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblies(Assemblies);
        });
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assemblies));
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: {Authorization: Bearer { token }",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
        });
        builder.Services.AddSingleton<IDataBase>(E =>
        {
            return new DataBase();
        });
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                policy => policy.WithOrigins("http://localhost:5176")
                                .AllowAnyMethod()
                                .AllowAnyHeader());
        });


        var app = builder.Build();
        app.UseCors("AllowSpecificOrigin");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}