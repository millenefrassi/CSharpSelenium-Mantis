using MantisBase2.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Pages
{
    public class GerenciarPerfisGlobaisPage : PageBase
    {
        By abaGerenciarProjeto = By.XPath("//a[@href='/manage_prof_menu_page.php']");
        By plataforma = By.Name("platform");
        By so = By.Name("os");
        By versaoSO = By.Name("os_build");
        By descricaoAdicional = By.Name("description");
        By botaoAdicionarPerfil = By.XPath("//input[@value='Adicionar Perfil']");
        By botaoEditarPerfil = By.XPath("//label//input[@id='action-edit']//following-sibling::span[@class='lbl']");
        By botaoApagarPerfil = By.XPath("//label//input[@id='action-delete']//following-sibling::span[@class='lbl']");
        By botaoEnviar = By.XPath("//input[@value='Enviar']");
        By botaoAtualizarPerfil = By.XPath("//input[@value='Atualizar Perfil']");
        By selecionarPerfil = By.Id("select-profile");


        public void ClicarAbaGerenciarProjeto()
        {
            Click(abaGerenciarProjeto);
        }
        public void PreencherPlataforma(string nomePlataforma)
        {
            ClearAndSendKeys(plataforma, nomePlataforma);
        }

        public void PreencherSO(string nomeSO)
        {
            ClearAndSendKeys(so, nomeSO);
        }

        public void PreencherVersaoSO(string nomeVersaoSO)
        {
            ClearAndSendKeys(versaoSO, nomeVersaoSO);
        }

        public void PreencherDescricaoAdicional(string nomeDescricaoAdicional)
        {
            ClearAndSendKeys(descricaoAdicional, nomeDescricaoAdicional);
        }

        public void ClicarBotaoAdicionarPerfil()
        {
            Click(botaoAdicionarPerfil);
        }

        public void ClicarBotaoEditarPerfil()
        {
            Click(botaoEditarPerfil);
        }

        public void ClicarBotaoApagarPerfil()
        {
            Click(botaoApagarPerfil);
        }

        public void ClicarBotaoEnviar()
        {
            Click(botaoEnviar);
        }

        public void ClicarBotaoAtualizarPerfil()
        {
            Click(botaoAtualizarPerfil);
        }

        public void PreencherSelecionarPerfil(string textPerfil)
        {
            ComboBoxSelectByVisibleText(selecionarPerfil, textPerfil);
        }
    }
}
