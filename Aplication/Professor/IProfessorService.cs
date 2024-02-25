using Domain.Professor;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Professors
{
    public interface IProfessorService
    {
        Result<IList<Professor>> List();
        Result<Professor> Get(int id);
        Result Create(CreateProfessor createProfessor);
        Result Update(UpdateProfessor updateProfessor);
        Result Delete(int id);
    }
}
