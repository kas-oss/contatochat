using CONTATOCHAT_API.Models;
using CONTATOCHAT_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CONTATOCHAT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        [Route("Create")]
        public ConversaCreate CriarConversa(ConversaCreate conversaCreate)
        {
            try
            {
                var conversa = new Conversa();
            }
            catch (Exception ex)
            {
                var coversaCreate = _chatService.CriarConversa(conversaCreate);
            }

            return conversaCreate;
        }

        [HttpPost]
        [Route("EnviarMensagem")]
        public Conversa EnviarMensagem()
        {
            var conversa = new Conversa();

            return conversa;
        }

    }
}
