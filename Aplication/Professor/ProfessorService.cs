using AutoMapper;
using Domain.Professor;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Professors
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Result<IList<Professor>> List()
        {
            return Result.Success<IList<Professor>>(_repository.GetAll());
        }

        public Result<Professor> Get(int id)
        {
            var professor = _repository.Get(p => p.Id == id);

            if (professor is null)
            {
                return Result.Failure<Professor>(ProfessorErrors.NotFound());
            }

            return Result.Success<Professor>(professor);
        }

        public Result Create(CreateProfessor createProfessor)
        {
            var professor = _mapper.Map<CreateProfessor, Professor>(createProfessor);
            _repository.Insert(professor);
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateProfessor updateProfessor)
        {
            var result = Get(updateProfessor.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var professor = result.Value;
            _mapper.Map(updateProfessor, professor);
            _repository.Update(professor);
            _repository.Save();
            return Result.Success();
        }

        public Result Delete(int id)
        {
            var result = Get(id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }
            var professor = result.Value;
            _repository.Delete(professor);
            _repository.Save();
            return Result.Success();
        }
    }
}
