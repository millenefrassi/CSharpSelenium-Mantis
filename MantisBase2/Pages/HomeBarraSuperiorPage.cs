using MantisBase2.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Pages
{
    public class HomeBarraSuperiorPage : PageBase
    {

        By usuarioLogado = By.XPath("//span[@class='user-info']");
        By labelTitulo = By.XPath("//span[@class='smaller-75']");
        By menuMinhaVisao = By.XPath("//li/a[@href=' / my_view_page.php']");
        By menuVerTarefas = By.XPath("//li/a[@href='/view_all_bug_page.php']");
        By menuRegistroDeMudancas = By.XPath("//li/a[@href='/changelog_page.php']");
        By menuPlanejamento = By.XPath("//li/a[@href='/roadmap_page.php']");
        By menuResumo = By.XPath("//li/a[@href='/summary_page.php']");
        By menuGerenciar = By.XPath("//li/a[@href='/manage_overview_page.php']");

        public string RetornarUsuarioLogado()
        {
            return GetText(usuarioLogado);
        }

        public string RetornarLabelTitulo()
        {
            return GetText(labelTitulo);
        }
        public void ClicarMenuMinhaVisao()
        {
            Click(menuMinhaVisao);
        }

        public void ClicarMenuVerTarefas()
        {
            Click(menuVerTarefas);
        }
        public void ClicarMenuRegistroDeMudancas()
        {
            Click(menuRegistroDeMudancas);
        }
        public void ClicarMenuPlanejamento()
        {
            Click(menuPlanejamento);
        }

        public void ClicarMenuResumo()
        {
            Click(menuResumo);
        }

        public void ClicarMenuGerenciar()
        {
            Click(menuGerenciar);
        }
    }
}
