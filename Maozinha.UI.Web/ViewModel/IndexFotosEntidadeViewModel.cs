using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class IndexFotosEntidadeViewModel
    {
        #region Constantes

        public const string CaminhoUpload = "~/Content/Uploads";

        #endregion

        #region Propriedades

        public List<ArquivoModel> ListaFotos { get; set; }

        #endregion

        public IndexFotosEntidadeViewModel()
        {
            ListaFotos = new List<ArquivoModel>();
        }
    }
}