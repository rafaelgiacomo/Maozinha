using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class BuscaProjetosViewModel
    {
        public List<ProjetoModel> Projetos { get; set; }

        public BuscaProjetosViewModel()
        {
            Projetos = new List<ProjetoModel>();
        }
    }
}