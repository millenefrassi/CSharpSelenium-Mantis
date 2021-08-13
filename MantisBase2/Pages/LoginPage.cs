using MantisBase2.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Pages
{
    public class LoginPage : PageBase
    {
        By nomeUsuario = By.Id("username");
        By senhaUsuario = By.Id("password");
        By botaoEntrar = By.XPath("//input[@value='Entrar']");
        By msgErro = By.XPath("//div[@class='alert alert-danger']/p");

        public void PreencherUsuario(string usuario)
        {
            SendKeys(nomeUsuario, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(senhaUsuario, senha);
        }

        public void ClicarBotaoEntrar()
        {
            Click(botaoEntrar);
        }

        public string RetornarMsgErro()
        {
            return GetText(msgErro);
        }

        #region JavaScript
        public void PreencherUsuarioJavaScript(string usuario)
        {
            SendKeysJavaScript(nomeUsuario, usuario);
        }

        public void PreencherSenhaJavaScript(string senha)
        {
            SendKeysJavaScript(senhaUsuario, senha);
        }

        public void ClicarBotaoEntrarJavaScript()
        {
            ClickJavaScript(botaoEntrar);
        }

        #endregion
    }
}
