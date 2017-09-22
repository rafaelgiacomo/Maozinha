using System.ComponentModel.DataAnnotations;

namespace Maozinha.UI.Web.ViewModel
{
    public class UsuarioViewModel
    {
        #region Propriedades

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "UF")]
        public string Uf { get; set; }

        public string Cidade { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public int ArquivoId { get; set; }

        #endregion
    }
}