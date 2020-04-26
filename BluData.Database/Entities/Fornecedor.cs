using BluData.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluData.Database.Entities
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}