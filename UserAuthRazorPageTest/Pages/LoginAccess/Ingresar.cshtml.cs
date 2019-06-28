using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAuthRazorPageTest.Domain;

namespace UserAuthRazorPageTest.Pages.LoginAccess {
  public class IngresarModel:PageModel {

    private readonly SignInManager<Usuario> signManager;
    private readonly UserManager<Usuario> userManager;

    [BindProperty]
    public string Usuario { get; set; }

    [BindProperty]
    public string Clave { get; set; }

    [BindProperty]
    public bool Recordarme { get; set; }

    public IngresarModel(SignInManager<Usuario> _signInManager,UserManager<Usuario> _userManager) {
      this.signManager = _signInManager;
      this.userManager = _userManager;
    }

    public void OnGet() {

    }

    public async Task<ActionResult> OnPostAsync() {
      var usuarioCheck = await this.userManager.FindByNameAsync(this.Usuario);
      if (usuarioCheck != null) {
        var result = await this.signManager.PasswordSignInAsync(usuarioCheck,this.Clave,this.Recordarme,lockoutOnFailure: true);
        if (result.Succeeded) {
          //_logger.LogInformation("User logged in.");
          //TODO: log informativo
          return Redirect("/Index");
        }
      }
      return Redirect("/Index");
    }
  }
}