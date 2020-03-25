using ImportacaoUsuarios.Models;
using ImportacaoUsuarios.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Repositories.Implementations
{
    public static class EntityExtensions
    {
        public static void Clear<UsuariosIntermediario>(this DbSet<UsuariosIntermediario> UsuarioIntermediario) where UsuariosIntermediario : class
        {
            UsuarioIntermediario.RemoveRange(UsuarioIntermediario);
        }
    }
    public class UsuarioIntermediarioRepositoryImp : IUsuarioIntermediarioRepository
    {

        private readonly UsuarioContext _context;

        public UsuarioIntermediarioRepositoryImp(UsuarioContext context)
        {
            _context = context;
        }
        public void DeleteAll()
        {
            try
            {
                _context.UsuariosIntermediario.Clear();
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UsuariosIntermediario> FindAll()
        {
            return _context.UsuariosIntermediario.ToList();
        }

        public UsuariosIntermediario Insert(UsuariosIntermediario usuariosIntermediario)
        {
            try
            {
                _context.Add(usuariosIntermediario);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usuariosIntermediario;
        }
    }
}
