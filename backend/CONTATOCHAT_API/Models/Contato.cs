using System.ComponentModel.DataAnnotations;

namespace CONTATOCHAT_API.Models
{
    public class Contato
    {
        public int Id { get; set; }

        public string nome {get; set;}

        public string email { get; set;}

        public string telefone { get; set;}

        public string senha { get; set;}

        public string foto_perfil { get; set;}

    }


    public class NovoContato
    {
        [Required(ErrorMessage = "É preciso informar o nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "É preciso informar o email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "É preciso informar o telefone")]
        [RegularExpression("[0-9]+",ErrorMessage ="Informe somente os números")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "É preciso informar uma senha")]
        public string senha { get; set; }

        public string foto_perfil { get; set; }

    }
}
