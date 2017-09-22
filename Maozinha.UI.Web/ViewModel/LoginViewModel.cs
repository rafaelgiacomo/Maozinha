using System.ComponentModel.DataAnnotations;


namespace Maozinha.UI.Web.ViewModel
{
    public class LoginViewModel
    {
        #region Propriedades

        public string LoginVoluntario { get; set; }

        public string SenhaVoluntario { get; set; }

        public string LoginEntidade { get; set; }

        public string SenhaEntidade { get; set; }

        public string MsgErroVoluntario { get; set; }

        public string MsgErroEntidade { get; set; }

        #endregion
    }
}