using MantisBase2.Helpers;
using MantisBase2.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.DataBaseSteps
{
    public class ProjetoDBSteps
    {
        public static string VerificaProjetoCadastrado(string nameProject, string statusProject, string categoria, string visivel, string textDescricao)
        {
            string query = ProjetoQueries.RetornaProjetoCadastrado.Replace("$nomeProjeto", nameProject).Replace("$status", statusProject).Replace("$headerCategoria", categoria).Replace("$visibilidade", visivel).Replace("$descricao", textDescricao);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static void DeletarProjetoCadastrado(string nameProject)
        {
            string query = ProjetoQueries.DeleteProjeto.Replace("$nomeProjeto", nameProject);
            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornaQdteProjetoCadastrado(string nameProject)
        {
            string query = ProjetoQueries.RetornaQdteProjetoCadastrado.Replace("$nomeProjeto", nameProject);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaStatusProjeto(string nameProject)
        {
            string query = ProjetoQueries.RetornaStatusProjeto.Replace("$nomeProjeto", nameProject);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaHabilitado(string nameProject)
        {
            string query = ProjetoQueries.RetornaHabilitado.Replace("$nomeProjeto", nameProject);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaHerdarCategoriasGlobais(string nameProject)
        {
            string query = ProjetoQueries.RetornaHerdarCategoriasGlobais.Replace("$nomeProjeto", nameProject);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaVisibilidade(string nameProject)
        {
            string query = ProjetoQueries.RetornaVisibilidade.Replace("$nomeProjeto", nameProject);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaDescricao(string nameProject)
        {
            string query = ProjetoQueries.RetornaDescricao.Replace("$nomeProjeto", nameProject);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaQtdeCategoria(string category)
        {
            string query = ProjetoQueries.RetornaQtdeCategoria.Replace("$categoria", category);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static void DeletarCategoriaCadastrado(string category)
        {
            string query = ProjetoQueries.DeleteCategoria.Replace("$categoria", category);
            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornaQtdeCategoriaAtribuido(string category, string atribuido)
        {
            string query = ProjetoQueries.RetornaQtdeCategoriaAtribuido.Replace("$categoria", category).Replace("$user", atribuido);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        
    }
}
