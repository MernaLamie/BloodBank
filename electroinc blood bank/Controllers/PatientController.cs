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
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public PatientController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var PatientLst = await _Conntext.Patients.ToListAsync();
                return Ok(_mapper.Map<List<Patient>>(PatientLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Patient = await _Conntext.Patients.FindAsync(id);
                return Ok(_mapper.Map<Patient>(Patient));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientDto _PatientDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Patient = _mapper.Map<Patient>(_PatientDto);
                    await _Conntext.Patients.AddAsync(Patient);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Patient);
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

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] PatientDto _updatedPatient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedPatient = _mapper.Map<Patient>(_updatedPatient);
                    _Conntext.Update(UpdatedPatient);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedPatient);
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

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedPatient = await _Conntext.Patients.FindAsync(id);
                    _Conntext.Remove(DeletedPatient);
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

