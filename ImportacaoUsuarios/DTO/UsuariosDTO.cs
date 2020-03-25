using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.DTO
{
    public class UsuariosDTO
    {
        public int Inserido { get; set; }
        public int Alterado { get; set; }
        public int Ignorado { get; set; }
        public int Falha { get; set; }

        public UsuariosDTO() { }
    }
}
