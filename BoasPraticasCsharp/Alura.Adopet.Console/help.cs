using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao:"help", 
        documentacao:"adopet help <parametro> ous simplemente adopet help  " +
                     "comando que exibe informações de ajuda dos comandos." )]
    internal class Help
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.GetCustomAttributes<DocComando>().Any())
                    .Select(t => t.GetCustomAttribute<DocComando>()!)
                    .ToDictionary(d => d.Instrucao);
        }

        public void HelpProjeto()
        {
            System.Console.WriteLine("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            
                System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine("Comando possíveis: ");
            //    System.Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
            //    System.Console.WriteLine($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
            //    System.Console.WriteLine(" adopet list  comando que " +
            //        "exibe no terminal o conteúdo da base de dados da AdoPet.");
            //System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");

            foreach (var item in docs.Values)
            {
                System.Console.WriteLine(item.Documentacao);
            }

        }
        // exibe o help daquele comando específico
        public void HelpDoComando(string comando)
        {
            
            if (docs.ContainsKey(comando))
            {
                var exibir = docs[comando];
                System.Console.WriteLine(exibir.Documentacao);
            }

            //if (comando.Equals("import"))
            //{
            //    System.Console.WriteLine(" adopet import <arquivo> " +
            //        "comando que realiza a importação do arquivo de pets.");
            //}
            //if (comando.Equals("show"))
            //{
            //    System.Console.WriteLine(" adopet show <arquivo>  comando que " +
            //        "exibe no terminal o conteúdo do arquivo importado.");
            //}
            //if (comando.Equals("list"))
            //{
            //    System.Console.WriteLine(" adopet list  comando que " +
            //        "exibe no terminal o conteúdo da base de dados da AdoPet.");
            //}
        }
        
    }
}
