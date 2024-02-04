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
    public class ReciptionistController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public ReciptionistController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<ReciptionistController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ReciptionistLst = await _Conntext.Reciptionists.ToListAsync();
                return Ok(_mapper.Map<List<Reciptionist>>(ReciptionistLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ReciptionistController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Reciptionist = await _Conntext.Reciptionists.FindAsync(id);
                return Ok(_mapper.Map<Reciptionist>(Reciptionist));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ReciptionistController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReciptionistDto _ReciptionistDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Reciptionist = _mapper.Map<Reciptionist>(_ReciptionistDto);
                    await _Conntext.Reciptionists.AddAsync(Reciptionist);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Reciptionist);
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

        // PUT api/<ReciptionistController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ReciptionistDto _updatedReciptionist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedReciptionist = _mapper.Map<Reciptionist>(_updatedReciptionist);
                    _Conntext.Update(UpdatedReciptionist);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedReciptionist);
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

        // DELETE api/<ReciptionistController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedReciptionist = await _Conntext.Reciptionists.FindAsync(id);
                    _Conntext.Remove(DeletedReciptionist);
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
