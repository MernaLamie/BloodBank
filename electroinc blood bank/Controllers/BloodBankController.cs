﻿using AutoMapper;
using electroinc_blood_bank.Dtos;
using electroinc_blood_bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace electroinc_blood_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {

        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public BloodBankController(ApplicationDBContext Context,IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<BloodBankController>
        [HttpGet]
        public async  Task<IActionResult> Get()
        {
            try
            {
                var BloodBankLst = await _Conntext.BloodBanks.ToListAsync();
                return Ok(_mapper.Map<List<BloodBank>>(BloodBankLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET api/<BloodBankController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var BloodBank = await _Conntext.BloodBanks.FindAsync(id);
                return Ok(_mapper.Map<BloodBank>(BloodBank));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BloodBankController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BloodBankDto _bloodBankDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bloodbank = _mapper.Map<BloodBank>(_bloodBankDto);
                    await _Conntext.BloodBanks.AddAsync(bloodbank);
                    await _Conntext.SaveChangesAsync();
                    return Ok(bloodbank);
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

        // PUT api/<BloodBankController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] BloodBankDto _updatedBloodBank)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Updatedbloodbank = _mapper.Map<BloodBank>(_updatedBloodBank);
                     _Conntext.Update(Updatedbloodbank);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedBloodBank);
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

        // DELETE api/<BloodBankController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedbloodBank= await _Conntext.BloodBanks.FindAsync(id);
                    _Conntext.Remove(DeletedbloodBank);
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

        [HttpGet]
        [Route("GetBloodRh")]
        public async Task<IActionResult> GetBloodRh()
        {
            try
            {
                var BloodQuantity = await _Conntext.Bloods.ToListAsync();
                return Ok(BloodQuantity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("GetAvaliableBloodQuantity")]
        public async Task<IActionResult> GetAvaliableBloodQuantity(int id)
        {
            try
            {
                var BloodQuantity = _mapper.Map<List<BloodQuantityDto>>(await _Conntext.BloodQuantities.Where(e=>e.BloodBankID==id).ToListAsync());

                foreach (var d in BloodQuantity)
                {
                    d.bloodRh = (await _Conntext.Bloods.FindAsync(d.BloodID)).BloodRhEn.ToString();
                }

                return Ok(BloodQuantity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("GetBloodExpiration")]
        public async Task<IActionResult> GetBloodExpiration(int id)
        {
            try
            {
                var BloodQuantityLst =_mapper.Map<List<DonorHistoryDto>>(await _Conntext.DonorsHistory.ToListAsync());
                

                foreach(var b in BloodQuantityLst)
                {
                    b.bloodRh = (await _Conntext.Bloods.FindAsync(b.BloodID)).BloodRhEn.ToString();
                    

                    if ((b.DateOfDonation - DateTime.Now).Days >= 42)
                    {
                        b.IsExpire = true;
                    }
                   
                   

                }
                return Ok(BloodQuantityLst.Where(e=>e.IsExpire==true).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
