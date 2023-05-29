using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Equipe
    {
        // propriedades
        [Key]
        public int IdEquipe { get; set; }
        public string? Nome { get; set; }
        public string? Imagem { get; set; }
        public ICollection<Jogador>? _Jogador { get; set; }
    }
}