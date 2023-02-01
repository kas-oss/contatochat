using System;
using System.Collections.Generic;

namespace CONTATOCHAT_API.Models
{
    public class Mensagem
    {
        public int id { get; set; }
        public string conteudo { get; set; }
        public int contatoId { get; set; }
        public int conversaId { get; set; }
        public int tipoConteudo { get; set; }
        public DateTime dataHora { get; set; }
    }

    public class reqMensagem
    {
        public string conteudo { get; set; }
        public int contatoId { get; set; }
        public int conversaId { get; set; }
        public int? tipoConteudo { get; set; }
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
