using System.Collections.Generic;

namespace CONTATOCHAT_API.Models
{
    public class Mensagem
    {
        public int id { get; set; }
        public string conteudo { get; set; }
        public string contatoId { get; set; }
        public string conversaId { get; set; }
        public string tipoConteudo { get; set; }
    }

    public class Usuario
    {
        int id { get; set; }
        string name { get; set; }
        public string email { get; set;}
        public string phone { get; set;}
    }

    public class Contato
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string profilePicture { get; set; }
    }

    public class Conversa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string foto { get; set; }
        public List<Contato> contatoList { get; set; }
        public List<Mensagem> mensagemList { get; set; }
    }

    public class Sessao
    {
        Usuario usuario { get; set; }
        List<Conversa> conversaList { get; set; }
    }

}
