using System.Collections.Generic;
using CONTATOCHAT_API.Models;

namespace CONTATOCHAT_API.Services
{
    public interface IUsuarioService
    {
        List<Contato> ListContato();
        int RegistrarUsuario(NovoUsuario usuario);
        List<Conversa> ListConvesaId(int id);
        Usuario ConsultarUsuarioId(int id);
        Usuario TestLogin(UsuarioLogin login);
    }
}