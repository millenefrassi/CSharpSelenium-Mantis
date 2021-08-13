using MantisBase2.Bases;
using MantisBase2.DataBaseSteps;
using MantisBase2.Flows;
using MantisBase2.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Tests
{
    public class GerenciarMarcadorTests : TestBase
    {
        #region Pages and Flows Objects
        LoginFlows loginFlows;
        GerenciarMarcadoresPage gerenciarMarcadoresPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;
        MarcadorFlows marcadorFlows;
        #endregion

        public string usuario = ConfigurationManager.AppSettings["usuario"];
        public string senha = ConfigurationManager.AppSettings["senha"];

        [Test]
        [Description("Realizar o cadastro de marcador")]
        public void RealizarCadastroMarcador()
        {

            loginFlows = new LoginFlows();
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string marcador = "Marcador teste";
            string descricao = "description marcador";
            #endregion

            MarcadorDBSteps.DeletarMarcadorCadastrado(marcador);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaGerenciarMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(marcador);
            gerenciarMarcadoresPage.PreencherDescricaoMarcador(descricao);
            gerenciarMarcadoresPage.ClicarBotaoCriarMarcador();

            Assert.AreEqual("1", MarcadorDBSteps.RetornaQtdeMarcador(marcador, descricao));
        }

        [Test]
        [Description("Realizar edição do campo nome marcador")]
        public void AlterarNomeMarcador()
        {

            loginFlows = new LoginFlows();
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            marcadorFlows = new MarcadorFlows();

            #region parameters
            string marcador = "Tag Editada";
            string marcadorEditada = "Tag Editada Manual";
            #endregion

            MarcadorDBSteps.DeletarMarcadorCadastrado(marcador);
            MarcadorDBSteps.DeletarMarcadorCadastrado(marcadorEditada);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            marcadorFlows.CadastrarNovoMarcador();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaGerenciarMarcador();
            gerenciarMarcadoresPage.ClicarGridNomeMarcador();
            gerenciarMarcadoresPage.ClicarBotaoAtualizarMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(marcadorEditada);
            gerenciarMarcadoresPage.ClicarBotaoAtualizarMarcador();

            Assert.AreEqual(marcadorEditada, MarcadorDBSteps.RetornaNomeMarcador(marcadorEditada));
        }

        [Test]
        [Description("Realizar edição do campo descrição marcador")]
        public void AlterarDescricaoMarcador()
        {

            loginFlows = new LoginFlows();
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            marcadorFlows = new MarcadorFlows();

            #region parameters
            string marcador = "Tag Editada";
            string descricaoEditada = "Tag Descricao Manual";
            #endregion

            MarcadorDBSteps.DeletarMarcadorCadastrado(marcador);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            marcadorFlows.CadastrarNovoMarcador();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaGerenciarMarcador();
            gerenciarMarcadoresPage.ClicarGridNomeMarcador();
            gerenciarMarcadoresPage.ClicarBotaoAtualizarMarcador();
            gerenciarMarcadoresPage.PreencherDescricaoMarcador(descricaoEditada);
            gerenciarMarcadoresPage.ClicarBotaoAtualizarMarcador();

            Assert.AreEqual(descricaoEditada, MarcadorDBSteps.RetornaDescricaoMarcador(marcador));
        }

        [Test]
        [Description("Realizar edição do campo criador marcador")]
        public void AlterarCriadorMarcador()
        {

            loginFlows = new LoginFlows();
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            marcadorFlows = new MarcadorFlows();

            #region parameters
            string marcador = "Tag Editada";
            string criador = "administrator";
            #endregion

            MarcadorDBSteps.DeletarMarcadorCadastrado(marcador);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            marcadorFlows.CadastrarNovoMarcador();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaGerenciarMarcador();
            gerenciarMarcadoresPage.ClicarGridNomeMarcador();
            gerenciarMarcadoresPage.ClicarBotaoAtualizarMarcador();
            gerenciarMarcadoresPage.PreencherCriador(criador);
            gerenciarMarcadoresPage.ClicarBotaoAtualizarMarcador();

            Assert.AreEqual(criador, MarcadorDBSteps.RetornaCriadorMarcador(marcador));
        }

        [Test]
        [Description("Realizar o delete do marcador")]
        public void ApagarMarcador()
        {

            loginFlows = new LoginFlows();
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            marcadorFlows = new MarcadorFlows();

            #region parameters
            string marcador = "Tag Editada";
            #endregion

            MarcadorDBSteps.DeletarMarcadorCadastrado(marcador);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            marcadorFlows.CadastrarNovoMarcador();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaGerenciarMarcador();
            gerenciarMarcadoresPage.ClicarGridNomeMarcador();
            gerenciarMarcadoresPage.ClicarBotaoApagarMarcador();
            gerenciarMarcadoresPage.ClicarBotaoApagarMarcador();

            Assert.AreEqual("0", MarcadorDBSteps.RetornaMarcadorDeletado(marcador));
        }
    }
}
