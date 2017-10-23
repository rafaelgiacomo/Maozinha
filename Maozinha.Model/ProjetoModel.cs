using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maozinha.Model
{
    public class ProjetoModel
    {
        #region Propriedades

        public int Id { get; set; }

        public int EntidadeId { get; set; }

        public int CategoriaId { get; set; }

        public int ArquivoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Endereco { get; set; }

        public int QtdVagas { get; set; }

        public EntidadeModel Entidade { get; set; }

        public CategoriaProjetoModel Categoria { get; set; }

        public ArquivoModel Arquivo { get; set; }

        public List<VoluntarioModel> Voluntarios { get; set; }

        #endregion
    }
}
