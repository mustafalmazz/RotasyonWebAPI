using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotasyonWebAPI.Data;
using RotasyonWebAPI.DTOs;

namespace RotasyonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<DashboardSummaryDto>> GetSummary()
        {
            // 1. Veritabanından Gerçek Verileri Çekelim
            var containers = await _context.Containers.ToListAsync();
            var vehicles = await _context.Vehicles.ToListAsync();

            // --- HESAPLAMALAR ---

            // KPI 2: Yüksek Riskli Konteynerler (> %80)
            int highRisk = containers.Count(c => c.PredictedFill > 80);

            // KPI 3: Aktif Rota (Servisteki veya Yoldaki araçlar)
            int activeRoutes = vehicles.Count(v => v.Status == "Serviste" || v.Status == "Yolda");

            // Sağ Taraf: Doluluk Dağılımı
            int lowFill = containers.Count(c => c.PredictedFill <= 50);
            int medFill = containers.Count(c => c.PredictedFill > 50 && c.PredictedFill <= 80);
            int highFill = highRisk; // Zaten hesaplamıştık (>80)

            // --- SİMÜLASYONLAR (Gerçek veri henüz oluşmadığı için) ---

            // Grafik: Son 7 günün verisi (Rastgele üretelim ki grafik dolu gözüksün)
            var trend = new List<ChartDataPoint>();
            var days = new[] { "Pzt", "Sal", "Çar", "Per", "Cum", "Cmt", "Paz" };
            var rnd = new Random();

            foreach (var day in days)
            {
                trend.Add(new ChartDataPoint
                {
                    Date = day,
                    Amount = Math.Round(2.0 + rnd.NextDouble() * 3.0, 1) // 2.0 ile 5.0 arası
                });
            }

            // KPI 1: Bugünün Tahmini (Grafiğin son verisi olsun)
            double todayPred = trend.Last().Amount;

            // Cevabı Dönüyoruz
            return Ok(new DashboardSummaryDto
            {
                TodayPrediction = $"{todayPred} ton",
                HighRiskCount = highRisk,
                ActiveRoutes = activeRoutes,
                FuelSavingRate = 18, // Optimizasyon sayfasındaki sabit değer
                WeeklyTrend = trend,
                LowFillCount = lowFill,
                MediumFillCount = medFill,
                HighFillCount = highFill
            });
        }
    }
}