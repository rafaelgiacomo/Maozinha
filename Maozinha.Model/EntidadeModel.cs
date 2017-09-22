using System.Collections.Generic;

namespace Maozinha.Model
{
    public class EntidadeModel : UsuarioModel
    {

        #region Propriedades

        public string Cnpj { get; set; }

        public List<ProjetoModel> Projetos { get; set; }

        #endregion

    }
}
