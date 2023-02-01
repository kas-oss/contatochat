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

    public class Conversa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string foto { get; set; }
        public List<Contato> contatoList { get; set; }
        public List<Mensagem> mensagemList { get; set; }
    }

    public class ConversaCreate
    {
        public int? id { get; set; }
        public string nome { get; set; }
        public string foto { get; set; }
        public int participante1 { get; set; }
        public int participante2 { get; set; }
    }


}
