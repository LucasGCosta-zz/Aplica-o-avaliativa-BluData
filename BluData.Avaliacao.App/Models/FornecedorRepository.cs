using BluData.Avaliacao.Database.DAL;
using BluData.Avaliacao.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluData.Avaliacao.App.Models
{
    public class FornecedorRepository : EntityRepository<Fornecedor>
    {
        public FornecedorRepository(BluDataContext context)
            : base(context)
        {
        }

        public override Fornecedor Find(int id)
        {
            return _context.Fornecedores
                            .Include(x => x.Telefones)
                            .FirstOrDefault(x => x.Id == id);
        }
        public override Fornecedor Insert(Fornecedor entity)
        {
            //Caso a empresa seja do Paraná, não permitir cadastrar um fornecedor pessoa física menor de idade;
            Empresa empresa = _context.Empresas.Find(entity.EmpresaId);

            if (empresa is null)
                throw new InvalidOperationException("Empresa obrigatória!");

            if (empresa.Uf.Equals("PR", StringComparison.InvariantCultureIgnoreCase) && !String.IsNullOrEmpty(entity.Rg))
            {
                if(!entity.DataNascimento.HasValue)
                    throw new InvalidOperationException("Data de nascimento obrigatória!");
                //int age = DateTime.Today.Year - entity.DataNascimento.Value.Year; Essa versão pode trazer a idade errada, pois não considera os dias do ano

                int age = DateTime.Today.Subtract(entity.DataNascimento.Value).Days / 365;

                if (age < 18)
                    throw new InvalidOperationException("Fornecedor não pode ser menor de idade no estado do Paraná!");
            }

            return base.Insert(entity);
        }
    }
}