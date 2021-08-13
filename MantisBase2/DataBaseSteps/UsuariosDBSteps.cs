using MantisBase2.Queries;
using MantisBase2.Helpers;
//using MantisBase2.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.DataBaseSteps
{
    public class UsuariosDBSteps 
    {
                
        public static string RetornaUsuarioSenhaLogin(string username)
        {
            string query = UsuariosQueries.RetornaSenha.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaNomeVerdadeiroUsuario(string username)
        {
            string query = UsuariosQueries.RetornaNomeVerdadeiroUsuarioCadastrado.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaEmailUsuario(string username)
        {
            string query = UsuariosQueries.RetornaEmailUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaNomeUsuario(string username)
        {
            string query = UsuariosQueries.RetornaNomeUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static void DeletarUsuarioEditado(string username)
        {
            string query = UsuariosQueries.DeletaUsuario.Replace("$username", username);
            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornaNivelAcesso(string username)
        {
            string query = UsuariosQueries.RetornaNivelAcesso.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaCountUsusario(string username)
        {
            string query = UsuariosQueries.RetornaCountUsuarios.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string VerificaUsuarioCadastrado(string username, string nameTrue, string email, string acesso, string habilitado, string protegido)
        {
            string query = UsuariosQueries.RetornaUsuarioCadastrado.Replace("$username", username).Replace("$nameTrue", nameTrue).Replace("$email", email).Replace("$acesso", acesso).Replace("$habilitado", habilitado).Replace("$protegido", protegido);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaHabilitado(string username)
        {
            string query = UsuariosQueries.RetornaHabilitadoUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaProtegido(string username)
        {
            string query = UsuariosQueries.RetornaProtegidoUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
    }
}
