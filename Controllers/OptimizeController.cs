using Microsoft.AspNetCore.Mvc;
using RotasyonWebAPI.DTOs;

namespace RotasyonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimizeController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<OptimizeResultDto>> RunOptimization([FromBody] OptimizeRequestDto request)
        {
            // 1. Sanki karmaşık bir AI algoritması çalışıyormuş gibi bekletelim
            await Task.Delay(1500); // 1.5 saniye bekle

            // 2. Gelen parametrelere göre dinamik sonuç üretelim
            double baseDistance = 40.0;
            double baseFuel = 20.0;

            // Bölgeye göre mesafeyi değiştir
            if (request.Region == "Merkez") { baseDistance = 25.5; baseFuel = 12.4; }
            else if (request.Region == "Sanayi") { baseDistance = 65.2; baseFuel = 35.8; }
            else if (request.Region == "Sahil") { baseDistance = 32.1; baseFuel = 18.2; }

            // Araç sayısı arttıkça yakıt artar ama süre azalır (Basit mantık)
            if (request.VehicleCount > 4)
            {
                baseFuel *= 1.2; // Yakıt artar
            }

            // Rastgelelik ekle (Her seferinde aynı sayı çıkmasın)
            var random = new Random();
            double finalDistance = baseDistance + random.NextDouble() * 5;
            double finalFuel = baseFuel + random.NextDouble() * 3;

            // Tasarruf oranı (Rastgele %10 ile %25 arası)
            int savingRate = random.Next(10, 25);

            return Ok(new OptimizeResultDto
            {
                Distance = $"{finalDistance:F1} km",
                Duration = $"{(int)(finalDistance * 1.5)} dk", // Hız tahmini
                Fuel = $"{finalFuel:F1} L",
                Saving = $"+%{savingRate} yakıt tasarrufu"
            });
        }
    }
}