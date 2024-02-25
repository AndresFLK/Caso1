using Aplication.Contexts;
using Application.Professors;
using Domain.Professor;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Professors
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<Professor> _professors;

        public ProfessorRepository(ApplicationDbContext context) { 
            _context = context;
            _professors = context.Professors;
        }

        public List<Domain.Professor.Professor> GetAll()
        {
            return _professors.ToList();
        }

        public Domain.Professor.Professor Get(Expression<Func<Domain.Professor.Professor, bool>> predicate)
        {
            IQueryable<Professor> query = _professors;
            query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        public void Insert(Domain.Professor.Professor professor)
        {
            _professors.Add(professor);
        }

        public void Update(Domain.Professor.Professor professor)
        {
            _professors.Update(professor);
        }

        public void Delete(Domain.Professor.Professor professor)
        {
            _professors.Remove(professor);
        }

        public void Save()
        {
            _context.Save();
        }
    }
}
