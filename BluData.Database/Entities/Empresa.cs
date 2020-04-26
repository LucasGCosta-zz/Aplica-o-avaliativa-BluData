using System.Collections.Generic;

namespace BluData.Database.Entities
{
    public class Empresa : Entity
    {
        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public virtual ICollection<Fornecedor> Fornecedores { get; set; }

    }
}
