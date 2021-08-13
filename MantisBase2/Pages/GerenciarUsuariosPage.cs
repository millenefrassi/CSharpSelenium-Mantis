using MantisBase2.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Pages 
{
    public class GerenciarUsuariosPage : PageBase
    {
        By abaGerenciarUsuario = By.XPath("//a[@href='/manage_user_page.php']");
        By botaoCriarNovaConta = By.XPath("//a[@class='btn btn-primary btn-white btn-round btn-sm']");
        By nomeUsuario = By.Name("username");
        By nomeVerdadeiro = By.Name("realname");
        By email = By.Id("email-field");
        By nivelAcesso = By.Name("access_level");
        By habilitado = By.XPath("//label//input[@name='enabled']//following-sibling::span[@class='lbl']");
        By protegido = By.XPath("//label//input[@name='protected']//following-sibling::span[@class='lbl']");
        By botaoCriarUsuario = By.XPath("//input[@class='btn btn-primary btn-white btn-round']");
        By msgSucesso = By.XPath("//div[@class='alert alert-success center']");
        By pesquisarUsuario = By.XPath("//input[@class='input-sm']");
        By botaoAplicarFiltro = By.XPath("//input[@type='submit']");
        By botaoAtualizarUsuario = By.XPath("//input[@value='Atualizar Usuário']");
        By botaoApagarUsuario = By.XPath("//input[@value='Apagar Usuário']");
        By botaoApagarConta = By.XPath("//input[@value='Apagar Conta']");
        By colunaGridNomeUsuario = By.XPath("//a[contains(@href,'manage_user_edit_page.php')]");
        By msgAviso = By.XPath("//div[@class='alert alert-warning center']");
        By msgErro = By.XPath("//div[@class='alert alert-danger']/p[2]");


        public void PreencherNomeUsuario(string usuarioNome)
        {
            ClearAndSendKeys(nomeUsuario, usuarioNome);
        }

        public void PreencherNomeVerdadeiro(string verdadeiroNome)
        {
            ClearAndSendKeys(nomeVerdadeiro, verdadeiroNome);
        }

        public void PreencherEmailUsuario(string emailUsuario)
        {
            ClearAndSendKeys(email, emailUsuario);
        }
        public void PreencherNivelAcesso(string nivel)
        {
            ComboBoxSelectByVisibleText(nivelAcesso, nivel);
        }

        public void PreencherHabilitado()
        {
            Click(habilitado);
        }

        public void PreencherProtegido()
        {
            Click(protegido);
        }

        public void ClicarBotaoCriarUsuario()
        {
            Click(botaoCriarUsuario);
        }

        public void ClicarBotaoCriarNovaConta()
        {
            Click(botaoCriarNovaConta);
        }

        public void ClicarAbaGerenciarUsuario()
        {
            Click(abaGerenciarUsuario);
        }

        public string RetornarNomeUsuario()
        {
            return GetText(nomeUsuario);
        }

        public string RetornarNomeUsuarioVerdadeiro()
        {
            return GetText(nomeVerdadeiro);
        }

        public string RetornarEmailUsuario()
        {
            return GetText(email);
        }

        public string RetornarMsgSucesso()
        {
            return GetText(msgSucesso);
        }

        public void PesquisarUsuario(string usuario)
        {
            SendKeys(pesquisarUsuario,usuario);
        }

        public void ClicarBotaoAplicarFiltro()
        {
            Click(botaoAplicarFiltro);
        }

        public void ClicarBotaoAtualizarUsuario()
        {
            Click(botaoAtualizarUsuario);
        }

        public void ClicarBotaoApagarUsuario()
        {
            Click(botaoApagarUsuario);
        }

        public void ClicarBotaoApagarConta()
        {
            Click(botaoApagarConta);
        }

        public void ClicarColunaGridNomeUsuario()
        {
            Click(colunaGridNomeUsuario);
        }

        public string RetornarMsgAviso()
        {
            return GetText(msgAviso);
        }

        public string RetornarMsgErro()
        {
            return GetText(msgErro);
        }
    }
}
