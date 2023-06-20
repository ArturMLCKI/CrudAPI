using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cruds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carcontroller : ControllerBase
    {
        private readonly DataContext _context;
        public carcontroller(DataContext context)
        {

            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<car>>> Get()
        {
            return Ok(await _context.cars.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<car>>> Get(int id)
        {
            var Car = await _context.cars.FindAsync(id);
            if (Car == null)
            {
                return BadRequest("Nie znaleziony.");

            }
            return Ok(Car);
        }
        [HttpPost]
        public async Task<ActionResult<List<car>>> AddProdukty(car car)
        {
            _context.cars.Add(car);
            await _context.SaveChangesAsync();

            return Ok(await _context.cars.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<car>>> UpdateProdukty(car request)
        {
            var dbcar = await _context.cars.FindAsync(request.Id);
            if (dbcar == null)
            {
                return BadRequest("Nie znaleziony.");

            }

            dbcar.Marka = request.Marka;
            dbcar.Model = request.Model;
            dbcar.Price = request.Price;
            await _context.SaveChangesAsync();
            return Ok(await _context.cars.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<car>>> Delete(int id)
        {
            var dbcar = await _context.cars.FindAsync(id);
            if (dbcar == null)
            {
                return BadRequest("Nie znaleziony.");

            }
            _context.cars.Remove(dbcar);
            await _context.SaveChangesAsync();
            return Ok(await _context.cars.ToListAsync());

        }
    }
}
