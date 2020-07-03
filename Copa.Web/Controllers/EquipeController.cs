using Copa.Domain.Entities;
using Copa.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Copa.Web.Controllers
{
    public class EquipeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IEquipeService _equipeService;

        public EquipeController(IConfiguration config, IEquipeService equipeService)
        {
            _config = config;
            _equipeService = equipeService;
        }

        // GET: EquipeController
        public IActionResult Index()
        {
            var equipes = _equipeService.BuscarEquipesPredefinidas();


            return View(equipes);
        }

        // POST: EquipeController/GerarCopa
        [HttpPost]
        public List<Equipe> GerarCopa(string equipes)
        {
            var equipesDominio = JsonConvert.DeserializeObject<List<Equipe>>(equipes);

            var resultado = _equipeService.OrganizarFinal(equipesDominio);

            return resultado;
        }

        // GET: EquipeController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }



    }
}