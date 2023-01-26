using System.Collections.Generic;
using CONTATOCHAT_API.Models;

namespace CONTATOCHAT_API.Services
{
    public interface IUsuarioService
    {

        List<Contato> ListUsuarios();
        int RegistrarContato(NovoContato contato);
    }
}