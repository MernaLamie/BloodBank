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
    public class EventController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public EventController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<EventController>
        [HttpGet]
        public async Task<IActionResult> Get(string? nameEn, string? nameAr)
        {
            try
            {
                var EventLst = await _Conntext.Events.ToListAsync();
                if (!string.IsNullOrEmpty(nameEn))
                {
                    EventLst = EventLst.Where(e => e.titleEn.Contains(nameEn)).ToList();
                }
                if (!string.IsNullOrEmpty(nameAr))
                {
                    EventLst = EventLst.Where(e => e.titleAr.Contains(nameAr)).ToList();
                }


                return Ok(_mapper.Map<List<EventDto>>(EventLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public async  Task<IActionResult> Get(int id)
        {
            try
            {
                var Event = await _Conntext.Events.FindAsync(id);
                return Ok(_mapper.Map<Event>(Event));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EventController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] EventDto _EventDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Event = _mapper.Map<Event>(_EventDto);
                    await _Conntext.Events.AddAsync(Event);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Event);
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

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromForm] EventDto _updatedEvent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedEvent = _mapper.Map<Event>(_updatedEvent);
                    _Conntext.Update(UpdatedEvent);
                    await _Conntext.SaveChangesAsync();
                  var Event = await _Conntext.Events.FindAsync(UpdatedEvent.Id);
                    return Ok(_mapper.Map<EventDto>(Event));
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

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedEvent = await _Conntext.Events.FindAsync(id);
                    _Conntext.Remove(DeletedEvent);
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

    