using MantisBase2.Helpers;
using MantisBase2.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.DataBaseSteps
{
    public class MarcadorDBSteps
    {
        public static string RetornaQtdeMarcador(string nomeMarcador, string descricaoMarcador)
        {
            string query = MarcadorQueries.RetornaQtdeMarcador.Replace("$name", nomeMarcador).Replace("$description", descricaoMarcador);
            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static void DeletarMarcadorCadastrado(string nomeMarcador)
        {
            string query = MarcadorQueries.DeleteMarcador.Replace("$name", nomeMarcador);
            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornaNomeMarcador(string nomeMarcador)
        {
            string query = MarcadorQueries.RetornaNomeMarcador.Replace("$name", nomeMarcador);
            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaDescricaoMarcador(string nomeMarcador)
        {
            string query = MarcadorQueries.RetornaDescricaoMarcador.Replace("$name", nomeMarcador);
            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaMarcadorDeletado(string nomeMarcador)
        {
            string query = MarcadorQueries.RetornaMarcadorDeletado.Replace("$name", nomeMarcador);
            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaCriadorMarcador(string nameCriador)
        {
            string query = MarcadorQueries.RetornaCriadorMarcador.Replace("$name", nameCriador);
            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
    }
}
