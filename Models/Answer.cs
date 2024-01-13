using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public User User { get; set; }
        public int UserId { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }        
    }
}