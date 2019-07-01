using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserAuthRazorPageTest.Pages.Pagina3 {

  [Authorize(Roles = "Usuario Preomed")]
  public class EmpresaPageModel:PageModel {

    public void OnGet() {

    }
  }
}