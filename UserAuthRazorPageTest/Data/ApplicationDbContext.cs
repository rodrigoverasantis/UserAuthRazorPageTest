using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserAuthRazorPageTest.Domain;

namespace UserAuthRazorPageTest.Data {
  public class ApplicationDbContext:IdentityDbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }

    public DbSet<Usuario> Usuarios { get; set; }
  }
}
