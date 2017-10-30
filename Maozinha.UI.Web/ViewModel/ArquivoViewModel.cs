using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class ArquivoViewModel
    {

        #region Constantes

        public const string CaminhoUpload = "~/Content/Uploads";

        #endregion

        #region Propriedades

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descreva mais sobre as fotos que esta subindo.")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Selecione pelo menos um arquivo para upload")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        #endregion

        public ArquivoViewModel()
        {

        }
    }
}