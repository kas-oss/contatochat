using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CONTATOCHAT_API.Models
{
    public class Contato
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string fotoPerfil { get; set; }
    }

}
