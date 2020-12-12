using System;

namespace Dominio_FroFood.Models
{
    public abstract class ClasseBase
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizao { get; set; }
    }
}
