using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataFiscal.Data;
using DataFiscal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using DataFiscal.Facedes;

namespace DataFiscal.Controllers
{
    public class ArquivoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArquivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string MensagemFinal(List<Arquivo> arquivos) => string.Join("<br>-", arquivos.Select(a => a));

      
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(IList<IFormFile> uploads)
        {
            try
            {
                var importFiles = new ImportFile(_context, uploads);

                if (ModelState.IsValid)
                {
                    await _context.Arquivo.AddRangeAsync(importFiles.ArquivosValidos);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Message = string.Concat("Notas lidas com sucesso:<br>-",
                                                MensagemFinal(importFiles.TodosArquivos));
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Algo de errado não está certo:<br>" + ex.Message;
            }

            return View();
        }
    }
}
