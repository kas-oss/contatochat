using CONTATOCHAT_API.Models;
using CONTATOCHAT_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost]
        [Route("EnviarMensagem")]
        public Conversa EnviarMensagem(reqMensagem msg)
        {
            _chatService.EnviarMensagem(msg);

            var conversa = GetConversa(msg.conversaId);

            return conversa;
        }

        [HttpGet]
        [Route("GetConversa")]
        public Conversa GetConversa(int id)
        {
            var conversa = _chatService.GetConversa(id);

            return conversa;
        }

    }
}
