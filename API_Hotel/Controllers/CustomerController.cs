using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using API_Hotel.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Hotel.Controllers
{
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IHotel _hotel;
        private readonly IMapper _mapper;

        public CustomerController(IHotel hotel, IMapper mapper)
        {
            _hotel = hotel;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer_View>>> Gets(string FullName, string Phone)
        {
            var book = await _hotel.Gets(FullName, Phone);
            var listBook_view = _mapper.Map<List<Customer_View>>(book);
            return Ok(listBook_view);
        }
        
        [HttpPut("{CusId}")]
        public async Task<ActionResult> Update(int CusId, [FromBody]Customer_View Cus)
        {
            var customer = _mapper.Map<Customer>(Cus);

            var rs = await _hotel.UpdateInfo(CusId, customer, _mapper);
            if (rs == true)
            {
                return Ok(rs);
            }
            return BadRequest();
        }

    }
}