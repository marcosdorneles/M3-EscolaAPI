﻿using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno, int>, IAlunoRepository
    {
        public AlunoRepository(EscolaDbContexto contexto) : base(contexto)
        {
          
        }

        public override Aluno ObterPorId(int id)
        {
            return _context.Alunos.Include(x=>x.Boletins).Include(x=>x.Turmas).FirstOrDefault(x => id == x.Id);
        }

        public bool EmailJaCadastrado(string email)
            => _context.Alunos.Any(x => x.Email == email);

    }
}
