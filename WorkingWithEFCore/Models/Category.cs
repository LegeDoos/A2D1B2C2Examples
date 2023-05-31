using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithEFCore.Models
{
    public class Category
    {
        // map to database pk / identity
        public int CategoryId { get; set; }

        // map to database
        public string? CategoryName { get; set; }

        // map to database different type
        [Column(TypeName ="ntext")]
        public string? Description { get; set; }

        // navigation property
        public virtual ICollection<Product> Products { get; set; }

        // constructor
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
