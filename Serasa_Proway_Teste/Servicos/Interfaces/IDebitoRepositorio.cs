using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.Interfaces
{
    public interface IDebitoRepositorio
    {
        public ICollection<Debito> ObterTodos();

        public (string mensagem, bool sucesso) PostarDebito(Debito debito);
    }
}
