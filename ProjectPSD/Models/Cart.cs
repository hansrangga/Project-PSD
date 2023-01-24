using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPSD.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public int? Quantity { get; set; }

        public int? Price { get; set; }

        public int? CartID { get; set; }

        public int? DeffaultPrice { get; set; }

    }
}
