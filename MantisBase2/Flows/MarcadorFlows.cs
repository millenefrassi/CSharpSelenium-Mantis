using MantisBase2.DataBaseSteps;
using MantisBase2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Flows
{
    public class MarcadorFlows
    {
        #region Page Object and Constructor
        GerenciarMarcadoresPage gerenciarMarcadoresPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;

        public MarcadorFlows()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
        }
        #endregion
        public string marcador = "Tag Editada";
        public string descricao = "Tag Descricao";
        public string marcadorEditada = "Tag Editada Manual";
        public string marcadorCriado = "Marcador teste";

        public void CadastrarNovoMarcador()
        {
            MarcadorDBSteps.DeletarMarcadorCadastrado(marcador);
            MarcadorDBSteps.DeletarMarcadorCadastrado(marcadorEditada);
            MarcadorDBSteps.DeletarMarcadorCadastrado(marcadorCriado);
            homeBarraSuperiorPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaGerenciarMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(marcador);
            gerenciarMarcadoresPage.PreencherDescricaoMarcador(descricao);
            gerenciarMarcadoresPage.ClicarBotaoCriarMarcador();
        }
    }
}
