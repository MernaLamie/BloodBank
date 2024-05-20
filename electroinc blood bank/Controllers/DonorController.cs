using AutoMapper;
using electroinc_blood_bank.Dtos;
using electroinc_blood_bank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace electroinc_blood_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("GetAllDonors")]
        public async Task<IActionResult> GetAllDonors(string? nameEn, string? nameAr)
        {
            try
            {
                var DonorLst = await _Conntext.Donors.ToListAsync();
                var mappingDonerLst = _mapper.Map < List < DonorDto >> (DonorLst);
                foreach (var D in mappingDonerLst)
                {
                    var blood= await _Conntext.Bloods.FindAsync(D.BloodID);
                    D.bloodRh = blood.BloodRhEn.ToString();
                }

                if (!string.IsNullOrEmpty(nameEn))
                {
                    mappingDonerLst = mappingDonerLst.Where(e => e.NameEn.Contains(nameEn)).ToList();
                }
                if (!string.IsNullOrEmpty(nameAr))
                {
                    mappingDonerLst = mappingDonerLst.Where(e => e.NameAr.Contains(nameAr)).ToList();
                }
              
        
                  return Ok(mappingDonerLst);
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
                return Ok(_mapper.Map<DonorDto>(Donor));

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

        [HttpPost]
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
                  
                    var IncreaceAvalabileQuantity = await _Conntext.BloodQuantities.Where(e => e.BloodID == _donorHistory.BloodID &&e.BloodBankID==_donorHistory.BloodBankID && e.type==_donorHistory.type).FirstOrDefaultAsync();
                   if (IncreaceAvalabileQuantity == null)
                    {
                        IncreaceAvalabileQuantity = new BloodQuantity() { BloodBankID = donorHistory.BloodBankID, BloodID = donorHistory.BloodID, type = _donorHistory.type, quantity = 0 };
                    }
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


        // GET api/<DonorController>/5
        [HttpGet]
        [Route("DonorHistory")]
        public async Task<IActionResult> GetDonorHistory(int id)
        {
            try
            {
                var Donor = await _Conntext.DonorsHistory.Where(e=>e.DonorID==id).ToListAsync();
                return Ok(_mapper.Map<List<DonorHistoryDto>>(Donor));
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
