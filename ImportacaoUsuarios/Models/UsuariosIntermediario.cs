using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Models
{
    public class UsuariosIntermediario
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType("dd/MM/yyyy")]
        public DateTime DataNascimento { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        public int UserId { get; set; }

        /*
        public UsuariosIntermediario() { }

        public UsuariosIntermediario(string nome, string email, DateTime dataNascimento, char sexo, int userId)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            UserId = userId;
        }
        */
    }
}
