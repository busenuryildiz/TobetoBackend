using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.ContactUs;
using Business.DTOs.Response.ContactUs;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{

    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsManager;

        public ContactUsController(IContactUsService contactUsManager)
        {
            _contactUsManager = contactUsManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddContactUs([FromBody] CreateContactUsRequest createContactUsRequest)
        {
            try
            {
                var result = await _contactUsManager.Add(createContactUsRequest);
                return CreatedAtAction(nameof(GetContactUsById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding contact message: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactUs(int id)
        {
            try
            {
                var deleteRequest = new DeleteContactUsRequest { Id = id };
                var result = await _contactUsManager.Delete(deleteRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting contact message: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactUsById(int id)
        {
            try
            {
                var result = await _contactUsManager.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting contact message by id: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetContactUsList([FromQuery] PageRequest pageRequest)
        {
            try
            {
                var result = await _contactUsManager.GetListAsync(pageRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting contact message list: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactUs([FromBody] UpdateContactUsRequest updateContactUsRequest)
        {
            try
            {
                var result = await _contactUsManager.Update(updateContactUsRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating contact message: {ex.Message}");
            }
        }
    }

}