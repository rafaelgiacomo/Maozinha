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

        public int QtdSelecionados { get; set; }

        public bool Selecionado { get; set; }

        public VerVoluntariosViewModel()
        {
            Selecionado = false;
            ListaVoluntarios = new List<VoluntarioModel>();
        }
    }
}