using System.Collections.Generic;

namespace api.Models
{
    public class User
    {
        public string Id { get; set;}
        public IList<ToDo> ToDos { get; set; }
    }
}