using Copa.Domain.Entities;
using System.Collections.Generic;

namespace Copa.Domain.Interfaces.Repositories
{
    public interface IEquipeRepository
    {
        List<Equipe> GetEquipes();
        void SaveEquipes(List<Equipe> equipes);
        void EditEquipe(Equipe equipe);
        void RemoveEquipes();
    }
}