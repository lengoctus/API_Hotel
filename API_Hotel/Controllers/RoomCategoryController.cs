using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Hotel.Models.ModelViews;
using API_Hotel.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Hotel.Controllers
{
    [Route("api/RoomCategory")]
    public class RoomCategoryController : ControllerBase
    {
        private readonly IHotel _hotel;
        private readonly IMapper _mapper;

        public RoomCategoryController(IHotel hotel, IMapper mapper)
        {
            _hotel = hotel;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomCategory_View>>> Get()
        {
            var listCategory = await _hotel.GetRoomCategory(null);
            if (listCategory != null)
            {
                return Ok(listCategory);
            }
            return BadRequest();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RoomCategory_View>>> Get(int id)
        {
            var listCategory = await _hotel.GetRoomCategory(id);
            if (listCategory != null)
            {
                return Ok(_mapper.Map<IEnumerable<RoomCategory_View>>(listCategory));
            }
            return BadRequest();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]RoomCategory_View roomCate)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
