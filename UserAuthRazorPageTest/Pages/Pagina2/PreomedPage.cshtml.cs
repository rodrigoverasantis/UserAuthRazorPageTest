﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserAuthRazorPageTest.Pages.Pagina2 {

  [Authorize(Roles = "Usuario Externo")]
  public class PreomedPageModel:PageModel {

    public void OnGet() {

    }
  }
}