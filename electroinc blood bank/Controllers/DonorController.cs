using AutoMapper;
using electroinc_blood_bank.Dtos;
using electroinc_blood_bank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electroinc_blood_bank.Controllers
{
    public class DonorController : Controller
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public DonorController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<DonorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var DonorLst = await _Conntext.Donors.ToListAsync();
                return Ok(_mapper.Map<List<Donor>>(DonorLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        // GET api/<DonorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Donor = await _Conntext.Donors.FindAsync(id);
                return Ok(_mapper.Map<Donor>(Donor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<DonorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DonorDto _DonorDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Donor = _mapper.Map<Donor>(_DonorDto);
                    await _Conntext.Donors.AddAsync(Donor);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Donor);
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

        [HttpGet]
        [Route("PostNewDonation")]
        public async Task<IActionResult> Post([FromBody] DonorHistoryDto donorHistory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _donorHistory = _mapper.Map<DonorHistory>(donorHistory);
                    await _Conntext.DonorsHistory.AddAsync(_donorHistory);
                    await _Conntext.SaveChangesAsync();
                  
                    var IncreaceAvalabileQuantity = await _Conntext.BloodQuantities.Where(e => e.BloodID == _donorHistory.BloodID &&e.BloodBankID==_donorHistory.BloodBankID).FirstOrDefaultAsync();
                    IncreaceAvalabileQuantity.quantity += _donorHistory.DonationAmout;
                    _Conntext.BloodQuantities.Update(IncreaceAvalabileQuantity);
                    await _Conntext.SaveChangesAsync();
                    return Ok(donorHistory);
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




        // PUT api/<DonorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] DonorDto _updatedDonor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedDonor = _mapper.Map<Donor>(_updatedDonor);
                    _Conntext.Update(UpdatedDonor);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedDonor);
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

        // DELETE api/<DonorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedDonor = await _Conntext.Donors.FindAsync(id);
                    _Conntext.Remove(DeletedDonor);
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
