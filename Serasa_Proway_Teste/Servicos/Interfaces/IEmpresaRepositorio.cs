using Dominio.Modelos;
using Servicos.Repositorios;
using System.Collections.Generic;

namespace Servicos.Interfaces
{
    public interface IEmpresaRepositorio
    {
        public ICollection<Empresa> ObterTodos();

        public Empresa ObterPorId(int id);

        public string PostarArquivo(ArquivoDTO dto, int id);

        public string EscreverEmpresa(int id);

        public string EscreverTodasEmpresas();
    }
}
