using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAuthRazorPageTest.Domain;

namespace UserAuthRazorPageTest.Pages.LoginAccess {
  public class RegistrarModel:PageModel {

    private readonly UserManager<Usuario> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    [BindProperty]
    public Usuario Usuario { get; set; }

    [BindProperty]
    public string Clave { get; set; }

    public RegistrarModel(UserManager<Usuario> _userManager,RoleManager<IdentityRole> _roleManager) {
      this.userManager = _userManager;
      this.roleManager = _roleManager;
    }

    public void OnGet() {

    }

    public async Task<ActionResult> OnPostAsync() {

      var usuarioCheck = await this.userManager.FindByNameAsync(this.Usuario.UserName);
      if (usuarioCheck == null) {
        var nuevoUsuario = await this.userManager.CreateAsync(this.Usuario,this.Clave);
        if (nuevoUsuario.Succeeded) {
          var rol = await this.roleManager.FindByNameAsync("Basico");
          await this.userManager.AddToRoleAsync(this.Usuario,rol.Name);
        }
      }
      return RedirectToAction("Index","Home");
    }
  }
}