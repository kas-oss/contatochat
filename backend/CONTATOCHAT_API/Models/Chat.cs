using System.Collections.Generic;

namespace CONTATOCHAT_API.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        
        public string Conteudo { get; set; }

        public string ContatoId { get; set; }

        public string ConversaId { get; set; }

        public string TipoConteudo { get; set; }
    }

    public class MensagemList
    {
        public int Id { get; set; }

        public List<Mensagem> Conteudo { get; set; }
    }

    public class Sessao
    {

        // Usuario
        // Contatos
        // Conversas

    }



}
