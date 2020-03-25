using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Api.Models.Entities;
using Hotel_Api.Models.ModelViews;
using Hotel_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Controllers
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

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]Customer_View customer_view)
        {
            var rs = await _hotel.AddCustomer(_mapper.Map<Customer>(customer_view));
            if (rs != null)
            {
                return Ok(rs);
            }
            return BadRequest();
        }
    }
}