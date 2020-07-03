using Copa.Domain.Entities;
using System.Collections.Generic;

namespace Copa.Domain.Interfaces.Services
{
    public interface IEquipeService
    {
        List<Equipe> DedicirQuemVenceConfronto(List<Equipe> equipes);
        List<Equipe> OrganizarSemifinal(List<Equipe> equipes);

        List<Equipe> OrganizarFinal(List<Equipe> equipes);
        void EditarEquipe(Equipe equipe);
        void SalvarEquipes(List<Equipe> equipes);
        List<Equipe> BuscarEquipesPredefinidas();
    }
}