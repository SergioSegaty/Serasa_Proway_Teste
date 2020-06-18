using Dominio.Modelos;
using Servicos.Interfaces;
using Servicos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicos.Repositorios
{
    public class NotaFiscalRepositorio : INotasFiscaisRepositorio
    {
        private readonly EmpresaRatingDbContext _context;

        public NotaFiscalRepositorio(EmpresaRatingDbContext context)
        {
            _context = context;
        }

        public ICollection<NotaFiscal> ObterTodos()
        {
            return _context.NotasFiscais.ToList();
        }

        public (string mensagem, bool sucesso) PostarNotaFiscal(NotaFiscal notaFiscal)
        {
            notaFiscal.Data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            _context.NotasFiscais.Add(notaFiscal);

            var empresa = _context.Empresas.Where(e => e.Id == notaFiscal.EmpresaId).SingleOrDefault();
           

            var resposta = empresa.AdicionarNotaFiscal();

            _context.Empresas.Update(empresa);

            _context.SaveChanges();

            return resposta;
        }
    }
}
