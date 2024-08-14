using MagicVilla.Data;
using MagicVilla.Model;
using MagicVilla.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIControllers : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public VillaAPIControllers(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {

            return Ok(await _db.villas.ToListAsync());

        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Villa>> GetVillas(int id)
        {

            if (id == 0)
            {

                return BadRequest();

            }

            var villa = await _db.villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();

            }

            return Ok(villa);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Villa>> CreateVilla([FromBody] VillaCreateDto villaDto)
        {

            if (_db.villas.FirstOrDefaultAsync(u => u.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                return BadRequest(ModelState);
            }
            {

            }
            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }
            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Villa model = new Villa()
            {
                Amenity = villaDto.Name,
                Details = villaDto.Details,
                Id = villaDto.Id,
                ImageUrl = villaDto.ImageUrl,
                Name = villaDto.Name,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate,
                Sqft = villaDto.Sqft
            };
            //  villa.Id = _db.villas.OrderByDescending(U => U.Id).FirstOrDefault().Id + 1;

            await _db.villas.AddAsync(model);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.villas.Remove(villa);
            await _db.SaveChangesAsync();
            return NoContent();

        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto villaDto)
        {
            if (id != villaDto.Id || villaDto == null)
            {
                return BadRequest();
            }

            //  var villa = VillaStore.villaList.FirstOrDefault (u => u.Id == id);
            //  villa.Name = villaDto.Name;
            //  villa.Id = villaDto.Id;

            //  return NoContent();

            Villa model = new Villa()
            {
                Amenity = villaDto.Name,
                Details = villaDto.Details,
                Id = villaDto.Id,
                ImageUrl = villaDto.ImageUrl,
                Name = villaDto.Name,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate,
                Sqft = villaDto.Sqft
            };
            _db.villas.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();


        }
    }
   
}