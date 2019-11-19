using System;
using System.Collections.Generic;
using System.Text;
using Entity_Framework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RolesyUsuarios.Models;

namespace RolesyUsuarios.Data
{
    public class ApplicationDbContext : IdentityDbContext <AppUser, IdentityRole, string>
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Obra> Obras { get; set; }

        //public DbSet<Autobiografia> Autobiografias { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ObraCategoria> ObraCategorias { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
