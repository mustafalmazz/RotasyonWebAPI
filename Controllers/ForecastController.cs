using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotasyonWebAPI.Data;
using RotasyonWebAPI.Models;

namespace RotasyonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ForecastController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForecastData>>> GetForecasts()
        {
            // Eğer veritabanında hiç veri yoksa,  veri üretip kaydedelim
            if (!_context.Forecasts.Any())
            {
                var dummyData = new List<ForecastData>();
                var today = DateTime.UtcNow.Date;

                // Gelecek 7 gün için rastgele veri
                var random = new Random();
                for (int i = 1; i <= 7; i++)
                {
                    dummyData.Add(new ForecastData
                    {
                        Date = today.AddDays(i),
                        PredictedWaste = Math.Round(2.5 + (random.NextDouble() * 2), 1), 
                        HighRiskCount = random.Next(5, 20) 
                    });
                }

                _context.Forecasts.AddRange(dummyData);
                await _context.SaveChangesAsync();
            }

            return await _context.Forecasts.OrderBy(f => f.Date).ToListAsync();
        }
    }
}