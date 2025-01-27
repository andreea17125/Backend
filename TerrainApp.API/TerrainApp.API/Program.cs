using System.Reflection;
using FluentValidation.AspNetCore;
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
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IDataBase>(E =>
        {
            return new DataBase();
        });
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:5173")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
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