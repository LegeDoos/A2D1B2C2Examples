using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstExample.Models
{
    public class VoorbeeldCategorie
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        // relatie
        public ICollection<Voorbeeld>? Voorbeelds { get; set; }

    }
}
