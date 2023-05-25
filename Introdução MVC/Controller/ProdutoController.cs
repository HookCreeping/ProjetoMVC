using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Introdução_MVC.Model;
using Introdução_MVC.View;

namespace Introdução_MVC.Controller
{
    public class ProdutoController
    {
        // instância das classes Produto e ProdutoView
        Produto produto = new Produto();
        ProdutoView produtoView = new ProdutoView();

        // método controlador para acessar a listagem de produtos
        public ProdutoController()
        {

        }
        public void ListarProdutos()
        {
            List<Produto> produtos = produto.Ler();

            produtoView.Listar(produtos);
        }

        public void Cadastrar()
        {
            produtoView.Cadastrar();
        }
    }
}