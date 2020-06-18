using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Servicos.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Servicos.ViewModel;

namespace Servicos.Repositorios
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly EmpresaRatingDbContext _context;
        private IDebitoRepositorio _debitoRepositorio;
        private INotasFiscaisRepositorio _notasFiscaisRepositorio;

        public EmpresaRepositorio(
            EmpresaRatingDbContext context,
            INotasFiscaisRepositorio notasFiscaisRepositorio,
            IDebitoRepositorio debitoRepositorio)
        {
            _debitoRepositorio = debitoRepositorio;
            _notasFiscaisRepositorio = notasFiscaisRepositorio;
            _context = context;
        }


        public Empresa ObterPorId(int id)
        {
            var empresa = _context.Empresas
                 .Include(e => e.Debitos)
                 .Include(e => e.NotasFicais)
                 .Where(e => e.Id == id).FirstOrDefault();

            empresa.ContarNotasEDebitos();

            return empresa;
        }

        public ICollection<Empresa> ObterTodos()
        {
            var empresas = _context.Empresas
                .Include(e => e.NotasFicais)
                .Include(e => e.Debitos)
                .OrderByDescending(e => e.Rating).ToList();

            foreach (Empresa empresa in empresas)
            {
                empresa.ContarNotasEDebitos();
            }

            return empresas;
        }

        public string EscreverTodasEmpresas()
        {
            var empresas = ObterTodos();
            string todasAsEmpresas = "";

            foreach (var empresa in empresas)
            {
                todasAsEmpresas = todasAsEmpresas + @$"
Nome: {empresa.Nome}
Pontuação: {empresa.Rating}
Débitos neste mes: {empresa.DebitosEsteMes}
Notas Fiscais neste mes: {empresa.NotasEsteMes}
_______________________________________________
";
            }

            return todasAsEmpresas;
        }

        public string EscreverEmpresa(int id)
        {
            var empresa = ObterPorId(id);

            string dados = @$"
Nome: {empresa.Nome}
Pontuação: {empresa.Rating}
Débitos neste mes: {empresa.DebitosEsteMes}
Notas Fiscais neste mes: {empresa.NotasEsteMes}

";

            return dados;
        }

        public string PostarArquivo(ArquivoDTO dto, int id)
        {
            string mensagem = "";

            for (int i = 0; i < dto.NumeroNotasFiscais; i++)
            {
                var novaNota = new NotaFiscal();
                novaNota.EmpresaId = id;
                var respota = _notasFiscaisRepositorio.PostarNotaFiscal(novaNota);
                if (!respota.sucesso)
                {
                    mensagem = mensagem + respota.mensagem + "/n";
                }
            }

            for (int i = 0; i < dto.NumeroDebitos; i++)
            {
                var novoDebito = new Debito();
                novoDebito.EmpresaId = id;
                var resposta = _debitoRepositorio.PostarDebito(novoDebito);
                if (!resposta.sucesso)
                {
                    mensagem = mensagem + resposta.mensagem + "/n";
                }
            }
            return mensagem;
        }
    }
}
