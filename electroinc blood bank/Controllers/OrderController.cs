using AutoMapper;
using electroinc_blood_bank.Dtos;
using electroinc_blood_bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace electroinc_blood_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public OrderController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Get(int? orderFor)
        {
            try
            {
                var OrderLst = _mapper.Map<List<OrderDto>>(await _Conntext.Orders.ToListAsync());

               foreach(var o in OrderLst)
                {
                    o.bloodRh = (await _Conntext.Bloods.FindAsync(o.BloodID)).BloodRhEn.ToString();


                    var AmountInBank = await _Conntext.BloodQuantities.Where(e => e.BloodID == o.BloodID && e.type == o.type).Select(e => e.quantity).SumAsync();

                    if (o.BloodAmount > AmountInBank)
                    {
                        o.Avaliable = false;
                    }
                    else
                    {
                        o.Avaliable = true;
                    }
                }

                //foreach(var o in OrderLst)
                //{
                //    if (o.orderFor == OrderFor.Patient)
                //    {
                //        var p = await _Conntext.Patients.FindAsync(o.orderForID);
                //        o.Name = p.NameEn;
                //        o.PhoneNumber = p.Phone;
                //    }
                //    else
                //    {
                //        var p = await _Conntext.Hospitals.FindAsync(o.orderForID);
                //        o.Name = p.NameEn;
                //        o.PhoneNumber = p.Phone;
                //    }
                //}

                if (orderFor == 1)
                {
                    OrderLst= OrderLst.Where(e=>e.orderFor ==OrderFor.Patient).ToList();

                    
                }
                else if(orderFor== 2) {
                    OrderLst=OrderLst.Where(e=>e.orderFor ==OrderFor.Hospital ).ToList();

                }
              
                return Ok(OrderLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Order = await _Conntext.Orders.FindAsync(id);
                return Ok(_mapper.Map<Orders>(Order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto _OrderDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Order = _mapper.Map<Orders>(_OrderDto);
                    var AmountInBank = await _Conntext.BloodQuantities.Where(e => e.BloodID == Order.BloodID&&e.type==Order.type).Select(e => e.quantity).SumAsync();

                    if (Order.BloodAmount > AmountInBank)
                    {
                        Order.Avaliable=false;
                    }
                    else
                    {
                        Order.Avaliable=true;
                    }
                    await _Conntext.Orders.AddAsync(Order);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Order);
                }
                else
                {
                    return UnprocessableEntity(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] OrderDto _updatedOrder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedOrder = _mapper.Map<Orders>(_updatedOrder);
                    _Conntext.Update(UpdatedOrder);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedOrder);
                }
                else
                {
                    return UnprocessableEntity(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedOrder = await _Conntext.Orders.FindAsync(id);
                    _Conntext.Remove(DeletedOrder);
                    await _Conntext.SaveChangesAsync();
                    return Ok("");
                }
                else
                {
                    return UnprocessableEntity(ModelState);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
