﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Models
{
    public class Voorbeeld
    {
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public ICollection<VoorbeeldCategorie>? VoorbeeldCategories { get; set; }
    }
}
