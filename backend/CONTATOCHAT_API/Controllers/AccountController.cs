using CONTATOCHAT_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CONTATOCHAT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static List<NovoContato> contatos = new List<NovoContato>();

        [HttpGet]
        [Route("teste")]
        public string teste()
        {
            return "Olá mundo! ";
        }

        [HttpPost]
        [Route("Create")]
        public string Create([FromBody] NovoContato contato)
        {
            //contatos.Add(contato);
            return "foi ";

        }

        [HttpPost]
        [Route("Login")]
        public LoginResult Login([FromBody] ContatoLogin login)
        {


            var loginResult = new LoginResult();

            return loginResult;
        }

        [HttpGet]
        public IEnumerable<NovoContato> RetornarContatos()
        {
            return contatos;
        }
    }
}
