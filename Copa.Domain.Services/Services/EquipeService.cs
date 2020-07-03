using Copa.Domain.Entities;
using Copa.Domain.Interfaces.Repositories;
using Copa.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace Copa.Domain.Services.Services
{
    public class EquipeService : IEquipeService
    {
        private readonly IConfiguration _config;
        private readonly IEquipeRepository _equipeRepository;

        public EquipeService(IConfiguration config, IEquipeRepository equipeRepository)
        {
            _config = config;
            _equipeRepository = equipeRepository;
        }

        public List<Equipe> BuscarEquipesPredefinidas()
        {
            var urlApi = _config.GetSection("urlApiEquipes")?.Value;

            //gato pra funcionar com o teste, infelizmente :(
            if (string.IsNullOrEmpty(urlApi))
            {
                urlApi = "https://raw.githubusercontent.com/delsonvictor/testetecnico/master/";
            }

            var url = $"{urlApi}equipes.json";

            var client = new HttpClient();
            var resultado = client.GetAsync(url).Result;
            var json = resultado.Content.ReadAsStringAsync().Result;

            var equipes = JsonConvert.DeserializeObject<List<Equipe>>(json);

            return equipes;
        }

        public List<Equipe> DedicirQuemVenceConfronto(List<Equipe> equipes)
        {
            var equipe1 = equipes[0];
            var equipe2 = equipes[1];

            ValidarEquipesComMesmoNome(equipe1, equipe2);

            if(equipe1.Gols != equipe2.Gols)
            {
                return equipes.OrderByDescending(x => x.Gols).ToList();
            }

            equipes = equipes.OrderByDescending(x => x.Nome).ToList();
            
            if(equipe1.Nome.Length > equipe2.Nome.Length)
            {
                equipes = equipes.OrderBy(x => x.Nome).ToList();
            }

            return equipes;
        }

        private static void ValidarEquipesComMesmoNome(Equipe equipe1, Equipe equipe2)
        {
            if (equipe1.Nome == equipe2.Nome)
            {
                throw new Exception("Não pode existir equipes com o mesmo nome.");
            }
        }

        public void EditarEquipe(Equipe equipe)
        {
            _equipeRepository.EditEquipe(equipe);
        }

        public List<Equipe> OrganizarFinal(List<Equipe> equipes)
        {
            _equipeRepository.RemoveEquipes();
            equipes = OrganizarSemifinal(equipes);

            return DedicirQuemVenceConfronto(equipes);
        }

        public List<Equipe> OrganizarSemifinal(List<Equipe> equipes)
        {
            equipes = equipes.OrderBy(x => x.Nome).ToList();

            var semifinal1 = new List<Equipe>(2);
            var semifinal2 = new List<Equipe>(2);

            semifinal1.Add(DedicirQuemVenceConfronto(new List<Equipe> { equipes[0], equipes[7] }).First());
            semifinal1.Add(DedicirQuemVenceConfronto(new List<Equipe> { equipes[1], equipes[6] }).First());

            semifinal2.Add(DedicirQuemVenceConfronto(new List<Equipe> { equipes[2], equipes[5] }).First());
            semifinal2.Add(DedicirQuemVenceConfronto(new List<Equipe> { equipes[3], equipes[4] }).First());

            var finalistas = new List<Equipe>();
            finalistas.Add(DedicirQuemVenceConfronto(semifinal1).First());
            finalistas.Add(DedicirQuemVenceConfronto(semifinal2).First());

            return finalistas;
        }

        public void SalvarEquipes(List<Equipe> equipes)
        {
            _equipeRepository.SaveEquipes(equipes);
        }
    }
}
