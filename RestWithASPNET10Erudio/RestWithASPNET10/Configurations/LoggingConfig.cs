using Serilog; 


namespace RestWithASPNET10.Configurations
{
    public static class LoggingConfig
    {
        public static void AddSerilog(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();
            builder.Host.UseSerilog();
        }
    }
}
