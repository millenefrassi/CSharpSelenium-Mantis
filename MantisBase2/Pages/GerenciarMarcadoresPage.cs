using MantisBase2.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Pages
{
    public class GerenciarMarcadoresPage : PageBase
    {
        By abaGerenciarMarcador = By.XPath("//a[@href='/manage_tags_page.php']");
        By botaoCriarMarcador = By.XPath("//input[@value='Criar Marcador']");
        By nomeMarcador = By.Id("tag-name");
        By descricaoMarcador = By.Id("tag-description");
        By botaoAtualizarMarcador = By.XPath("//input[@value='Atualizar Marcador']");
        By botaoApagarMarcador = By.XPath("//input[@value='Apagar Marcador']");
        By criador = By.Id("tag-user-id");
        By colunaGridNomeMarcador = By.XPath("//a[contains(@href,'tag_view_page.php')]");


        public void ClicarGridNomeMarcador()
        {
            Click(colunaGridNomeMarcador);
        }

        public void PreencherCriador(string criadorUser)
        {
            ComboBoxSelectByVisibleText(criador, criadorUser);
        }

        public void ClicarBotaoAtualizarMarcador()
        {
            Click(botaoAtualizarMarcador);
        }

        public void ClicarBotaoApagarMarcador()
        {
            Click(botaoApagarMarcador);
        }

        public void ClicarAbaGerenciarMarcador()
        {
            Click(abaGerenciarMarcador);
        }

        public void ClicarBotaoCriarMarcador()
        {
            Click(botaoCriarMarcador);
        }

        public void PreencherNomeMarcador(string marcador)
        {
            ClearAndSendKeys(nomeMarcador, marcador);
        }

        public void PreencherDescricaoMarcador(string descricao)
        {
            ClearAndSendKeys(descricaoMarcador, descricao);
        }
    }
}
