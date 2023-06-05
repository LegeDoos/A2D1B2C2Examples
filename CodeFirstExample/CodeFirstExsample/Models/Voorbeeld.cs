using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExsample.Models
{
    public class Voorbeeld
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
