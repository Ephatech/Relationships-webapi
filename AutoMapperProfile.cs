using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateQuestionDto, Question>();
            CreateMap<CreateAnswerDto, Answer>();
            CreateMap<UpdateQuestionDto, Question>();
        }
    }
}