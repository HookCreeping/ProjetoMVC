using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infra
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = NOTE18-S15;  catalog = projetoGamer; Integrated Security = true; TrustServerCertificate = true");
            }
        }

        public DbSet<Jogador>? _Jogador { get; set; }
        public DbSet<Equipe>? _Equipe { get; set; }
    }
}