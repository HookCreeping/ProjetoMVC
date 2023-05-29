using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_CadastroDeEventos.Model;
using _1_CadastroDeEventos.Controller;

namespace _1_CadastroDeEventos.View
{
    public class EventosView
    {
        // propriedades e instâncias
        EventosModel model = new EventosModel();

        // métodos
        public EventosModel Cadastrar() // $
        {
            EventosModel eventos = new EventosModel();

            Console.WriteLine($"Nome do evento: ");
            eventos.Nome = Console.ReadLine()!;

            Console.WriteLine($"Descrição do evento: ");
            eventos.Descricao = Console.ReadLine()!;

            Console.WriteLine($"Data do evento: ");
            eventos.Data = Console.ReadLine()!;

            Console.WriteLine($"Código do evento: ");
            eventos.Codigo = Console.ReadLine()!; ;


            EventosModel ev = new EventosModel();

            ev.SalvarNoCSV(eventos);

            return ev;
        }
        public void Listar(List<EventosModel> eventos) // $
        {
            foreach (var item in eventos)
            {
                Console.WriteLine(@$"
----------
Código:{item.Codigo}

Nome: {item.Nome}
Descrição: {item.Descricao}
Data: {item.Data}

");

            }
        }
        public EventosModel Deletar()
        {
            Console.WriteLine($"Insira o código do evento:");
            string codigo = Console.ReadLine()!;

            model.DeletarDoCSV(codigo);

            return Deletar();
        }

        public void MostrarMenu() // $
        {
            string resposta;
            EventosController controller = new EventosController();

            do
            {
                Console.WriteLine(@$"
    O que desejas fazer?
    
    [1] - Cadastrar novo Evento
    [2] - Listar eventos
    [3] - Deletar evento

    [0] - Sair
    ");

                resposta = Console.ReadLine()!;

                if (resposta == "1") // $
                {
                    Console.Beep(430, 1000);

                    controller.Cadastrar();
                }
                else if (resposta == "2") // $
                {
                    Console.Beep(430, 1000);

                    controller.Listar();
                }
                else if (resposta == "3") // $
                {
                    Console.Beep(430, 1000);

                    controller.Deletar();
                }
                else // $
                {
                    Console.Beep(430, 1000);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Caractér inválido!");
                    Console.ResetColor();

                    Thread.Sleep(3000);
                }

            } while (resposta == "0");
        }
    }
}