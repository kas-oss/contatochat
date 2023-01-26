using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CONTATOCHAT_API.Models
{
    public class Contato
    {
        public int id { get; set; }

        public string name {get; set;}

        public string email { get; set;}

        public string phone { get; set;}

        public string profilePicture { get; set;}

    }


    public class NovoContato
    {
        [Required(ErrorMessage = "É preciso informar o nome")]
        public string name { get; set; }

        [Required(ErrorMessage = "É preciso informar o email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "É preciso informar o telefone")]
        [RegularExpression("[0-9]+",ErrorMessage ="Informe somente os números")]
        public string phone { get; set; }

        [Required(ErrorMessage = "É preciso informar uma senha")]
        public string pass { get; set; }
        
        [Required(ErrorMessage = "É preciso informar uma senha")]
        public string confirmPass { get; set; }

        public string profilePicture { get; set; }

    }

    public class ContatoLogin
    {
        [Required(ErrorMessage = "É preciso informar o login")]
        public string login { get; set; }

        [Required(ErrorMessage = "É preciso informar a senha")]
        public string password { get; set; }
    }

    public class LoginResult
    {
        public string name { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string profilePicture { get; set; }

        public bool resultLogin { get; set; }

        public List<Contato> list { get;set; }
    }
}
