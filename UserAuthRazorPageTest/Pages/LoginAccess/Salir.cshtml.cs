using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAuthRazorPageTest.Domain;

namespace UserAuthRazorPageTest.Pages.LoginAccess {
  public class SalirModel:PageModel {

    private readonly SignInManager<Usuario> signManager;

    public SalirModel(SignInManager<Usuario> _signManager) {
      this.signManager = _signManager;
    }

    public void OnGet() {

    }

    public async Task<ActionResult> OnPost() {
      await this.signManager.SignOutAsync();
      //_logger.LogInformation("User logged out.");
      //TODO: Log informativo
      return RedirectToAction("Index","Home");
    }
  }
}