using Maozinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maozinha.UI.Web.ViewModel
{
    public class VerVoluntariosViewModel
    {
        public ProjetoModel Projeto { get; set; }

        public List<VoluntarioModel> ListaVoluntarios { get; set; }

        public List<VoluntarioModel> ListaSelecionados { get; set; }

        public VerVoluntariosViewModel()
        {
            ListaVoluntarios = new List<VoluntarioModel>();
        }
    }
}