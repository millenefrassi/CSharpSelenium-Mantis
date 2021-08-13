using MantisBase2.DataBaseSteps;
using MantisBase2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Flows
{
    public class UsuarioFlows
    {

        #region Page Object and Constructor
        GerenciarUsuariosPage gerenciarUsuarioPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;

        public UsuarioFlows()
        {
            gerenciarUsuarioPage = new GerenciarUsuariosPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
        }
        #endregion

        public string nomeUsuario = "usuarioEdicao";
        public string nomeVerdadeiro = " Usuario Edicao Verdadeiro";
        public string email = "usuarioedicao@gmail.com";
        public string nivelAcesso = "relator";
        public string nomeUsuEdicaoTeste = "UsuEdicaoTeste";

        public void CadastrarNovoUsuario()
        {
            UsuariosDBSteps.DeletarUsuarioEditado(nomeUsuario);
            UsuariosDBSteps.DeletarUsuarioEditado(nomeUsuEdicaoTeste);

            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarUsuarioPage.ClicarAbaGerenciarUsuario();
            gerenciarUsuarioPage.ClicarBotaoCriarNovaConta();
            gerenciarUsuarioPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuarioPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuarioPage.PreencherEmailUsuario(email);
            gerenciarUsuarioPage.PreencherNivelAcesso(nivelAcesso);
            gerenciarUsuarioPage.ClicarBotaoCriarUsuario();
            gerenciarUsuarioPage.ClicarAbaGerenciarUsuario();
        }
    }
}
