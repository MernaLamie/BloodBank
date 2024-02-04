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
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public ManagerController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<ManagerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ManagerLst = await _Conntext.Managers.ToListAsync();
                return Ok(_mapper.Map<List<Manager>>(ManagerLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ManagerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Manager = await _Conntext.Managers.FindAsync(id);
                return Ok(_mapper.Map<Manager>(Manager));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ManagerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ManagerDto _ManagerDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Manager = _mapper.Map<Manager>(_ManagerDto);
                    await _Conntext.Managers.AddAsync(Manager);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Manager);
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

        // PUT api/<ManagerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ManagerDto _updatedManager)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedManager = _mapper.Map<Manager>(_updatedManager);
                    _Conntext.Update(UpdatedManager);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedManager);
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

        // DELETE api/<ManagerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedManager = await _Conntext.Managers.FindAsync(id);
                    _Conntext.Remove(DeletedManager);
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

