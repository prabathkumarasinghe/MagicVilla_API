using MagicVilla.Data;
using MagicVilla.Model;
using MagicVilla.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIControllers : ControllerBase
    {
       

        public VillaAPIControllers()
        {
            
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VillaDto> GetVillas()
        {
            
            return Ok(VillaStore.villaList);

        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVillas(int id)
        {

            if (id == 0)
            {
                
                return BadRequest();

            }

            var villa = VillaStore.villaList.Where(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();

            }

            return Ok(villa);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {

            if (!ModelState.IsValid)
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
            villaDto.Id = VillaStore.villaList.OrderByDescending(U => U.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);

            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0) 
            {
                return BadRequest ();
            }

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            { 
                return NotFound ();
            }
            VillaStore.villaList.Remove(villa);
            return NoContent ();
            
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdataVilla(int id, [FromBody]VillaDto villaDto)
        {
            if (id != villaDto.Id || villaDto == null)
            {
                return BadRequest();
            }
            
            var villa = VillaStore.villaList.FirstOrDefault (u => u.Id == id);
            villa.Name = villaDto.Name;
            villa.Id = villaDto.Id;

            return NoContent();

        }


    }
}
