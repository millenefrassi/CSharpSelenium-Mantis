using MantisBase2.DataBaseSteps;
using MantisBase2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Flows
{
    public class ProjetoFlows
    {
        #region Page Object and Constructor
        GerenciarProjetoPage gerenciarProjetoPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;

        public ProjetoFlows()
        {
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
        }
        #endregion
        public string nomeProjeto = "Projeto Trabalho Mantis Edição";
        public string status = "estável";
        public string visibilidade = "público";
        public string descricao = "Teste para automação edição";
        public string nomeProjetoEdicaoTeste = "Edita Projeto";
        public string nomeProjetoCadastro = "Projeto Trabalho Mantis";
        public string nomeCategoria = "Automação";
        public string nomeCategoriaEditar = "Manual";


        public void CadastrarNovoProjeto()
        {
            ProjetoDBSteps.DeletarProjetoCadastrado(nomeProjeto);
            ProjetoDBSteps.DeletarProjetoCadastrado(nomeProjetoEdicaoTeste);
            ProjetoDBSteps.DeletarProjetoCadastrado(nomeProjetoCadastro);

            homeBarraSuperiorPage.ClicarMenuGerenciar();
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.ClicarBotaoCriarProjeto();
            gerenciarProjetoPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetoPage.PreencherStatusProjeto(status);
            gerenciarProjetoPage.ClicarHerdarCategoriasGlobais();
            gerenciarProjetoPage.PreencherVisibilidade(visibilidade);
            gerenciarProjetoPage.PreencherDescricao(descricao);
            gerenciarProjetoPage.ClicarBotaoAdicionarProjeto(); 
        }

        public void CadastrarNovaCategoria()
        {            
            gerenciarProjetoPage = new GerenciarProjetoPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            ProjetoDBSteps.DeletarCategoriaCadastrado(nomeCategoria);
            ProjetoDBSteps.DeletarCategoriaCadastrado(nomeCategoriaEditar);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarProjetoPage.ClicarAbaGerenciarProjeto();
            gerenciarProjetoPage.PreencherCategoria(nomeCategoria);
            gerenciarProjetoPage.ClicarBotaoAdicionarCategoria();
        }
    }
}
