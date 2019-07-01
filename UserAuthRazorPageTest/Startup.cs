using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAuthRazorPageTest.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAuthRazorPageTest.Domain;

namespace UserAuthRazorPageTest {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.Configure<CookiePolicyOptions>(options => {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite("Data Source=userAuth.db"));
      services.AddIdentity<Usuario,IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
      services.AddScoped<RoleManager<IdentityRole>>();

      //Password Strength Setting 
      services.Configure<IdentityOptions>(options => {
        // Password settings 
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredUniqueChars = 1;

        // Lockout settings 
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 10;
        options.Lockout.AllowedForNewUsers = true;

        // User settings 
        options.User.RequireUniqueEmail = true;
      });

      //Redirecciona en caso de entrar a una página sin tener autorización
      services.ConfigureApplicationCookie(options => {
        options.LoginPath = "/LoginAccess/Ingresar";
        options.AccessDeniedPath = "/LoginAccess/AccesoDenegado";
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,IHostingEnvironment env,IServiceProvider services) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      } else {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseAuthentication();

      app.UseMvc();

      this.CreateUserRoles(services).Wait();
    }

    private async Task CreateUserRoles(IServiceProvider serviceProvider) {
      var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

      var roles = new string[] {
        "Administrador",
        "Usuario Externo",
        "Usuario Preomed",
        "Basico"
      };

      foreach (var item in roles) {
        var rolCheck = await RoleManager.RoleExistsAsync(item);
        if (rolCheck == false) {
          var newRol = new IdentityRole(item);
          await RoleManager.CreateAsync(newRol);
        }
      }

      var UserManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();

      var usuarios = new Usuario[] {
        new Usuario {
          UserName = "usuario1",
          Email = "usuario1@usuarios.com",

          Nombre = "Nombre1",
          SegundoNombre = "SegundoNombre1",
          ApellidoPaterno = "ApellidoPaterno1",
          ApellidoMaterno = "ApellidoMaterno1",
          FechaNacimiento = DateTime.UtcNow,
          Genero = "Masculino",
        },
        new Usuario {
          UserName = "usuario2",
          Email = "usuario2@usuarios.com",

          Nombre = "Nombre2",
          SegundoNombre = "SegundoNombre2",
          ApellidoPaterno = "ApellidoPaterno2",
          ApellidoMaterno = "ApellidoMaterno2",
          FechaNacimiento = DateTime.UtcNow,
          Genero = "Masculino",
        },
        new Usuario {
          UserName = "usuario3",
          Email = "usuario3@usuarios.com",

          Nombre = "Nombre3",
          SegundoNombre = "SegundoNombre3",
          ApellidoPaterno = "ApellidoPaterno3",
          ApellidoMaterno = "ApellidoMaterno3",
          FechaNacimiento = DateTime.UtcNow,
          Genero = "Masculino",
        },
      };

      foreach (var item in usuarios) {
        var usuarioCheck = await UserManager.FindByNameAsync(item.UserName);
        if (usuarioCheck == null) {
          await UserManager.CreateAsync(item,"password");
        }
      }

      //Assign Admin role to the main User here we have given our newly registered  
      //login id for Admin management 
      var usuario1 = await UserManager.FindByEmailAsync("usuario1@usuarios.com");
      var usuario2 = await UserManager.FindByEmailAsync("usuario2@usuarios.com");
      var usuario3 = await UserManager.FindByEmailAsync("usuario3@usuarios.com");

      var rol1 = await RoleManager.FindByNameAsync("Administrador");
      var rol2 = await RoleManager.FindByNameAsync("Usuario Externo");
      var rol3 = await RoleManager.FindByNameAsync("Usuario Preomed");

      await UserManager.AddToRoleAsync(usuario1,rol1.Name);
      await UserManager.AddToRoleAsync(usuario2,rol2.Name);
      await UserManager.AddToRoleAsync(usuario3,rol3.Name);
    }
  }
}
