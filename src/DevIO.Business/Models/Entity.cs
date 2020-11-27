using System;

namespace DevIO.Business.Models
{

    // essa classe será herdada pelas classes: endereco, fornecedor, produto...
    // todos que herdarem dela já implementam por 'natureza' um ID
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
