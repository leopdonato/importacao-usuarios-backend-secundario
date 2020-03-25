using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportacaoUsuarios.DTO;
using ImportacaoUsuarios.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImportacaoUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult PostIntermediario(IFormFile file)
        {
            if (file == null) return BadRequest();
            _usuarioService.InsertIntermediario(file);
            return Ok();
        }

        [HttpPost("Confirmado")]
        public IActionResult Post()
        {
            UsuariosDTO userDto = _usuarioService.Insert();
            return Ok(userDto);
        }
    }
}