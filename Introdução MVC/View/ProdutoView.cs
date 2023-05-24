using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Introdução_MVC.Model;

namespace Introdução_MVC.View
{
    public class ProdutoView
    {
        // método para exibir os dados da lista no console
        public void Listar(List<Produto> produto)
        {
            foreach (var item in produto)
            {
                Console.WriteLine($"\nCódigo: {item.Codigo}");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Text {item.Preco:C}");
            }
        }
    }
}