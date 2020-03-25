using ImportacaoUsuarios.DTO;
using ImportacaoUsuarios.Models;
using ImportacaoUsuarios.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Services.Implementations
{
    public class UsuarioServiceImp : IUsuarioService
    {

        private readonly IUsuarioRepository _repository;

        private readonly IUsuarioIntermediarioService _intermediarioService;

        public UsuarioServiceImp(IUsuarioRepository repository, IUsuarioIntermediarioService intermediarioService)
        {
            _repository = repository;
            _intermediarioService = intermediarioService;
        }
        public UsuariosDTO Insert()
        {
            try
            {
                List<UsuariosIntermediario> listaUsuariosIntermediario = _intermediarioService.FindAll();
                int Inserido = 0;
                int Alterado = 0;
                int Ignorado = 0;
                int Falha = 0;

                foreach (UsuariosIntermediario usuariosIntermediario in listaUsuariosIntermediario)
                {
                    /*Usuarios usuarios = new Usuarios(usuariosIntermediario.UserId, usuariosIntermediario.Nome,
                        usuariosIntermediario.Email, usuariosIntermediario.DataNascimento, usuariosIntermediario.Sexo);*/
                    Usuarios usuarios = new Usuarios()
                    {
                        Id = usuariosIntermediario.UserId,
                        Nome = usuariosIntermediario.Nome,
                        Email = usuariosIntermediario.Email,
                        DataNascimento = usuariosIntermediario.DataNascimento,
                        Sexo = usuariosIntermediario.Sexo
                    };
                    var opUser = _repository.FindById(usuarios.Id);
                    if (opUser != null)
                    {
                        if (opUser.Equals(usuarios))
                        {
                            Ignorado++;
                        }
                        else
                        {
                            Usuarios email = _repository.FindByEmail(usuarios.Email);
                            if (email != null && email.Id != usuarios.Id)
                            {
                                Falha++;
                            }
                            else
                            {
                                _repository.Update(usuarios);
                                Alterado++;
                            }
                        }
                    }
                    else
                    {
                        Usuarios email = _repository.FindByEmail(usuarios.Email);
                        if (email != null)
                        {
                            Falha++;
                        }
                        else
                        {
                            _repository.Insert(usuarios);
                            Inserido++;
                        }
                    }
                }
                UsuariosDTO userDto = new UsuariosDTO()
                {
                    Inserido = Inserido,
                    Alterado = Alterado,
                    Ignorado = Ignorado,
                    Falha = Falha
                };
                _intermediarioService.DeleteAll();
                return userDto;
            } catch (Exception e)
            {
                throw e;
            }
        }

        public List<Usuarios> FindAll()
        {
            return _repository.FindAll();
        }
        public Usuarios FindById(int id)
        {
            return _repository.FindById(id);
        }
        public void InsertIntermediario(IFormFile file)
        {
            _intermediarioService.Insert(file);
        }

        public void DeleteAllIntermediario()
        {
            _intermediarioService.DeleteAll();
        }

    }
}
