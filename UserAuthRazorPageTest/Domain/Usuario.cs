using Microsoft.AspNetCore.Identity;
using System;

namespace UserAuthRazorPageTest.Domain {
  public class Usuario:IdentityUser {

    public string Nombre { get; set; }
    public string SegundoNombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }

    public string Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
  }
}
