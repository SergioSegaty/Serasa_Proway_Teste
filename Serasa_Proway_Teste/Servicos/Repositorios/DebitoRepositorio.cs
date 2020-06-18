using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Servicos.Interfaces;
using Servicos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicos.Repositorios
{
    public class DebitoRepositorio : IDebitoRepositorio
    {
        private readonly EmpresaRatingDbContext _context;

        public DebitoRepositorio(EmpresaRatingDbContext context)
        {
            _context = context;
        }

        public ICollection<Debito> ObterTodos()
        {
            return _context.Debitos.ToList();
        }

        public (string mensagem, bool sucesso) PostarDebito(Debito debito)
        {
            debito.Data = DateTime.Now;

            _context.Debitos.Add(debito);

            var empresa = _context.Empresas.Where(e => e.Id == debito.EmpresaId)
                .Include(e => e.Debitos)
                .SingleOrDefault();

            var resposta = empresa.AdicionarDebito();

            _context.Empresas.Update(empresa);

            _context.SaveChanges();

            debito.Empresa = empresa;

            return resposta;
        }
    }
}
