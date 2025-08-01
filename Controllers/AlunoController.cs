using EnglishForLife.Data;
using EnglishForLife.Models;
using EnglishForLife.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishForLife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly AlunoService _alunoService;

        public AlunoController(ApiDbContext context, AlunoService alunoService)
        {
            _context = context;
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            if ( _context.Alunos == null)
            {
                return NotFound();
            }

            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAlunoId(int id)
        {
            if ( _context == null) 
            { 
                 return NotFound(); 
            }

            var getAlunoId = await _context.Alunos.FindAsync(id);

            if (getAlunoId == null)
            {
                return NotFound();
            }

            return getAlunoId;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, [FromBody] AlunoDto alunoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alunoExiste = await _context.Alunos.FindAsync(id);

            if (alunoExiste == null)
            {
                return NotFound($"Aluno com ID {id} não encontrado.");
            }

            alunoExiste.Nome = alunoDto.Nome;
            alunoExiste.Email = alunoDto.Email;
            alunoExiste.Cpf = alunoDto.Cpf;

            try
            { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno (Aluno aluno)
        {
            if (_context.Alunos == null)
            {
                return Problem("Erro ao criar uma Aluno, Contate o suporte!");
            }

            try
            {
                var novoAluno = await _alunoService.PostAluno(aluno);
                return CreatedAtAction(nameof(GetAlunos), new { id = novoAluno.Id }, novoAluno);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno (int id)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);

            if(aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok();

        }

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(a => a.Id == id)).GetValueOrDefault();
        }
    } 
}
