using Microsoft.EntityFrameworkCore;

namespace Cruds
{
    public class Produkty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctripiton { get; set; }

        public car car { get; set; }


    }
}
