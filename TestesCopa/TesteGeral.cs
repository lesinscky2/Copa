using Copa.Domain.Interfaces.Repositories;
using Copa.Domain.Interfaces.Services;
using Copa.Domain.Services.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace TestesCopa
{
    public class TesteGeral
    {
        private IEquipeService _equipeService;
        private IEquipeRepository _equipeRepository;

        [SetUp]
        public void Setup()
        {
            var config = new Mock<IConfiguration>().Object;
            _equipeRepository = new Mock<IEquipeRepository>().Object;
            _equipeService = new EquipeService(config, _equipeRepository);
        }

        [Test]
        public void TesteFinais()
        {
            var todasEquipes = _equipeService.BuscarEquipesPredefinidas();
            var final = _equipeService.OrganizarFinal(todasEquipes);

            Assert.That(final.First().Gols > final.Last().Gols);
            Assert.Pass();
        }
    }
}