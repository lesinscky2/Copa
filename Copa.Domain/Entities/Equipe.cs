using System;

namespace Copa.Domain.Entities
{
    public class Equipe
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public short Gols { get; set; }
    }
}
