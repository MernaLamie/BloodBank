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
    public class HospitalController : ControllerBase
    {

        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public HospitalController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<HospitalController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var HospitalLst = await _Conntext.Hospitals.ToListAsync();
                return Ok(_mapper.Map<List<Hospital>>(HospitalLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<HospitalController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Hospital = await _Conntext.Hospitals.FindAsync(id);
                return Ok(_mapper.Map<Hospital>(Hospital));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<HospitalController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HospitalDto _HospitalDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Hospital = _mapper.Map<Hospital>(_HospitalDto);
                    await _Conntext.Hospitals.AddAsync(Hospital);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Hospital);
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

        // PUT api/<HospitalController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] HospitalDto _updatedHospital)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedHospital = _mapper.Map<Hospital>(_updatedHospital);
                    _Conntext.Update(UpdatedHospital);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedHospital);
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

        // DELETE api/<HospitalController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedHospital = await _Conntext.Hospitals.FindAsync(id);
                    _Conntext.Remove(DeletedHospital);
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
