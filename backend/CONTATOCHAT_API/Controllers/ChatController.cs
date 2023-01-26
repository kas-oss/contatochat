using CONTATOCHAT_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CONTATOCHAT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {

        // Conexão com banco
        private static List<NovoContato> contatos = new List<NovoContato>();

        [HttpPost]
        [Route("EnviarMensagem")]
        public MensagemList EnviarMensagem()
        {

            var msgList = new MensagemList(); 

            return msgList;
        }

        [HttpPost]
        [Route("getMensagens")]
        public MensagemList getMensagensById(string id)
        {

            var msgList = new MensagemList();

            return msgList;
        }




    }
}
