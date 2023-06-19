using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cruds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktyController : ControllerBase
    {
        private static List<Produkty> produktys = new List<Produkty>
        {
            new Produkty
            { 
                Id = 1,
                Name = "Telefon",
                Desctripiton = "Samsung"
            }
        };
        [HttpGet]
        public async Task<ActionResult<List<Produkty>>> Get()
        {
            return Ok(produktys);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Produkty>>> Get(int id)
        {
            var produkt = produktys.Find(p => p.Id == id);
            if (produkt == null )
            {
                return BadRequest("Nie znaleziony.");
                
            }
            return Ok(produktys);
        }
        [HttpPost]
        public async Task<ActionResult<List<Produkty>>> AddProdukty(Produkty produkty)
        {
            produktys.Add(produkty);
            return Ok(produkty);
        }
        [HttpPut]
        public async Task<ActionResult<List<Produkty>>> UpdateProdukty(Produkty request)
        {
            var produkt = produktys.Find(p => p.Id == request.Id);
            if (produkt == null)
            {
                return BadRequest("Nie znaleziony.");

            }

            produkt.Name = request.Name;
            produkt.Desctripiton = request.Desctripiton;

            return Ok(produktys);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Produkty>>> Delete(int id)
        {
            var produkt = produktys.Find(p => p.Id == id);
            if (produkt == null)
            {
                return BadRequest("Nie znaleziony.");

            }
            produktys.Remove(produkt);
            return Ok(produktys);
        }
    }
}
