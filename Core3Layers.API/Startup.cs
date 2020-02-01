using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Core3Layers.API.Helpers;
using Core3LayersAPI.Core.Interfaces;
using Core3LayersAPI.Infrastructure;
using Core3LayersAPI.Infrastructure.Services;
using AutoMapper;
using Core3LayersAPI.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Core3Layers.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc()
             .AddJsonOptions(options => {
                 options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
             });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddMemoryCache();
            services.AddResponseCaching();

            //services.AddTransient<IContratosAprovacoesPendentesRepository, ContratosAprovacoesPendentesRepository>();

            var memo = services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            var getOptions = services.BuildServiceProvider()
                      .GetRequiredService<DbContextOptions<ApplicationDbContext>>();

            //Task.Run(() =>
            //{
            //    using (var dbContext = new ApplicationDbContext(getOptions))
            //    {
            //        var model = dbContext.Model; //force the model creation
            //    }
            //});

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultUI()
            //    .AddDefaultTokenProviders();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WebApplication1", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
            });

            });

            services.AddAuthorization(options =>
            {

                options.AddPolicy(StaticRoles.Customer,
                    authBuilder =>
                    {
                        authBuilder.RequireRole(StaticRoles.Customer).Build();
                    });

            });
            services.AddAuthorization(options =>
            {

                options.AddPolicy(StaticRoles.Business,
                    authBuilder =>
                    {
                        authBuilder.RequireAuthenticatedUser().RequireAssertion(context => context.User.HasClaim(ClaimTypes.Role, StaticRoles.Business)).Build();
                    });

            });
            services.AddAuthorization(options =>
            {

                options.AddPolicy(StaticRoles.Admin,
                    authBuilder =>
                    {
                        authBuilder.RequireRole(StaticRoles.Admin).Build();
                    });

            });

            services.AddResponseCompression();

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true; options.Providers.Add<BrotliCompressionProvider>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Enable compression
            //app.UseResponseCompression();
            app.UseAuthentication();
            app.UseResponseCaching();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
                c.OAuthClientId("demo_api_swagger");
                c.OAuthAppName("Demo API - Swagger");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area=Users}/{controller=Users}/{action=Authenticate}/{id?}"
                );
            });
        }
    }
}
