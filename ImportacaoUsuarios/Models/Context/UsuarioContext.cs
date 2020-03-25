using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Models.Context
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosIntermediario> UsuariosIntermediario { get; set; }
        public UsuarioContext()
        { }

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        { }
    }
}
