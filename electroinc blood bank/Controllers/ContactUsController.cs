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
    public class ContactUsController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public ContactUsController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<ContactUSController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ContactUSLst = await _Conntext.ContactUs.ToListAsync();
                return Ok(ContactUSLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ContactUSController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ContactUS = await _Conntext.ContactUs.FindAsync(id);
                return Ok(_mapper.Map<ContactUs>(ContactUS));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContactUSController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactUs _ContactUs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    await _Conntext.ContactUs.AddAsync(_ContactUs);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_ContactUs);
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

        // PUT api/<ContactUSController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ContactUs _updatedContactUS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    _Conntext.Update(_updatedContactUS);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedContactUS);
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

        // DELETE api/<ContactUSController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedContactUS = await _Conntext.ContactUs.FindAsync(id);
                    _Conntext.Remove(DeletedContactUS);
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
