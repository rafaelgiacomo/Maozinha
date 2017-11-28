using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maozinha.Model
{
    public class VoluntarioProjetoModel
    {
        #region Propriedades

        public int VoluntarioId { get; set; }

        public int ProjetoId { get; set; }

        public ProjetoModel Projeto { get; set; }

        public VoluntarioModel Voluntario { get; set; }

        #endregion
    }
}
