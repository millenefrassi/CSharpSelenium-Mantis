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
    public class GerenciarPerfisGlobaisTests : TestBase
    {
        #region Pages and Flows Objects
        LoginFlows loginFlows;
        GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;
        PerfilFlows perfilFlows;
        #endregion

        public string usuario = ConfigurationManager.AppSettings["usuario"];
        public string senha = ConfigurationManager.AppSettings["senha"];

        [Test]
        [Description("Realizar o cadastro de um novo perfil")]
        public void RealizarCadastroNovoPerfil()
        {
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();


            #region parameters
            string plataforma = "Teste Plataforma";
            string so = "windows";
            string versaoSO = "10";
            string descricaoAdicional = "Teste para automação";
            #endregion

            PerfisDBSteps.DeletarPerfilCadastrado(plataforma);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.ClicarAbaGerenciarProjeto();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.PreencherSO(so);
            gerenciarPerfisGlobaisPage.PreencherVersaoSO(versaoSO);
            gerenciarPerfisGlobaisPage.PreencherDescricaoAdicional(descricaoAdicional);
            gerenciarPerfisGlobaisPage.ClicarBotaoAdicionarPerfil();

            Assert.AreEqual("1", PerfisDBSteps.RetornaQtdePerfil(plataforma, so, versaoSO, descricaoAdicional));
        }

        [Test]
        [Description("Alterar perfil campo plataforma")]
        public void AlterarPerfilCampoPlataforma()
        {
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            perfilFlows = new PerfilFlows();

            #region parameters
            string plataforma = "Edita Plataforma";
            string so = "Linux";
            string versaoSO = "8";
            string plataformaEditada = "Edita Teste";
            string valuePerfil = plataforma + " " + so + " " + versaoSO;
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            perfilFlows.CadastrarNovoPerfil();
            gerenciarPerfisGlobaisPage.ClicarAbaGerenciarProjeto();
            gerenciarPerfisGlobaisPage.PreencherSelecionarPerfil(valuePerfil);
            gerenciarPerfisGlobaisPage.ClicarBotaoEditarPerfil();
            gerenciarPerfisGlobaisPage.ClicarBotaoEnviar();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataformaEditada);
            gerenciarPerfisGlobaisPage.ClicarBotaoAtualizarPerfil();

            Assert.AreEqual("1", PerfisDBSteps.RetornaPlataforma(plataformaEditada));
        }

        [Test]
        [Description("Alterar perfil campo SO")]
        public void AlterarPerfilCampoSO()
        {
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            perfilFlows = new PerfilFlows();

            #region parameters
            string plataforma = "Edita Plataforma";
            string so = "Linux";
            string versaoSO = "8";
            string soEditada = "windows";
            string valuePerfil = plataforma + " " + so + " " + versaoSO;
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            perfilFlows.CadastrarNovoPerfil();
            gerenciarPerfisGlobaisPage.ClicarAbaGerenciarProjeto();
            gerenciarPerfisGlobaisPage.PreencherSelecionarPerfil(valuePerfil);
            gerenciarPerfisGlobaisPage.ClicarBotaoEditarPerfil();
            gerenciarPerfisGlobaisPage.ClicarBotaoEnviar();
            gerenciarPerfisGlobaisPage.PreencherSO(soEditada);
            gerenciarPerfisGlobaisPage.ClicarBotaoAtualizarPerfil();

            Assert.AreEqual(soEditada, PerfisDBSteps.RetornaSO(plataforma));
        }

        [Test]
        [Description("Alterar perfil campo versão SO")]
        public void AlterarPerfilCampoVersaoSO()
        {
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            perfilFlows = new PerfilFlows();

            #region parameters
            string plataforma = "Edita Plataforma";
            string so = "Linux";
            string versaoSO = "8";
            string versaoSOEditada = "10";
            string valuePerfil = plataforma + " " + so + " " + versaoSO;
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            perfilFlows.CadastrarNovoPerfil();
            gerenciarPerfisGlobaisPage.ClicarAbaGerenciarProjeto();
            gerenciarPerfisGlobaisPage.PreencherSelecionarPerfil(valuePerfil);
            gerenciarPerfisGlobaisPage.ClicarBotaoEditarPerfil();
            gerenciarPerfisGlobaisPage.ClicarBotaoEnviar();
            gerenciarPerfisGlobaisPage.PreencherVersaoSO(versaoSOEditada);
            gerenciarPerfisGlobaisPage.ClicarBotaoAtualizarPerfil();

            Assert.AreEqual(versaoSOEditada, PerfisDBSteps.RetornaVersaoSO(plataforma));
        }

        [Test]
        [Description("Alterar perfil campo descrição adicional")]
        public void AlterarPerfilCampoDescricaoAdicional()
        {
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            perfilFlows = new PerfilFlows();

            #region parameters
            string plataforma = "Edita Plataforma";
            string so = "Linux";
            string versaoSO = "8";
            string descricaoAdicionalEditada = "Projeto Automação";
            string valuePerfil = plataforma + " " + so + " " + versaoSO;
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            perfilFlows.CadastrarNovoPerfil();
            gerenciarPerfisGlobaisPage.ClicarAbaGerenciarProjeto();
            gerenciarPerfisGlobaisPage.PreencherSelecionarPerfil(valuePerfil);
            gerenciarPerfisGlobaisPage.ClicarBotaoEditarPerfil();
            gerenciarPerfisGlobaisPage.ClicarBotaoEnviar();
            gerenciarPerfisGlobaisPage.PreencherDescricaoAdicional(descricaoAdicionalEditada);
            gerenciarPerfisGlobaisPage.ClicarBotaoAtualizarPerfil();

            Assert.AreEqual(descricaoAdicionalEditada, PerfisDBSteps.RetornaDescricaoAdicional(plataforma));
        }

        [Test]
        [Description("Apagar Perfil Global")]
        public void ApagarPerfilGlobal()
        {
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            perfilFlows = new PerfilFlows();

            #region parameters
            string plataforma = "Edita Plataforma";
            string so = "Linux";
            string versaoSO = "8";
            string valuePerfil = plataforma + " " + so + " " + versaoSO;
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            perfilFlows.CadastrarNovoPerfil();
            gerenciarPerfisGlobaisPage.ClicarAbaGerenciarProjeto();
            gerenciarPerfisGlobaisPage.PreencherSelecionarPerfil(valuePerfil);
            gerenciarPerfisGlobaisPage.ClicarBotaoApagarPerfil();
            gerenciarPerfisGlobaisPage.ClicarBotaoEnviar();

            Assert.AreEqual("0", PerfisDBSteps.RetornaPlataforma(plataforma));
        }
    }
}
