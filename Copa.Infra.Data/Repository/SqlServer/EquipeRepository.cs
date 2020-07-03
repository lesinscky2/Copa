using Copa.Domain.Entities;
using Copa.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Copa.Infra.Data.Repository.SqlServer
{
    public class EquipeRepository : RepositoryBase<Equipe>, IEquipeRepository
    {
        public void EditEquipe(Equipe equipe)
        {

        }

        public List<Equipe> GetEquipes()
        {
            return colecao.FindAll().ToList();
        }

        public void RemoveEquipes()
        {
            colecao.DeleteAll();
        }

        public void SaveEquipes(List<Equipe> equipes)
        {
            colecao.InsertBulk(equipes);
        }
    }
}