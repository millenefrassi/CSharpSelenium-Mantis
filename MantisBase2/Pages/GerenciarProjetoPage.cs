using MantisBase2.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Pages
{
    public class GerenciarProjetoPage : PageBase
    {
        By abaGerenciarProjeto = By.XPath("//a[@href='/manage_proj_page.php']");
        By botaoCriarProjeto = By.XPath("//button[@class='btn btn-primary btn-white btn-round']");
        By nomeProjeto = By.Id("project-name");
        By statusProjeto = By.Id("project-status");
        By herdarCategoraisGlobais = By.XPath("//label//input[@name='inherit_global']//following-sibling::span[@class='lbl']");
        By habilitado = By.XPath("//label//input[@name='enabled']//following-sibling::span[@class='lbl']");
        By visibilidade = By.Name("view_state");
        By descricao = By.Name("description");
        By botaoAdicionarProjeto = By.XPath("//input[@value='Adicionar projeto']");
        By botaoApagarProjeto = By.XPath("//input[@value='Apagar Projeto']");
        By botaoAtualizarProjeto = By.XPath("//input[@value='Atualizar Projeto']");
        By msgSucesso = By.XPath("//div[@class='alert alert-success center']");
        By msgErro = By.XPath("//div[@class='alert alert-danger']/p[2]");
        By colunaGridNomeProjeto = By.XPath("//a[contains(@href,'manage_proj_edit_page.php')]");
        By categoria = By.XPath("//input[@class='input-sm']");
        By botaoAdicionarCategoria = By.XPath("//input[@value='Adicionar Categoria']");
        By botaoAdicionarEditarCategoria = By.XPath("//input[@value='Adicionar e editar Categoria']");
        By categoriaEditar = By.Id("proj-category-name");
        By atribuidoCategoriaEditar = By.Id("proj-category-assigned-to");
        By botaoAtualizarCategoria = By.XPath("//input[@value='Atualizar Categoria']");
        By botaoApagarCategoriaConfirmacao = By.XPath("//input[@value='Apagar Categoria']");

        public By botaoAlterar(string textCategoria)//dinâmico, pegar qualquer texto
        {
            return By.XPath($"//td[text()='{textCategoria}']/following-sibling::td[2]//button[text()='Alterar']");
        }

        public void ClicarBotaoAlterarCategoria(string categoria)//dinâmico, pegar qualquer texto
        {
            Click(botaoAlterar(categoria));
        }

        public By botaoApagar(string textCategoria)//dinâmico, pegar qualquer texto
        {
            return By.XPath($"//td[text()='{textCategoria}']/following-sibling::td[2]//button[text()='Apagar']");
        }

        public void ClicarBotaoApagarCategoria(string categoria)//dinâmico, pegar qualquer texto
        {
            Click(botaoApagar(categoria));
        }

        public void ClicarAbaGerenciarProjeto()
        {
            Click(abaGerenciarProjeto);
        }

        public void ClicarBotaoCriarProjeto()
        {
            Click(botaoCriarProjeto);
        }

        public void PreencherNomeProjeto(string nameProject)
        {
            ClearAndSendKeys(nomeProjeto, nameProject);
        }

        public void PreencherStatusProjeto(string status)
        {
            ComboBoxSelectByVisibleText(statusProjeto, status); 
        }

        public void ClicarHerdarCategoriasGlobais()
        {
            Click(herdarCategoraisGlobais);
        }

        public void ClicarHabilitado()
        {
            Click(habilitado);
        }


        public void PreencherVisibilidade(string visivel)
        {
            ComboBoxSelectByVisibleText(visibilidade, visivel);
        }

        public void PreencherDescricao(string textoDescricao)
        {
            ClearAndSendKeys(descricao, textoDescricao);
        }

        public void ClicarBotaoAdicionarProjeto()
        {
            Click(botaoAdicionarProjeto);
        }

        public void ClicarBotaoApagarProjeto()
        {
            Click(botaoApagarProjeto);
        }

        public void ClicarBotaoAtualizarProjeto()
        {
            Click(botaoAtualizarProjeto);
        }

        public string RetornarMsgSucesso()
        {
            return GetText(msgSucesso);
        }

        public string RetornarMsgErro()
        {
            return GetText(msgErro);
        }

        public void ClicarColunaGridNomeProjeto()
        {
            Click(colunaGridNomeProjeto);
        }

        public void PreencherCategoria(string textoCategoria)
        {
            ClearAndSendKeys(categoria, textoCategoria);
        }

        public void ClicarBotaoAdicionarCategoria()
        {
            Click(botaoAdicionarCategoria);
        }

        public void ClicarBotaoAdicionarEditarCategoria()
        {
            Click(botaoAdicionarEditarCategoria);
        }

        public void PreencherAtribuidoCategoriaEditar(string atribuido)
        {
            ComboBoxSelectByVisibleText(atribuidoCategoriaEditar, atribuido);
        }

        public void PreencherCategoriaEditar(string categoria)
        {
            ClearAndSendKeys(categoriaEditar, categoria);
        }

        public void ClicarBotaoAtualizarCategoria()
        {
            Click(botaoAtualizarCategoria);
        }

        public void ClicarBotaoApagarCategoriaConfirmacao()
        {
            Click(botaoApagarCategoriaConfirmacao);
        }
    }
}
