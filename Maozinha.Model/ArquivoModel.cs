using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maozinha.Model
{
    public class ArquivoModel
    {
        #region Constantes

        public const string CaminhoUpload = "~/Content/Uploads";

        #endregion

        #region Propriedades

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Caminho { get; set; }

        public string Tipo { get; set; }

        #endregion
    }
}
