using MagicVilla.Data;
using MagicVilla.Model;
using MagicVilla.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    [Route ("api/VillaAPI")]
    [ApiController]
    public class VillaAPIControllers : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VillaDto> GetVillas()
        {
            
            return Ok(VillaStore.villaList);

         }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVillas(int id)
        {

            if (id == 0)
            {
                return BadRequest ();
            
            }

            var villa = VillaStore.villaList.Where(u => u.Id == id);

            if (villa == null)
            { 
                return NotFound ();
            
            }

            return Ok(villa);

        }

        [HttpPost]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
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

            return Ok(villaDto);
        }


    }
}
