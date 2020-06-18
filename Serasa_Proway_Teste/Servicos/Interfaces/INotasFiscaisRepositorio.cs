using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.Interfaces
{
    public interface INotasFiscaisRepositorio
    {
        public ICollection<NotaFiscal> ObterTodos();

        public (string mensagem, bool sucesso) PostarNotaFiscal(NotaFiscal notaFiscal);
    }
}
