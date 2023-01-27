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

        [HttpPost]
        [Route("EnviarMensagem")]
        public Conversa EnviarMensagem()
        {
            var conversa = new Conversa(); 

            return conversa;
        }

    }
}
