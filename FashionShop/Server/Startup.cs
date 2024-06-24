using FashionShop.Adapter;
using FashionShop.Adapter.Repository;
using FashionShop.Adapter.Transaction;
using FashionShop.App.Data;
using FashionShop.App.Interactors;
using FashionShop.App.Storage;
using FashionShop.Server.Data;
using FashionShop.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace FashionShop.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidIssuer = AuthOptions.ISSUER,

                           ValidateAudience = true,
                           ValidAudience = AuthOptions.AUDIENCE,
                           ValidateLifetime = true,

                           IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                           ValidateIssuerSigningKey = true,
                       };
                   });
            services.AddTransient<IUnitWork, UnitWork>();

			services.AddTransient<BasketInteractor>();
			services.AddTransient<IBasketRepository, BasketRepository>();

			services.AddTransient<OrderInteractor>();
			services.AddTransient<IOrderRepository, OrderRepository>();

			services.AddTransient<ProductInteractor>();
			services.AddTransient<IProductRepository, ProductRepository>();

			services.AddTransient<ReviewInteractor>();
			services.AddTransient<IReviewRepository, ReviewRepository>();

			services.AddTransient<RoleInteractor>();
			services.AddTransient<IRoleRepository, RoleRepository>();

			services.AddTransient<SizeInteractor>();
			services.AddTransient<ISizeRepository, SizeRepository>();

			services.AddTransient<UserInteractor>();
			services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<TagInteractor>();
            services.AddTransient<ITagRepository, TagRepository>();

            services.AddTransient<EmailVerifInteractor>();
            services.AddTransient<IEmailVerifRepository, EmailVerifRepository>();

            services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "FashionShop", Version = "v1" });
			});

			services.AddDbContext<ShopContext>(options => options.UseSqlite(Configuration.GetConnectionString("MyConnection")));

			//services.AddDbContext<ApplicationDbContext>(options =>
			//	options.UseSqlServer(
			//		Configuration.GetConnectionString("DefaultConnection")));

			services.AddDatabaseDeveloperPageExceptionFilter();

			//services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
			//	.AddEntityFrameworkStores<ApplicationDbContext>();

			//services.AddIdentityServer()
			//	.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

			//services.AddAuthentication()
			//	.AddIdentityServerJwt();

			services.AddControllersWithViews();
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
				app.UseWebAssemblyDebugging();

				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FAshionShop v1"));
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseIdentityServer();
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
