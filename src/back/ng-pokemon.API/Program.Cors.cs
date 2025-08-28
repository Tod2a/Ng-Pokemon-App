namespace ng_pokemon.API;

public static partial class Program
{
    /// <summary>
    /// Configures and adds a CORS policy to the application services.
    /// This policy allows requests from a specific origin and allows any HTTP method and header.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder used to configure the application services.</param>
    public static void AddCorsPolicy(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            string corsPolicy = "corsPolicy";
            string allowedOrigin = builder.Configuration["CorsSettings:AllowedOrigin"] ?? "https://default-origin.com";
            options.AddPolicy(name: corsPolicy, policyBuilder =>
            {
                policyBuilder.WithOrigins(allowedOrigin)
                             .AllowAnyHeader()
                             .AllowAnyMethod();
            });
        });
    }
}
