using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class ImagemProjetoViewModel
    {

        #region Propriedades

        public int ProjetoId { get; set; }

        public List<ArquivoModel> Imagens { get; set; }

        #endregion

        public ImagemProjetoViewModel()
        {
            Imagens = new List<ArquivoModel>();
        }

    }
}