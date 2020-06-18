using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio.Modelos;
using Servicos.Interfaces;

namespace View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasFiscaisController : ControllerBase
    {
        private readonly INotasFiscaisRepositorio _notasFiscaisRepositorio;

        public NotasFiscaisController(INotasFiscaisRepositorio notasFiscaisRepositorio)
        {
            _notasFiscaisRepositorio = notasFiscaisRepositorio;
        }

        //GET-ALL api/NotasFiscais
        [HttpGet]
        public IEnumerable<NotaFiscal> GetNotasFiscais()
        {
            return _notasFiscaisRepositorio.ObterTodos();
        }

        // POST: api/NotasFiscais
        [HttpPost]
        public IActionResult PostNotaFiscal(NotaFiscal notaFiscal)
        {
            if (notaFiscal.EmpresaId <= 0)
            {
                return BadRequest("Nota Fiscal precisa conter um Id de Empresa");
            }

            var resposta = _notasFiscaisRepositorio.PostarNotaFiscal(notaFiscal);

            return CreatedAtAction(resposta.mensagem, new { notaFiscal.Id }, notaFiscal);
        }
    }
}
