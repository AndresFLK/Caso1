using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Professors
{
    public class ProfessorErrors
    {
        public static Error NotFound(int id) => new Error("Professors.NOT_FOUND", $"The Professor with ID {id} was not found");

        public static Error NotFound() => new Error("Professors.NOT_FOUND", $"The Professor was not found");

    }
}
