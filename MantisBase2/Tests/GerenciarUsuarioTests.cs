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
    public class GerenciarUsuarioTests : TestBase
    {
        #region Pages and Flows Objects
        LoginFlows loginFlows;
        GerenciarUsuariosPage gerenciarUsuarioPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;
        UsuarioFlows usuarioFlows;
        #endregion

        public string usuario = ConfigurationManager.AppSettings["usuario"];
        public string senha = ConfigurationManager.AppSettings["senha"];

        [Test]
        [Description("Realizar o cadastro de um novo usuário para acesso ao mantis")]
        public void RealizarCadastroNovoUsuario()
        {
            loginFlows = new LoginFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "UsuarioTeste";
            string nomeVerdadeiro = "Usuario Teste Verdadeiro";
            string email = "usuarioteste@base2.com.br";
            string nivelAcesso = "desenvolvedor";
            #endregion

            UsuariosDBSteps.DeletarUsuarioEditado(nomeUsuario);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarUsuarioPage.ClicarAbaGerenciarUsuario();
            gerenciarUsuarioPage.ClicarBotaoCriarNovaConta();
            gerenciarUsuarioPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuarioPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuarioPage.PreencherEmailUsuario(email);
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.PreencherHabilitado();
            gerenciarUsuarioPage.PreencherProtegido();
            gerenciarUsuarioPage.ClicarBotaoCriarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("1", UsuariosDBSteps.VerificaUsuarioCadastrado(nomeUsuario, nomeVerdadeiro, email, "55", "0", "1"));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("criado com um nível de acesso de desenvolvedor"));
            });
        }

        [Test]
        [Description("Realizar cadastro de um usuário já existente")]
        public void RealizarCadastroUsuarioExistente()
        {
            loginFlows = new LoginFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            usuarioFlows = new UsuarioFlows();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nomeVerdadeiro = " Usuario Edicao Verdadeiro";
            string email = "usuarioedicao@gmail.com";
            string nivelAcesso = "relator";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarUsuarioPage.ClicarAbaGerenciarUsuario();
            gerenciarUsuarioPage.ClicarBotaoCriarNovaConta();
            gerenciarUsuarioPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuarioPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuarioPage.PreencherEmailUsuario(email);
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoCriarUsuario();
            

            Assert.Multiple(() =>
            {
                Assert.AreEqual("1", UsuariosDBSteps.RetornaCountUsusario(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgErro().Contains("Este nome de usuário já está sendo usado. Por favor, volte e selecione um outro."));
            });
        }

        [Test]
        [Description("Realizar a edição do email de um usuário cadastrado")]
        public void AlterarEmailUsuario()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string email = "usu1@gmail.com";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherEmailUsuario(email);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(email, UsuariosDBSteps.RetornaEmailUsuario(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nome verdadeiro usuário cadastrado")]
        public void AlterarNomeVerdadeiroUsuario()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nomeVerdadeiroUsuario = "Nome Verdade";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNomeVerdadeiro(nomeVerdadeiroUsuario);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(nomeVerdadeiroUsuario, UsuariosDBSteps.RetornaNomeVerdadeiroUsuario(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nome usuário cadastrado")]
        public void AlterarNomeUsuario()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nomeUsuarioEditado = "UsuEdicaoTeste";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNomeUsuario(nomeUsuarioEditado);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(nomeUsuarioEditado, UsuariosDBSteps.RetornaNomeUsuario(nomeUsuarioEditado));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nível acesso Visualizador")]
        public void AlterarNivelAcessoVisualizador()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nivelAcesso = "visualizador";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("10", UsuariosDBSteps.RetornaNivelAcesso(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nível acesso Relator")]
        public void AlterarNivelAcessoRelator()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nivelAcesso = "relator";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("25", UsuariosDBSteps.RetornaNivelAcesso(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nível acesso Atualizador")]
        public void AlterarNivelAcessoAtualizador()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nivelAcesso = "atualizador";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("40", UsuariosDBSteps.RetornaNivelAcesso(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nível acesso Desenvolvedor")]
        public void AlterarNivelAcessoDesenvolvedor()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nivelAcesso = "desenvolvedor";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("55", UsuariosDBSteps.RetornaNivelAcesso(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nível acesso Gerente")]
        public void AlterarNivelAcessoGerente()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nivelAcesso = "gerente";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("70", UsuariosDBSteps.RetornaNivelAcesso(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do nível acesso Administrador")]
        public void AlterarNivelAcessoAdministrador()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            string nivelAcesso = "administrador";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("90", UsuariosDBSteps.RetornaNivelAcesso(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar o delete do usuário")]
        public void ApagarUsuario()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.ClicarBotaoApagarUsuario();
            string msgAviso = gerenciarUsuarioPage.RetornarMsgAviso();
            gerenciarUsuarioPage.ClicarBotaoApagarConta();
            

            Assert.Multiple(() =>
            {
                Assert.AreEqual("0", UsuariosDBSteps.RetornaCountUsusario(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
                Assert.True(msgAviso.Contains(nomeUsuario));
            });
        }

        [Test]
        [Description("Realizar a edição do campo Habilitado")]
        public void AlterarCampoHabilitadoUsuarioCadastrado()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherHabilitado();
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("0", UsuariosDBSteps.RetornaHabilitado(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar a edição do campo Protegido")]
        public void AlterarCampoProtegidoUsuarioCadastrado()
        {
            loginFlows = new LoginFlows();
            usuarioFlows = new UsuarioFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeUsuario = "usuarioEdicao";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            gerenciarUsuarioPage.PesquisarUsuario(nomeUsuario);
            gerenciarUsuarioPage.ClicarBotaoAplicarFiltro();
            gerenciarUsuarioPage.ClicarColunaGridNomeUsuario();
            gerenciarUsuarioPage.PreencherProtegido();
            gerenciarUsuarioPage.ClicarBotaoAtualizarUsuario();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("1", UsuariosDBSteps.RetornaProtegido(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgSucesso().Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar cadastro de um usuário para um email já existente")]
        public void RealizarCadastroUsuarioEmailExistente()
        {
            loginFlows = new LoginFlows();
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            usuarioFlows = new UsuarioFlows();

            #region parameters
            string nomeUsuario = "usuarioEmail";
            string nomeVerdadeiro = " Usuario Email Teste";
            string email = "usuarioedicao@gmail.com";
            string nivelAcesso = "relator";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            usuarioFlows.CadastrarNovoUsuario();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarUsuarioPage.ClicarAbaGerenciarUsuario();
            gerenciarUsuarioPage.ClicarBotaoCriarNovaConta();
            gerenciarUsuarioPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuarioPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuarioPage.PreencherEmailUsuario(email);
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoCriarUsuario();


            Assert.Multiple(() =>
            {
                Assert.AreEqual("0", UsuariosDBSteps.RetornaCountUsusario(nomeUsuario));
                Assert.True(gerenciarUsuarioPage.RetornarMsgErro().Contains("Este e-mail já está sendo usado. Por favor, volte e selecione outro."));
            });
        }

    }
}
