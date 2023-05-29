using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_CadastroDeEventos.Model;
using _1_CadastroDeEventos.View;

namespace _1_CadastroDeEventos.Controller
{
    public class EventosController
    {
        // instâncias
        EventosModel eventos = new EventosModel();
        EventosView eventosView = new EventosView();

        // métodos
        public EventosController()
        {

        }
        public void Cadastrar()
        {
            eventosView.Cadastrar();
        }

        public void Listar()
        {
            List<EventosModel> lista = eventos.LerArquivo();

            eventosView.Listar(lista);
        }

        public void Deletar()
        {
            eventosView.Deletar();
        }
    }
}