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
}
