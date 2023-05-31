using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithEFCore.Models
{
    public class Product
    {
        //  map pk to database
        public int ProductId { get; set; }

        // map with extra attributes
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; } = null!; // null forgiving operator: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving

        // map with different name
        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }

        [Column("UnitsInStock")]
        public short? Stock { get; set; }

        // map to database column
        public bool Discontinued { get; set; }

        // fk
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
