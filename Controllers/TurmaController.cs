using EnglishForLife.Data;
using EnglishForLife.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishForLife.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TurmaController(ApiDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }

            return await _context.Turmas.ToListAsync();
        }


        [HttpGet("{idTurma}/alunos")]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunosByTurma(int idTurma)
        {
            var alunos = await _context.Alunos
                                       .Where(a => a.TurmaId == idTurma)
                                       .ToListAsync();

            if (alunos == null || !alunos.Any())
            {
                return NotFound($"Nenhum aluno encontrado para a turma com ID {idTurma}.");
            }

            return alunos;
        }


        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            if (_context.Turmas == null)
            {
                return Problem("Erro ao criar uma Turma, Contate o suporte!");
            }

            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTurmas), new { id = turma.Id }, turma);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
