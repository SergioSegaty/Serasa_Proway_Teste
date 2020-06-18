using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio.Modelos;
using Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;

        public EmpresasController(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        // GET: api/Empresas
        [HttpGet]
        public IEnumerable<Empresa> GetEmpresas()
        {
            return _empresaRepositorio.ObterTodos();
        }

        // GET: api/Empresas/id
        [HttpGet("{id}")]
        public ActionResult<Empresa> GetEmpresa(int id)
        {
            var empresa = _empresaRepositorio.ObterPorId(id);

            if (empresa == null)
            {
                return NotFound("Não foi possível achar a Empresa com este Id");
            }

            return empresa;

        }
        [HttpGet]
        [Route("EscreverTodos")]
        public IActionResult EscreverTodos()
        {
            var texto = _empresaRepositorio.EscreverTodasEmpresas();

            return Content(texto, "text/plain");
        }

        // POST: api/Empresas/EnviarArquivo
        [HttpPost]
        [Route("EnviarArquivo/{id}")]
        public IActionResult PostarArquivo([FromForm]IFormFile file, [FromRoute]int id)
        {
            if (file == null || file.Length == 0)
                return Content("Arquivo não selecionado");

            var diretorio = Path.Combine(
                  Directory.GetCurrentDirectory(), "wwwroot",
                  file.FileName);

            using (var stream = new FileStream(diretorio, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string jsonTexto = "";

            try
            {
                using (StreamReader sr = new StreamReader(diretorio))
                {
                    jsonTexto = sr.ReadToEnd();
                }
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var objeto = new ArquivoDTO();

            try
            {
                objeto = JsonConvert.DeserializeObject<ArquivoDTO>(jsonTexto);
            }
            catch (JsonReaderException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _empresaRepositorio.PostarArquivo(objeto, id);

            return Ok();
        }
    }
}
