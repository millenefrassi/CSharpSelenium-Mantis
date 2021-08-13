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
    public class GerenciarProjetoTests : TestBase
    {
        #region Pages and Flows Objects
        LoginFlows loginFlows;
        GerenciarProjetoPage gerenciarProjetoPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;
        ProjetoFlows projetoFlows;
        #endregion

        public string usuario = ConfigurationManager.AppSettings["usuario"];
        public string senha = ConfigurationManager.AppSettings["senha"];

        #region Projeto
        [Test]
        [Description("Realizar o cadastro de um novo projeto")]
        public void RealizarCadastroNovoProjeto()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis";
            string status = "estável";
            string visibilidade = "público";
            string descricao = "Teste para automação";
            #endregion

            ProjetoDBSteps.DeletarProjetoCadastrado(nomeProjeto);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarBotaoCriarProjeto();
            gerenciarProjetoPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetoPage.PreencherStatusProjeto(status);
            gerenciarProjetoPage.ClicarHerdarCategoriasGlobais();
            gerenciarProjetoPage.PreencherVisibilidade(visibilidade);
            gerenciarProjetoPage.PreencherDescricao(descricao);
            gerenciarProjetoPage.ClicarBotaoAdicionarProjeto(); 

            string msgSucesso = gerenciarProjetoPage.RetornarMsgSucesso();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("1", ProjetoDBSteps.VerificaProjetoCadastrado(nomeProjeto, "50", "0", "10", descricao));
                Assert.True(msgSucesso.Contains("Operação realizada com sucesso."));
            });
        }

        [Test]
        [Description("Realizar o cadastro de um projeto já existente")]
        public void RealizarCadastroProjetoExistente()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string status = "estável";
            string visibilidade = "público";
            string descricao = "Teste para automação edição";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarBotaoCriarProjeto();
            gerenciarProjetoPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetoPage.PreencherStatusProjeto(status);
            gerenciarProjetoPage.ClicarHerdarCategoriasGlobais();
            gerenciarProjetoPage.PreencherVisibilidade(visibilidade);
            gerenciarProjetoPage.PreencherDescricao(descricao);
            gerenciarProjetoPage.ClicarBotaoAdicionarProjeto(); ;

            Assert.Multiple(() =>
            {
                Assert.AreEqual("1", ProjetoDBSteps.RetornaQdteProjetoCadastrado(nomeProjeto));
                Assert.True(gerenciarProjetoPage.RetornarMsgErro().Contains("Um projeto com este nome já existe. Por favor, volte e entre um nome diferente."));
            });
        }

        [Test]
        [Description("Realizar alteração do nome do projeto")]
        public void AlterarNomeProjeto()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Edita Projeto";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("1", ProjetoDBSteps.RetornaQdteProjetoCadastrado(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo estado para Desenvolvimento")]
        public void AlterarStatusDesenvolvimento()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string status = "desenvolvimento";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherStatusProjeto(status);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("10", ProjetoDBSteps.RetornaStatusProjeto(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo estado para Release")]
        public void AlterarStatusRelease()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string status = "release";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherStatusProjeto(status);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("30", ProjetoDBSteps.RetornaStatusProjeto(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo estado para Estavel")]
        public void AlterarStatusEstavel()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string status = "estável";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherStatusProjeto(status);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("50", ProjetoDBSteps.RetornaStatusProjeto(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo estado para Obsoleto")]
        public void AlterarStatusObsoleto()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string status = "obsoleto";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherStatusProjeto(status);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("70", ProjetoDBSteps.RetornaStatusProjeto(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo habilitado")]
        public void AlterarHabilitado()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.ClicarHabilitado();
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("0", ProjetoDBSteps.RetornaHabilitado(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo herdar categorias globais")]
        public void AlterarHedarCategoriasGlobais()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.ClicarHerdarCategoriasGlobais();
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("1", ProjetoDBSteps.RetornaHerdarCategoriasGlobais(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo visibilidade Público")]
        public void AlterarVisibilidadePublico()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string visibilidade = "público";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherVisibilidade(visibilidade);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("10", ProjetoDBSteps.RetornaVisibilidade(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo visibilidade Privado")]
        public void AlterarVisibilidadePrivado()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string visibilidade = "privado";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherVisibilidade(visibilidade);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual("50", ProjetoDBSteps.RetornaVisibilidade(nomeProjeto));
        }

        [Test]
        [Description("Realizar alteração do campo Descrição")]
        public void AlterarDescricao()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            string descricao = "teste de edição para o menu de cadastro do projeto";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.PreencherDescricao(descricao);
            gerenciarProjetoPage.ClicarBotaoAtualizarProjeto(); ;

            Assert.AreEqual(descricao, ProjetoDBSteps.RetornaDescricao(nomeProjeto));
        }

        [Test]
        [Description("Realizar o delete do projeto")]
        public void ApagarProjeto()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeProjeto = "Projeto Trabalho Mantis Edição";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovoProjeto();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarColunaGridNomeProjeto();
            gerenciarProjetoPage.ClicarBotaoApagarProjeto();
            gerenciarProjetoPage.ClicarBotaoApagarProjeto();

            Assert.AreEqual("0", ProjetoDBSteps.RetornaQdteProjetoCadastrado(nomeProjeto));
        }

        #endregion

        #region Categoria

        [Test]
        [Description("Realizar o cadastro de uma categoria")]
        public void RealizarCadastroCategoria()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeCategoria = "Similar";
            #endregion

            ProjetoDBSteps.DeletarCategoriaCadastrado(nomeCategoria);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.PreencherCategoria(nomeCategoria);
            gerenciarProjetoPage.ClicarBotaoAdicionarCategoria();

            Assert.AreEqual("1", ProjetoDBSteps.RetornaQtdeCategoria(nomeCategoria));
        }

        [Test]
        [Description("Alterar uma categoria")]
        public void AlterarCategoria()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeCategoria = "Automação";
            string nomeCategoriaEditar = "Manual";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovaCategoria();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarBotaoAlterarCategoria(nomeCategoria);
            gerenciarProjetoPage.PreencherCategoriaEditar(nomeCategoriaEditar);
            gerenciarProjetoPage.ClicarBotaoAtualizarCategoria();

             Assert.AreEqual("1", ProjetoDBSteps.RetornaQtdeCategoria(nomeCategoriaEditar));
        }

        [Test]
        [Description("Validar campo categoria obrigatória")]
        public void ValidarCampoCategoriaObrigatoria()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarBotaoAdicionarCategoria();

            Assert.True(gerenciarProjetoPage.RetornarMsgErro().Contains("Um campo necessário 'Categoria' estava vazio. Por favor, verifique novamente suas entradas."));

        }

        [Test]
        [Description("Realizar o cadastro e edição da categoria")]
        public void RealizarCadastroEdicaoCategoria()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeCategoria = "Desempenho";
            string atribuido = "administrator";
            #endregion

            ProjetoDBSteps.DeletarCategoriaCadastrado(nomeCategoria);
            loginFlows.RealizarLoginSucesso(usuario, senha);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.PreencherCategoria(nomeCategoria);
            gerenciarProjetoPage.ClicarBotaoAdicionarEditarCategoria();
            gerenciarProjetoPage.PreencherAtribuidoCategoriaEditar(atribuido);
            gerenciarProjetoPage.ClicarBotaoAtualizarCategoria();

            Assert.AreEqual("1", ProjetoDBSteps.RetornaQtdeCategoriaAtribuido(nomeCategoria, "1"));
        }


        [Test]
        [Description("Apagar uma categoria")]
        public void ApagarCategoria()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeCategoria = "Automação";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovaCategoria();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarBotaoApagarCategoria(nomeCategoria);
            gerenciarProjetoPage.ClicarBotaoApagarCategoriaConfirmacao();

            Assert.AreEqual("0", ProjetoDBSteps.RetornaQtdeCategoria(nomeCategoria));
        }

        [Test]
        [Description("Realizar o cadastro de uma categoria já existente")]
        public void RealizarCadastroCategoriaExistente()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            projetoFlows = new ProjetoFlows();

            #region parameters
            string nomeCategoria = "Automação";
            #endregion

            loginFlows.RealizarLoginSucesso(usuario, senha);
            projetoFlows.CadastrarNovaCategoria();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.PreencherCategoria(nomeCategoria);
            gerenciarProjetoPage.ClicarBotaoAdicionarCategoria();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("1", ProjetoDBSteps.RetornaQtdeCategoria(nomeCategoria));
                Assert.True(gerenciarProjetoPage.RetornarMsgErro().Contains("Uma categoria com este nome já existe."));
            });
        }
        #endregion
    }
}
