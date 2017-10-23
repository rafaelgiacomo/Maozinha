using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class IndexProjetosEntidadeViewModel
    {
        public List<ProjetoModel> ListaProjetos { get; set; }

        public IndexProjetosEntidadeViewModel()
        {
            ListaProjetos = new List<ProjetoModel>();
        }
    }
}