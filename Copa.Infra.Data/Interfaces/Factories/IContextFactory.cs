using Copa.Infra.Data.Contexto;

namespace Copa.Infra.Data.Interfaces.Factories
{
    public interface IContextFactory
    {
        ContextoAplicacao GetSingleInstance();
    }
}