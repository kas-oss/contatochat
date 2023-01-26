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
        public LoginResult Login([FromBody] ContatoLogin login)
        {
            var loginResult = new LoginResult();

            return loginResult;
        }


        [HttpPost]
        [Route("Create")]
        public int Create([FromBody] NovoContato contato)
        {
            var result = 0;

            try
            {
                result = _usuarioService.RegistrarContato(contato);
            }

            catch(Exception ex)
            {
                result = -1;
            }

            return result;
        }


        [HttpGet]
        [Route("ListUser")]
        public List<Contato> RetornarContatos()
        {

            var contatos = _usuarioService.ListUsuarios();

            return contatos;
        }



    }
}
