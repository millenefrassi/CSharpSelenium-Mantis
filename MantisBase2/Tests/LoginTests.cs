using MantisBase2.Bases;
using MantisBase2.DataBaseSteps;
using MantisBase2.Helpers;
using MantisBase2.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MantisBase2.Tests
{
   
    public class LoginTests : TestBase
    {
        #region Pages and Flows Objects
        LoginPage loginPage;
        HomeBarraSuperiorPage homeBarraSuperiorPage;
        
        #endregion

        #region Data Driven Providers
        public static IEnumerable LoginUsuarioInvalidoTestDataIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Login/LoginUsuarioInvalidoTestData.csv");
        }
        #endregion

        [Test]
        [Description("Realizar login com sucesso")]
        public void RealizarLoginComSucesso()
        {
            loginPage = new LoginPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();
            
            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string labelTitulo = "MantisBT";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarBotaoEntrar();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarBotaoEntrar();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(usuario, homeBarraSuperiorPage.RetornarUsuarioLogado());
                Assert.AreEqual(labelTitulo, homeBarraSuperiorPage.RetornarLabelTitulo());
            });
        }

        [Test]
        [Description("Realizar login com usuário correto e senha incorreta")]
        public void RealizarLoginUsuarioCorretoSenhaIncorreta()
        {
            loginPage = new LoginPage();
            
            #region Parameters
            string usuario = "administrator";
            string senha = "incorreto";
            string msgErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarBotaoEntrar();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarBotaoEntrar();
                            
            Assert.AreEqual(msgErro, loginPage.RetornarMsgErro());
            
        }

        [Test]
        [Description("Realizar login com usuário incorreto e senha correta")]
        public void RealizarLoginUsuarioInCorretoSenhaCorreta()
        {
            loginPage = new LoginPage();

            #region Parameters
            string usuario = "incorreto";
            string senha = "administrator";
            string msgErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarBotaoEntrar();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarBotaoEntrar();

            Assert.AreEqual(msgErro, loginPage.RetornarMsgErro());

        }

        [Test, TestCaseSource("LoginUsuarioInvalidoTestDataIProvider")]
        [Description("Realizar login com vários usuários inválidos extraídos no TestData - DataDriven")]
        public void RealizarLoginUsuarioInvalido(ArrayList testData)
        {
            loginPage = new LoginPage();
            
            #region Parameters
            string usuario = testData[0].ToString();
            string senha = testData[1].ToString();
            string msgErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarBotaoEntrar();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarBotaoEntrar();

            Assert.AreEqual(msgErro, loginPage.RetornarMsgErro());

        }

        [Test]
        [Description("Realizar login com sucesso e comparar a senha entrada com a senha cadastrada no banco")]
        public void CompararSenhaEntradaComSenhaCadastradaViaBanco()
        {
            loginPage = new LoginPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region Parameters
            string usuario = "administrator";
            string senhaEntrada = "administrator";
            string senhaMD5 = GeneralHelpers.GerarHashMd5(senhaEntrada);
            string senha = UsuariosDBSteps.RetornaUsuarioSenhaLogin(usuario);
            string labelTitulo = "MantisBT";
            #endregion        
   
            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarBotaoEntrar();
            loginPage.PreencherSenha(senhaEntrada);
            loginPage.ClicarBotaoEntrar();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(usuario, homeBarraSuperiorPage.RetornarUsuarioLogado());
                Assert.AreEqual(labelTitulo, homeBarraSuperiorPage.RetornarLabelTitulo());
                Assert.AreEqual(senha, senhaMD5);
            });
        }

        [Test]
        [Description("Realizar login com sucesso usando Javascript")]
        public void RealizarLoginSucessoJavaScript()
        {
            loginPage = new LoginPage();
            homeBarraSuperiorPage = new HomeBarraSuperiorPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            string labelTitulo = "MantisBT";
            #endregion

            loginPage.PreencherUsuarioJavaScript(usuario);
            loginPage.ClicarBotaoEntrarJavaScript();
            loginPage.PreencherSenhaJavaScript(senha);
            loginPage.ClicarBotaoEntrarJavaScript();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(usuario, homeBarraSuperiorPage.RetornarUsuarioLogado());
                Assert.AreEqual(labelTitulo, homeBarraSuperiorPage.RetornarLabelTitulo());
            });
        }

        [Test]
        [Description("Realizar login com usuário e senha incorreta usando JavaScript")]
        public void RealizarLoginUsuarioSenhaIncorretaJavaScript()
        {
            loginPage = new LoginPage();

            #region Parameters
            string usuario = "usuincorreto";
            string senha = "incorreto";
            string msgErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuarioJavaScript(usuario);
            loginPage.ClicarBotaoEntrarJavaScript();
            loginPage.PreencherSenhaJavaScript(senha);
            loginPage.ClicarBotaoEntrarJavaScript();

            Assert.AreEqual(msgErro, loginPage.RetornarMsgErro());

        }
    }
}
