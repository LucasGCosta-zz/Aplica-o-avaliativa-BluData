using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluData.Avaliacao.Database.Models
{
    public class Telefone : Entity
    {
        public string Numero { get; set; }

        public int FornecedorId { get; set; }
        [JsonIgnore]
        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
