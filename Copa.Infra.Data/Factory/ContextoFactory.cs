using Copa.Infra.Data.Contexto;
using LiteDB;

namespace Copa.Infra.Data.Factory
{
    public class ContextoFactory
    {
        private static LiteDatabase _instancia;
        private static readonly object Padlock = new object();

        private static LiteDatabase Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new LiteDatabase(@"banco.db");
                    }
                    return _instancia;
                }
            }
        }

        public LiteDatabase GetSingleInstance()
        {
            return Instance;
        }
    }

    //public class ContextoFactory
    //{
    //    private static ContextoAplicacao _instancia;
    //    private static readonly object Padlock = new object();

    //    private static ContextoAplicacao Instance
    //    {
    //        get
    //        {
    //            lock (Padlock)
    //            {
    //                if (_instancia == null)
    //                {
    //                    _instancia = new ContextoAplicacao();
    //                }
    //                return _instancia;
    //            }
    //        }
    //    }

    //    public ContextoAplicacao GetSingleInstance()
    //    {
    //        return Instance;
    //    }
    //}
}