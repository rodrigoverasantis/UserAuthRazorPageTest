using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAuthRazorPageTest.Domain;

namespace UserAuthRazorPageTest.Pages {
  public class IndexModel:PageModel {

    private readonly SignInManager<Usuario> signManager;

    public IndexModel(SignInManager<Usuario> _signManager) {
      this.signManager = _signManager;
    }

    public async Task OnGetAsync() {
      //var a = await this._userManager.GetUserAsync(this.User);
      //if (a != null) {
      //  Debug.WriteLine(a.Nombre);
      //}
    }

    public async Task<ActionResult> OnPost() {
      if (this.User != null) {
        await this.signManager.SignOutAsync();
        //_logger.LogInformation("User logged out.");
        //TODO: Log informativo
        return Redirect("/Index");
      }
      return Redirect("/Index");
    }
  }
}
