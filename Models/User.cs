using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}