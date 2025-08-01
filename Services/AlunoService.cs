using EnglishForLife.Data;
using EnglishForLife.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishForLife.Services
{
    public class AlunoService
    {
        private readonly ApiDbContext _context; 

        public AlunoService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Aluno> PostAluno(Aluno aluno)
        {
            var turma = await _context.Turmas
                                       .Include(t => t.Alunos)
                                       .FirstOrDefaultAsync(t => t.Id == aluno.TurmaId);

            if (turma == null)
            {
                throw new InvalidOperationException($"Turma com Id {aluno.TurmaId} não encontrada.");
            }

            const int numeroMaximoAlunos = 5;

            if (turma.Alunos.Count >= numeroMaximoAlunos)
            {
                throw new InvalidOperationException($"A turma '{turma.NomeTurma}' (Id: {turma.Id}) já atingiu o número máximo de {numeroMaximoAlunos} alunos.");
            }

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }
    }
}
