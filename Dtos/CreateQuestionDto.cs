using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships.Dtos
{
    public class CreateQuestionDto
    {
        // public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public int UserId { get; set; }
    }
}