using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_CadastroDeEventos.Model
{
    public class EventosModel
    {
        // propriedades
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Data { get; set; }
        public string? Codigo { get; set; }

        List<EventosModel> eventos = new List<EventosModel>();

        // caminho da pasta
        private const string PATH = "Database/Eventos.csv";
        public EventosModel()
        {
            string pasta = PATH.Split("/")[0];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        // métodos
        public List<EventosModel> LerArquivo() // $
        {
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas) // $
            {
                string[] atributos = item.Split(";");

                EventosModel ev = new EventosModel();

                ev.Nome = atributos[0];
                ev.Descricao = atributos[1];
                ev.Data = atributos[2];
                ev.Codigo = atributos[3];

                eventos.Add(ev);
            }

            return (eventos);
        }
        public string PrepararProCSV(EventosModel ev) // $
        {
            return $"{ev.Nome};{ev.Descricao};{ev.Data};{ev.Codigo}";
        }
        public void SalvarNoCSV(EventosModel ev) // $
        {
            string[] linhas = { PrepararProCSV(ev) };

            File.AppendAllLines(PATH, linhas);
        }

        public List<EventosModel> DeletarDoCSV(string codigo)
        {
            string[] linhas = File.ReadAllLines(PATH);

            EventosModel removido = eventos.Find(x => x.Codigo == codigo)!;

            eventos.Remove(removido);

            return (eventos);
        }
    }
}
