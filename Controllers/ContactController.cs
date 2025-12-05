using Microsoft.AspNetCore.Mvc;
using RotasyonWebAPI.Data;
using RotasyonWebAPI.DTOs;
using RotasyonWebAPI.Models;
using System;

namespace RotasyonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/contact
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] CreateContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newMessage = new ContactMessage
            {
                FullName = contactDto.FullName,
                Email = contactDto.Email,
                Subject = contactDto.Subject,
                Message = contactDto.Message,
                CreatedAt = DateTime.UtcNow
            };

            _context.ContactMessages.Add(newMessage);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Mesajınız başarıyla iletildi!" });
        }
    }
}
