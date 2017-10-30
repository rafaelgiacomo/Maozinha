using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maozinha.Model
{
    public class VoluntarioModel : UsuarioModel
    {

        #region Propriedades

        public string Cpf { get; set; }

        public string DataNascimento { get; set; }

        public List<ProjetoModel> Projetos { get; set; }

        #endregion

    }
}
