using ClosedXML.Excel;
using ImportacaoUsuarios.Models;
using ImportacaoUsuarios.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Services.Implementations
{
    public class UsuarioIntermediarioServiceImp : IUsuarioIntermediarioService
    {
        private readonly IUsuarioIntermediarioRepository _repository;

        public UsuarioIntermediarioServiceImp(IUsuarioIntermediarioRepository repository)
        {
            _repository = repository;
        }
        public void DeleteAll()
        {
            try
            {
                _repository.DeleteAll();
            } catch (Exception e)
            {
                throw e;
            }
        }

        public List<UsuariosIntermediario> FindAll()
        {
            return _repository.FindAll();
        }

        public void Insert(IFormFile file)
        {
            try
            {
                List<UsuariosIntermediario> listaUsuariosIntermediario = new List<UsuariosIntermediario>();
                Stream stream = file.OpenReadStream();
                Console.WriteLine("Teste: " + stream.CanRead);
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    for (int i = 1; i <= worksheet.RowsUsed().Count(); i++)
                    {
                        var row = worksheet.Row(i);
                        //if (row == null) continue;
                        int Id;
                        string Nome;
                        string Email;
                        string DataNascimento;
                        string Sexo;
                        int column = 1;

                        var cell = row.Cell(column);
                        //if (cell == null) continue;
                        Id = cell.GetValue<int>();
                        column++;
                        cell = row.Cell(column);
                        Nome = cell.GetValue<string>();
                        column++;
                        cell = row.Cell(column);
                        Email = cell.GetValue<string>();
                        column++;
                        cell = row.Cell(column);
                        DataNascimento = cell.GetValue<string>();
                        column++;
                        cell = row.Cell(column);
                        Sexo = cell.GetValue<string>();
                        column++;
                        DateTime DataFormatada = DateTime.ParseExact(DataNascimento, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

                        if (Nome != null && Nome != "" || Email != null && Email != "" ||
                        DataFormatada != null || Sexo != null && Sexo != "")
                        {
                            //UsuariosIntermediario user = new UsuariosIntermediario(Nome, Email, DataFormatada, Char.Parse(Sexo), Id);
                            UsuariosIntermediario user = new UsuariosIntermediario()
                            {
                                Nome = Nome,
                                Email = Email,
                                DataNascimento = DataFormatada,
                                Sexo = Char.Parse(Sexo),
                                UserId = Id
                            };
                            listaUsuariosIntermediario.Add(user);
                        }
                        else
                        {
                            throw new Exception("Não foi possível inserir na tabela de validação!");
                        }
                    }
                        _repository.DeleteAll();
                        foreach(UsuariosIntermediario usuarioIntermediario in listaUsuariosIntermediario)
                        {
                            _repository.Insert(usuarioIntermediario);
                        }
                }

            } catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
