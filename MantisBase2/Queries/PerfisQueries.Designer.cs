//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MantisBase2.Queries {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class PerfisQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PerfisQueries() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MantisBase2.Queries.PerfisQueries", typeof(PerfisQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a DELETE FROM mantis_user_profile_table WHERE platform=&apos;$plataforma&apos;.
        /// </summary>
        internal static string DeletePerfil {
            get {
                return ResourceManager.GetString("DeletePerfil", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT description FROM mantis_user_profile_table WHERE platform=&apos;$plataforma&apos;.
        /// </summary>
        internal static string RetornaDescricaoAdicional {
            get {
                return ResourceManager.GetString("RetornaDescricaoAdicional", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT count(*) FROM mantis_user_profile_table WHERE platform=&apos;$plataforma&apos;.
        /// </summary>
        internal static string RetornaPlataforma {
            get {
                return ResourceManager.GetString("RetornaPlataforma", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT count(*) FROM mantis_user_profile_table WHERE platform=&apos;$plataforma&apos; AND os=&apos;$so&apos; AND os_build=&apos;$versao&apos; AND description=&apos;$descricao&apos;.
        /// </summary>
        internal static string RetornaQtdePerfil {
            get {
                return ResourceManager.GetString("RetornaQtdePerfil", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT os FROM mantis_user_profile_table WHERE platform=&apos;$plataforma&apos;.
        /// </summary>
        internal static string RetornaSO {
            get {
                return ResourceManager.GetString("RetornaSO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT os_build FROM mantis_user_profile_table WHERE platform=&apos;$plataforma&apos;.
        /// </summary>
        internal static string RetornaVersaoSO {
            get {
                return ResourceManager.GetString("RetornaVersaoSO", resourceCulture);
            }
        }
    }
}
