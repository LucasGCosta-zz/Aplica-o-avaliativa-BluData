using Newtonsoft.Json;
using System.Collections.Generic;

namespace BluData.Avaliacao.Database.Models
{
    public class Empresa : Entity
    {
        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public string Uf { get; set; }

        [JsonIgnore]
        public virtual ICollection<Fornecedor> Fornecedores { get; set; }

    }
}
