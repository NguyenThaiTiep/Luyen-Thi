using Luyenthi.Domain.User;
using Luyenthi.EntityFrameworkCore;
using Luyenthi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Luyenthi.HttpApi.Host;
using Luyenthi.HttpApi.Host.Middleware;
using Hangfire;
using Hangfire.MySql;

namespace Luyenthi
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<AuthSettings>(Configuration.GetSection("AuthSettings"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddHttpContextAccessor();
            services.AddDbContext<LuyenthiDbContext>(options =>
            {
                options.UseMySql(
                    Configuration.GetConnectionString("Default"),
                    ServerVersion.AutoDetect(Configuration.GetConnectionString("Default")),
                    b => b.MigrationsAssembly("Luyenthi.DbMigrator")

                );
                options.EnableSensitiveDataLogging();
            }
            );
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "127.0.0.1";
                option.InstanceName = "master";
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddOptions();
            // repository
            services.AddTransient<GradeRepository>();
            services.AddTransient<QuestionRepository>();
            services.AddTransient<QuestionHistoryRepository>();
            services.AddTransient<SubjectRepository>();
            services.AddTransient<DocumentRepository>();
            services.AddTransient<DocumentHistoryRepository>();
            services.AddTransient<QuestionSetRepository>();
            services.AddTransient<ChapterRepository>();
            services.AddTransient<UnitRepository>();
            services.AddTransient<LevelQuestionRepository>();
            services.AddTransient<TemplateQuestionRepository>();
            services.AddTransient<UserRepository>();
            services.AddTransient<TemplateDocumentRepository>();
            services.AddTransient<TemplateQuestionSetRepository>();
            services.AddTransient<TemplateQuestionGenerateRepository>();
            
            // add transient service
            services.AddTransient<DocumentService>();
            services.AddTransient<QuestionService>();
            services.AddTransient<FileService>();
            services.AddTransient<CloudinarySerivce>();
            services.AddTransient<QuestionSetService>();
            services.AddTransient<ChapterService>();
            services.AddTransient<UnitService>();
            services.AddTransient<JwtService>();
            services.AddTransient<TemplateQuestionService>();
            services.AddTransient<IMailService, Services.MailService>();
            services.AddTransient<HashingService>();
            services.AddTransient<MutationService>();
            services.AddTransient<GradeService>();
            services.AddTransient<SubjectService>(); 
            services.AddTransient<DocumentHistoryService>();
            services.AddTransient<QuestionHistoryService>();
            services.AddTransient<UserService>();
            services.AddTransient<GenerateService>();
            services.AddTransient<QuestionSetGenerateService>();
            services.AddTransient<LevelQuestionService>();

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                {
                    options.User.RequireUniqueEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                }
            )
                .AddEntityFrameworkStores<LuyenthiDbContext>()
                .AddDefaultTokenProviders();
            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));
            services.AddHangfire(configuration =>
            {
                configuration.UseStorage(
                    new MySqlStorage(
                        Configuration.GetConnectionString("Hangfire"),
                        new MySqlStorageOptions
                        {
                            TablesPrefix = "Hangfire"
                        }
                    )
                ).UseSerializerSettings(
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                );
            });

            services.AddHangfireServer(
                options => options.WorkerCount = Environment.ProcessorCount * 2
            );
            services.AddCors();
            services.AddControllers()

            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thi Thu API V1");
            });

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMiddleware<HandleErrorMiddleware>();
            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
        }
    }
}
