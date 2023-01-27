using System.Collections.Generic;
using CONTATOCHAT_API.Models;

namespace CONTATOCHAT_API.Services
{
    public interface IChatService
    {
        ConversaCreate CriarConversa(ConversaCreate conversaCreate);
    }
}