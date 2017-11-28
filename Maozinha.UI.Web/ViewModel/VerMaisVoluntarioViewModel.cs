using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class VerMaisVoluntarioViewModel : ContaVoluntarioViewModel
    {

        public int ProjetoId { get; set; }

        public bool Selecionado { get; set; }

        public VerMaisVoluntarioViewModel()
        {
            Selecionado = false;
        }
    }
}