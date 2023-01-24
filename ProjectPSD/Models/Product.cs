using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPSD.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public string? ImagePath { get; set; }

        public int? Price { get; set; }

        public int? CategoryID { get; set; }
    }
}
