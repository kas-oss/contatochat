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
            var sessao = new Sessao();
            Usuario testLogin = null;
            try
            {
                testLogin = _usuarioService.TestLogin(login);
                if (testLogin.email == null)
                {
                    HttpContext.Response.StatusCode = 400;
                }
                else
                {
                    sessao.usuario = testLogin;
                    sessao.contatoList = RetornarContatos();
                    sessao.conversaList = RetornarConvesasPorId(sessao.usuario.id);
                }
            }
            catch(Exception ex)
            {
                // faz nada
            }
            return sessao;
        }

        [HttpPost]
        [Route("Registro")]
        public Sessao RegistrarUsuario([FromBody] NovoUsuario usuario)
        {
            var registro = new Sessao();

            try
            {
                var idUsuario = _usuarioService.RegistrarUsuario(usuario);

                registro.usuario     = RetornarUsuario(idUsuario);
                
                registro.contatoList = RetornarContatos();

                registro.conversaList = RetornarConvesasPorId(idUsuario);

            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 400;

                registro = new Sessao();
            }

            return registro;
        }

        private Usuario RetornarUsuario(int id)
        {
            var usuario = _usuarioService.ConsultarUsuarioId(id);

            return usuario;
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
