using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using ModernSchoolManagement.Authentication;
using Dapper;
using ModernSchoolManagement.Dam.Repositories;
using ModernSchoolManagement.Dam.Services;
using ModernSchoolManagement.Dam.Models;

namespace ModernSchoolManagement
{
    public class Startup
    {
        private readonly string? _connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("SqlConnection");
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Use AddMemoryCache for in-memory caching
            services.AddMemoryCache();
            // Configure JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,

                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]!)),
                        ValidateLifetime = true,
                    };
                    options.Events=new JwtBearerEvents{
                        OnAuthenticationFailed = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Startup>>();
                            logger.LogError("Authentication failed: {0}", context.Exception.Message);
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    //    ,
                    //    OnTokenValidated = context =>
                    //    {
                    //        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Startup>>();
                    //        logger.LogInformation("Token validated for {0}", context.Principal?.Identity?.Name);
                    //        return System.Threading.Tasks.Task.CompletedTask;
                    //    }
                    };
                });

            //Add Services
            services.AddScoped<IAuthentication, Authentication.Authentication>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IDynamicRepository, DynamicRepository>();
            services.AddScoped<IUserModel, UserService>();
            services.AddScoped<ISchoolModel, SchoolService>();
            services.AddScoped<IClassModel, ClassService>();
            services.AddScoped<ISubjectModel, SubjectService>();
            services.AddScoped<IAcademicYearModel, AcademicYearService>();
            services.AddScoped<INotificationModel, NotificationService>();
            services.AddScoped<ISubjectModel, SubjectService>();
            services.AddScoped<ICourseModel, CourseService>();

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

            // Add CORS with a default policy for best performance
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModernSchoolManagement v1"));
            }
           //else
           //  {
           //     app.UseExceptionHandler("/Error");
           //     app.UseHsts();
           // }

            app.UseHttpsRedirection();

            // Use CORS
            app.UseCors(x=> x.AllowAnyOrigin());
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
        }
    }
}
