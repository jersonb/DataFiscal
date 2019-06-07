using DataFiscal.Data;
using DataFiscal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataFiscal.Controllers
{
    public class OperacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Operacao
        public async Task<IActionResult> Index()
        {
            return View(await _context
                                    .Operacao
                                    .Include(o => o.Cfop)
                                    .Include(o => o.Ncm)
                                    .Include(o => o.Origem)
                                    .Include(o => o.Cst)
                                    .Include(o => o.Aliq)
                                    .Where(o => o.Valida.Equals(""))
                                    .ToListAsync());
        }
         public async Task<IActionResult> Validas()
        {
            return View(await _context
                                   .Operacao
                                   .Include(o => o.Cfop)
                                   .Include(o => o.Ncm)
                                   .Include(o => o.Origem)
                                   .Include(o => o.Cst)
                                   .Include(o => o.Aliq)
                                   .Where(o => o.Valida.Equals("1"))
                                   .ToListAsync());
        }
         public async Task<IActionResult> NaoValidas()
        {
            return View(await _context
                                    .Operacao
                                    .Include(o => o.Cfop)
                                    .Include(o => o.Ncm)
                                    .Include(o => o.Origem)
                                    .Include(o => o.Cst)
                                    .Include(o => o.Aliq)
                                    .Where(o => o.Valida.Equals("0"))
                                    .ToListAsync());
        }

        // GET: Operacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacao = await _context.Operacao
                                                .Include(o => o.Cfop)
                                                .Include(o => o.Ncm)
                                                .Include(o => o.Origem)
                                                .Include(o => o.Cst)
                                                .Include(o => o.Aliq)
                                                .Where(o => o.Id.Equals(id))
                                                .FirstAsync();

            if (operacao == null)
            {
                return NotFound();
            }

            return View(operacao);
        }

        // GET: Operacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacao = await _context.Operacao.FindAsync(id);

            if (operacao == null)
            {
                return NotFound();
            }
            return View(operacao);
        }

        // POST: Operacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Valida")] string valida)
        {
            var operacao = await _context.Operacao
                                               .Include(o => o.Cfop)
                                               .Include(o => o.Ncm)
                                               .Include(o => o.Origem)
                                               .Include(o => o.Cst)
                                               .Include(o => o.Aliq)
                                               .Where(o => o.Id.Equals(id))
                                               .FirstAsync();
            operacao.Valida = valida;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperacaoExists(operacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(operacao);
        }

        private bool OperacaoExists(int id)
        {
            return _context.Operacao.Any(e => e.Id == id);
        }
    }
}
