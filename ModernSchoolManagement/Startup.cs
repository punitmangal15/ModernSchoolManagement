using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using ModernSchoolManagement.Authentication;
using Dapper;
using ModernSchoolManagement.Dam.Repositories;
using ModernSchoolManagement.Dam.Services;

namespace ModernSchoolManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string? _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("SqlConnection");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Use AddMemoryCache for in-memory caching
            services.AddMemoryCache();

            // Validate JWT configuration
            var jwtSection = Configuration.GetSection("Jwt");
            ArgumentNullException.ThrowIfNull(jwtSection["Issuer"]);
            ArgumentNullException.ThrowIfNull(jwtSection["Audience"]);
            ArgumentNullException.ThrowIfNull(jwtSection["Key"]);

            // Configure JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSection["Issuer"],
                        ValidAudience = jwtSection["Audience"],
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(jwtSection["Key"]!)),
                        ValidateLifetime = true,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.Write("lne 50 ofstartup");
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Startup>>();
                            logger.LogError("Authentication failed: {0}", context.Exception.Message);
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };
                });

            // Add Services
            services.AddScoped<IAuthentication, Authentication.Authentication>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IDynamicRepository, DynamicRepository>();
            services.AddScoped<IUserModel, UserService>();

            //services.AddScoped<IUserInterface, UserService>();


            // Use AddControllers with minimal JSON config for performance
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                });

            // Add logging
            services.AddLogging();

            // Add CORS with a named policy for security
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    //builder.WithOrigins("http://localhost:5216/") // Replace with your allowed origins
                    //       .AllowAnyHeader()
                    //       .AllowAnyMethod();
                });
            });

            // Add Swagger for API documentation
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter JWT with Bearer prefix",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("Application starting up...");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModernSchoolManagement v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Use named CORS policy
            app.UseCors("DefaultPolicy");
            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            // Use custom authentication middleware if needed
            app.UseMiddleware<Middleware.AuthenticationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            logger.LogInformation("Application started.");
        }
    }
}
