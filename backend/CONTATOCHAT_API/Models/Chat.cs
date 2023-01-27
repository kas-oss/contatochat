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
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set;}
        public string telefone { get; set;}
        public string fotoPerfil { get; set; }

    }

    public class Contato
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string fotoPerfil { get; set; }
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
        public Usuario usuario { get; set; }
        public List<Conversa> conversaList { get; set; }
        public List<Contato> contatoList { get; set; }
    }

}
