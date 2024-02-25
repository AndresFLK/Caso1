using Domain.Professor;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Professors
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<CreateProfessor, Professor>();


            CreateMap<UpdateProfessor, Professor>().ForMember(destination => destination.Id, source => source.Ignore());
        }
    }
}
