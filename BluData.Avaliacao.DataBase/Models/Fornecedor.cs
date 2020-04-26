using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluData.Avaliacao.Database.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public string Rg { get; set; }

        public DateTime? DataNascimento { get; set; }

        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}