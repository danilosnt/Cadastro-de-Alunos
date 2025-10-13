using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroEstudantesIEL.Data;
using CadastroEstudantesIEL.Models;
using System.Linq.Expressions;

namespace CadastroEstudantesIEL.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudantes --- MÉTODO CORRIGIDO COM A LÓGICA DE BUSCA ---
        public async Task<IActionResult> Index(string termoBusca)
        {
            // Começa criando uma consulta base para todos os estudantes
            var estudantes = from e in _context.Estudantes
                             select e;

            // Se o termo de busca não for nulo ou vazio...
            if (!String.IsNullOrEmpty(termoBusca))
            {
                // ...filtra a consulta, buscando em Nome, CPF ou Endereço
                estudantes = estudantes.Where(s => s.Nome.Contains(termoBusca)
                                                || s.CPF.Contains(termoBusca)
                                                || s.Endereco.Contains(termoBusca));
            }

            // Executa a consulta (já filtrada ou não) e envia a lista para a View
            return View(await estudantes.ToListAsync());
        }

        // GET: Estudantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // GET: Estudantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Endereco,DataConclusao")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(estudante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Verifica a exceção interna para o erro de chave única do SQL Server (números 2601 ou 2627)
                    if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx &&
                       (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                    {
                        ModelState.AddModelError("CPF", "Este CPF já está cadastrado em nosso sistema.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar os dados.");
                    }
                }
            }
            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        // Este método busca o estudante e MOSTRA a página de edição.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Endereco,DataConclusao")] Estudante estudante)
        {
            if (id != estudante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Verifica a exceção interna para o erro de chave única do SQL Server (números 2601 ou 2627)
                    if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx &&
                       (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                    {
                        ModelState.AddModelError("CPF", "Este CPF já está cadastrado em nosso sistema.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar as alterações.");
                    }
                }
            }
            return View(estudante);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudantes.Any(e => e.Id == id);
        }
    }
}