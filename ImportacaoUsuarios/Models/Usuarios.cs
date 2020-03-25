using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Models
{
    public class Usuarios
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public Usuarios() { }

        public Usuarios(int id, string nome, string email, DateTime dataNascimento, char sexo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Sexo = sexo;
        }

        public override bool Equals(object obj)
        {
            return obj is Usuarios usuarios &&
                   Id == usuarios.Id &&
                   Nome == usuarios.Nome &&
                   Email == usuarios.Email &&
                   DataNascimento == usuarios.DataNascimento &&
                   Sexo == usuarios.Sexo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Email, DataNascimento, Sexo);
        }
    }
}
