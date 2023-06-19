using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cruds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktyController : ControllerBase
    {
        
        private readonly DataContext _context;
        public ProduktyController(DataContext context)
        {

            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Produkty>>> Get()
        {
            return Ok(await _context.Produktys.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Produkty>>> Get(int id)
        {
            var produkt = await _context.Produktys.FindAsync(id);
            if (produkt == null )
            {
                return BadRequest("Nie znaleziony.");
                
            }
            return Ok(produkt);
        }
        [HttpPost]
        public async Task<ActionResult<List<Produkty>>> AddProdukty(Produkty produkty)
        {
            _context.Produktys.Add(produkty);
            await _context.SaveChangesAsync();

            return Ok(await _context.Produktys.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Produkty>>> UpdateProdukty(Produkty request)
        {
            var dbprodukt = await _context.Produktys.FindAsync(request.Id);
            if (dbprodukt == null)
            {
                return BadRequest("Nie znaleziony.");

            }

            dbprodukt.Name = request.Name;
            dbprodukt.Desctripiton = request.Desctripiton;
            await _context.SaveChangesAsync();
            return Ok(await _context.Produktys.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Produkty>>> Delete(int id)
        {
            var dbprodukt = await _context.Produktys.FindAsync(id);
            if (dbprodukt == null)
            {
                return BadRequest("Nie znaleziony.");

            }
            _context.Produktys.Remove(dbprodukt);
            await _context.SaveChangesAsync();
            return Ok(await _context.Produktys.ToListAsync());
        }
    }
}
