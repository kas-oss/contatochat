using CONTATOCHAT_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CONTATOCHAT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private static List<NovoContato> contatos = new List<NovoContato>();

        [HttpPost]
        public void ContatoCreate([FromBody] NovoContato contato)
        {
            contatos.Add(contato);
        }


        [HttpGet]
        public IEnumerable<NovoContato> RetornarContatos()
        {
            return contatos;
        }
    }
}
