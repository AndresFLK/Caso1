using Domain.Professor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Professors
{
    public interface IProfessorRepository
    {
        public List<Professor> GetAll();

        public Professor Get(Expression<Func<Professor, bool>> predicate);

        void Insert(Professor professor);

        void Update(Professor professor);

        void Delete(Professor professor);

        void Save();
    }
}
