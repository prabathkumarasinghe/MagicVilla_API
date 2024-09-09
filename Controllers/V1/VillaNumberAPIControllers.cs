
using AutoMapper;
using MagicVilla.Data;
using MagicVilla.Model;
using MagicVilla.Model.Dto;
using MagicVilla.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla.Controllers.V1
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("1.0")]

    public class VillaNumberAPIControllers : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaNumberAPIControllers(IVillaNumberRepository dbVillaNumber, IVillaRepository dbVilla, IMapper mapper)
        {
            _dbVillaNumber = dbVillaNumber;
            _dbVilla = dbVilla;
            _mapper = mapper;
            _response = new();

        }


        [HttpGet]
        //[MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaListNumber = await _dbVillaNumber.GetAllAsync(includeproperties: "Villa");
                _response.Result = _mapper.Map<List<VillaNumberDto>>(villaListNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };


            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillasNumber(int id)
        {
            try
            {

                if (id == 0)
                {

                    return BadRequest();

                }

                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);

                if (villa == null)
                {
                    return NotFound();

                }
                _response.Result = _mapper.Map<VillaNumberDto>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };

            }

            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto villaDto)
        {
            try
            {

                if (await _dbVillaNumber.GetAsync(u => u.VillaNo == villaDto.VillaNo) != null)
                {
                    ModelState.AddModelError("Custom Error", "Villa Number already Exit");
                    return BadRequest(ModelState);
                }
                if (await _dbVilla.GetAsync(u => u.Id == villaDto.VillaID) == null)
                {
                    ModelState.AddModelError("Custom Error", "Villa Id is invalid");
                    return BadRequest(ModelState);
                }

                if (villaDto == null)
                {
                    return BadRequest(villaDto);
                }
                //    if (villaDto.VillaNo > 0)
                //    {
                //        return StatusCode(StatusCodes.Status500InternalServerError);
                //    }

                VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaDto);
                /*        Villa model = new Villa()
                        {
                            Amenity = villaDto.Name,
                            Details = villaDto.Details,
                            Id = villaDto.Id,
                            ImageUrl = villaDto.ImageUrl,
                            Name = villaDto.Name,
                            Occupancy = villaDto.Occupancy,
                            Rate = villaDto.Rate,
                            Sqft = villaDto.Sqft
                       }; */
                //  villa.Id = _db.villas.OrderByDescending(U => U.Id).FirstOrDefault().Id + 1;

                await _dbVillaNumber.CreateAsync(villaNumber);
                _response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = villaNumber.VillaNo }, _response);
            }

            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };

            }

            return _response;
        }

        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
                if (villaNumber == null)
                {
                    return NotFound();
                }

                await _dbVillaNumber.RemoveAsync(villaNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);

            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };

            }

            return _response;



        }

        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDto villaDto)
        {
            try
            {
                if (id != villaDto.VillaNo || villaDto == null)
                {
                    return BadRequest();
                }
                if (await _dbVilla.GetAsync(u => u.Id == villaDto.VillaID) == null)
                {
                    ModelState.AddModelError("Custom Error", "Villa Id is invalid");
                    return BadRequest(ModelState);
                }

                //  var villa = VillaStore.villaList.FirstOrDefault (u => u.Id == id);
                //  villa.Name = villaDto.Name;
                //  villa.Id = villaDto.Id;

                //  return NoContent();
                VillaNumber model = _mapper.Map<VillaNumber>(villaDto);
                /*   Villa model = new Villa()
                 {
                      Amenity = villaDto.Name,
                      Details = villaDto.Details,
                      Id = villaDto.Id,
                      ImageUrl = villaDto.ImageUrl,
                      Name = villaDto.Name,
                      Occupancy = villaDto.Occupancy,
                      Rate = villaDto.Rate,
                      Sqft = villaDto.Sqft
                  };*/
                await _dbVillaNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };

            }

            return _response;
        }


    }

}