using Microsoft.EntityFrameworkCore;

namespace Cruds
{
    public class car
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        [Precision(18,2)]
        public decimal? Price { get; set; }

        public int ProduktyId { get; set; }

        public Produkty Produkty { get; set; }
    }
}
