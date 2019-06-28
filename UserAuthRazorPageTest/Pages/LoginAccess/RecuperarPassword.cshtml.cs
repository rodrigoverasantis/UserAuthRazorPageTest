using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserAuthRazorPageTest.Pages.LoginAccess {
  public class RecuperarPasswordModel:PageModel {

    [BindProperty]
    public string Correo { get; set; }

    public void OnGet() {

    }

    public void OnPost() {

    }
  }
}