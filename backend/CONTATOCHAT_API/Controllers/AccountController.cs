using CONTATOCHAT_API.Models;
using CONTATOCHAT_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CONTATOCHAT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IUsuarioService _usuarioService;


        public AccountController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        [Route("Login")]
        public Sessao Login([FromBody] UsuarioLogin login)
        {
            var loginResult = new Sessao();

            return loginResult;
        }


        [HttpPost]
        [Route("Registro")]
        public Sessao RegistrarUsuario([FromBody] NovoUsuario usuario)
        {
            var idUsuario = 0;
            
            var registro = new Sessao();

            registro.usuario = new Usuario();

            try
            {
                idUsuario = _usuarioService.RegistrarUsuario(usuario);
                
                registro.contatoList = RetornarContatos();

                //registro.conversaList = RetornarConvesasPorId(idUsuario);

            }
            catch (Exception ex)
            {
                registro.usuario.id = -1;
            }

            return registro;
        }


        [HttpGet]
        [Route("ListContatos")]
        public List<Contato> RetornarContatos()
        {

            var contatos = _usuarioService.ListContato();

            return contatos;
        }

        [HttpGet]
        [Route("ListConversas")]
        public List<Conversa> RetornarConvesasPorId(int id)
        {

            var contatos = _usuarioService.ListConvesaId(id);

            return contatos;
        }



    }
}
