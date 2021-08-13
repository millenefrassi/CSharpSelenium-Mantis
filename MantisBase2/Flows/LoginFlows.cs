using MantisBase2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Flows
{
    public class LoginFlows
    {
        #region Page Object and Constructor
        LoginPage loginPage;

        public LoginFlows()
        {
            loginPage = new LoginPage();
        }
        #endregion

        public void RealizarLoginSucesso(string usuario, string senha)
        {
            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarBotaoEntrar();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarBotaoEntrar();
        }
    }
}
