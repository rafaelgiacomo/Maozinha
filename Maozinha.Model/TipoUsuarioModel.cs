namespace Maozinha.Model
{
    public class TipoUsuarioModel
    {
        #region Constantes

        public const string DescricaoVoluntario = "Voluntario";
        public const string DescricaoEntidade = "Entidade";
        public const string DescricaoAdmin = "Admin";
        public const int IdVoluntario = 1;
        public const int IdEntidade = 2;
        public const int IdAdmin = 3;

        #endregion

        #region Propriedades

        public int Id { get; set; }

        public string Descricao { get; set; }

        #endregion
    }
}
