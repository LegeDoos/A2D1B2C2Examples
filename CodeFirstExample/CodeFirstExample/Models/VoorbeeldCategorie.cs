using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Models
{
    public class VoorbeeldCategorie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Voorbeeld>? Voorbeelds { get; set; }
    }
}
