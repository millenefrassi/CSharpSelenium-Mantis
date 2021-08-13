using MantisBase2.Helpers;
using MantisBase2.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.DataBaseSteps
{
    public class PerfisDBSteps
    {
        public static string RetornaQtdePerfil(string nomePlataforma, string nomeSO, string versaoSO, string descricaoAdicional)
        {
            string query = PerfisQueries.RetornaQtdePerfil.Replace("$plataforma", nomePlataforma).Replace("$so", nomeSO).Replace("$versao", versaoSO).Replace("$descricao", descricaoAdicional);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static void DeletarPerfilCadastrado(string nomePlataforma)
        {
            string query = PerfisQueries.DeletePerfil.Replace("$plataforma", nomePlataforma);
            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornaPlataforma(string nomePlataforma)
        {
            string query = PerfisQueries.RetornaPlataforma.Replace("$plataforma", nomePlataforma);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
        public static string RetornaSO(string nomePlataforma)
        {
            string query = PerfisQueries.RetornaSO.Replace("$plataforma", nomePlataforma);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaVersaoSO(string nomePlataforma)
        {
            string query = PerfisQueries.RetornaVersaoSO.Replace("$plataforma", nomePlataforma);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaDescricaoAdicional(string nomePlataforma)
        {
            string query = PerfisQueries.RetornaDescricaoAdicional.Replace("$plataforma", nomePlataforma);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
    }
}
