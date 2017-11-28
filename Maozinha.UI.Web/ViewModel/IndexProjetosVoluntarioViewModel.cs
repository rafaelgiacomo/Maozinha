using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class IndexProjetosVoluntarioViewModel
    {

        #region Propriedades

        public List<ProjetoModel> ListaProjetos { get; set; }

        public int Visao { get; set; }

        #endregion


        public IndexProjetosVoluntarioViewModel()
        {
            ListaProjetos = new List<ProjetoModel>();
            Visao = 1;
        }

    }
}