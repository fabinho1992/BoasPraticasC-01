﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "show",
        documentacao: " adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show
    {
        public void MostrarArquivo(string caminhoDoArquivo)
        {
            var lista = new LerArquivo();
            lista.MostrarPets(caminhoDoArquivo);
        }
    }
}
