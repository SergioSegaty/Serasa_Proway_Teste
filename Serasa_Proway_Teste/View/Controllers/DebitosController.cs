using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio.Modelos;
using Servicos.Interfaces;

namespace View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitosController : ControllerBase
    {
        private readonly IDebitoRepositorio _debitoRepositorio;

        public DebitosController(IDebitoRepositorio debitoRepositorio)
        {
            _debitoRepositorio = debitoRepositorio;
        }

        // GET-ALL: api/Debitos
        [HttpGet]
        public IEnumerable<Debito> GetDebitos()
        {
            return _debitoRepositorio.ObterTodos();
        }

        // POST: api/Debitos
        [HttpPost]
        public IActionResult PostDebito(Debito debito)
        {
            if (debito.EmpresaId <= 0)
            {
                return BadRequest("Debito precisa conter um Id de Empresa");
            }

            var resposta = _debitoRepositorio.PostarDebito(debito);
            
            return CreatedAtAction(resposta.mensagem, new { debito.Id }, debito);
        }
    }
}
