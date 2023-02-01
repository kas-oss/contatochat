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
            var conversa = new ConversaCreate();

            try
            {
                conversaCreate.id = 0;
                conversa = _chatService.CriarConversa(conversaCreate);
            }
            catch (Exception ex)
            {
                conversa = new ConversaCreate();
            }

            return conversa;
        }

        // Enviar Mensagens

        [HttpPost]
        [Route("EnviarMensagem")]
        public Conversa EnviarMensagem()
        {
            var conversa = new Conversa();

            return conversa;
        }

        // Listar Mensagens
        [HttpPost]
        [Route("ListarMensagens")]
        public Conversa ListMensagens(int id)
        {
            var conversa = new Conversa();

            return conversa;
        }

    }
}
