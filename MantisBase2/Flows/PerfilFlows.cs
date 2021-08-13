using MantisBase2.DataBaseSteps;
using MantisBase2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Flows
{
    public class PerfilFlows
    {
        #region Page Object and Constructor
        GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;

        public PerfilFlows()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
        }
        #endregion
        public string plataforma = "Edita Plataforma";
        public string so = "Linux";
        public string versaoSO = "8";
        public string descricaoAdicional = "Edita Descrição";
        public string plataformaEditada = "Edita Teste";

        public void CadastrarNovoPerfil()
        {
            PerfisDBSteps.DeletarPerfilCadastrado(plataforma);
            PerfisDBSteps.DeletarPerfilCadastrado(plataformaEditada);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.ClicarAbaGerenciarProjeto();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.PreencherSO(so);
            gerenciarPerfisGlobaisPage.PreencherVersaoSO(versaoSO);
            gerenciarPerfisGlobaisPage.PreencherDescricaoAdicional(descricaoAdicional);
            gerenciarPerfisGlobaisPage.ClicarBotaoAdicionarPerfil();
        }
    }
}
