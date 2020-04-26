using System.ComponentModel.DataAnnotations.Schema;

namespace BluData.Database.Entities
{
    public class Telefone : Entity
    {
        public string Numero { get; set; }

        public int FornecedorId { get; set; }
        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
