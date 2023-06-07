using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GamerTarde.Infra;
using GamerTarde.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GamerTarde.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador!.ToList();
            ViewBag.Equipe = c.Equipe!.ToList();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();
            novoJogador.IdEquipe = int.Parse(form["IdEquipe"].ToString());

            c.Jogador!.Add(novoJogador);
            c.SaveChanges();
            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Jogador del = c.Jogador!.First(del => del.IdJogador == id);

            c.Remove(del);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            Jogador ed = c.Jogador!.First(x => x.IdJogador == id);

            ViewBag.Jogador = ed;
            ViewBag.Equipe = c.Equipe!.ToList();
            return View("/Views/Jogador/Edit.cshtml");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.IdJogador = int.Parse(form["IdJogador"].ToString());
            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();
            novoJogador.IdEquipe = int.Parse(form["IdEquipe"].ToString());

            Jogador jogadorBuscado = c.Jogador!.First(j => j.IdJogador == novoJogador.IdJogador);

            jogadorBuscado.Nome = novoJogador.Nome;
            jogadorBuscado.Email = novoJogador.Email;
            jogadorBuscado.Senha = novoJogador.Senha;
            jogadorBuscado.IdEquipe = novoJogador.IdEquipe;

            c.Jogador!.Update(jogadorBuscado);
            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        IActionResult Error()
        {
            return View("Error!");
        }
    }
}