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

    private readonly UserManager<Usuario> _userManager;

    public IndexModel(UserManager<Usuario> userManager) {
      this._userManager = userManager;
    }

    public async Task OnGetAsync() {
      //var a = await this._userManager.GetUserAsync(this.User);
      //if (a != null) {
      //  Debug.WriteLine(a.Nombre);
      //}
    }
  }
}
