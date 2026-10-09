using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNET10.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            
            if (environment.IsDevelopment())
            {
                var connectionString = configuration[
                    "MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];


                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                }
                try
                {
                    using var evolveConnection = new SqlConnection(connectionString);
                    var evolve = new Evolve(evolveConnection,
                        msg => Log.Information(msg))
                    {
                        Locations = new[] { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true,
                        CommandTimeout = 60
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    Log.Fatal("Database migration failed.", ex);
                    throw;
                }
            }
            
            return services;
        }
    }
}
