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
    internal class MarcadorQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MarcadorQueries() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MantisBase2.Queries.MarcadorQueries", typeof(MarcadorQueries).Assembly);
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
        ///   Consulta uma cadeia de caracteres localizada semelhante a DELETE FROM mantis_tag_table WHERE NAME=&apos;$name&apos; .
        /// </summary>
        internal static string DeleteMarcador {
            get {
                return ResourceManager.GetString("DeleteMarcador", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT u.username FROM mantis_tag_table t INNER JOIN mantis_user_table u ON t.user_id = u.id WHERE t.name=&apos;$name&apos;.
        /// </summary>
        internal static string RetornaCriadorMarcador {
            get {
                return ResourceManager.GetString("RetornaCriadorMarcador", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT description FROM mantis_tag_table WHERE NAME=&apos;$name&apos;.
        /// </summary>
        internal static string RetornaDescricaoMarcador {
            get {
                return ResourceManager.GetString("RetornaDescricaoMarcador", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT count(*) FROM mantis_tag_table WHERE NAME=&apos;$name&apos;.
        /// </summary>
        internal static string RetornaMarcadorDeletado {
            get {
                return ResourceManager.GetString("RetornaMarcadorDeletado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT name FROM mantis_tag_table WHERE NAME=&apos;$name&apos;.
        /// </summary>
        internal static string RetornaNomeMarcador {
            get {
                return ResourceManager.GetString("RetornaNomeMarcador", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COUNT(*) FROM mantis_tag_table WHERE NAME=&apos;$name&apos; and description=&apos;$description&apos;.
        /// </summary>
        internal static string RetornaQtdeMarcador {
            get {
                return ResourceManager.GetString("RetornaQtdeMarcador", resourceCulture);
            }
        }
    }
}
