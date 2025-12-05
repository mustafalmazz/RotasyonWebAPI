namespace RotasyonWebAPI.DTOs
{
    public class DashboardSummaryDto
    {
        // Kartlar İçin
        public string TodayPrediction { get; set; } // "3.4 ton"
        public int HighRiskCount { get; set; }      // 37
        public int ActiveRoutes { get; set; }       // 5
        public int FuelSavingRate { get; set; }     // 18 (%18)

        // Sol Grafik İçin (Son 7 gün)
        public List<ChartDataPoint> WeeklyTrend { get; set; }

        // Sağ Bar Çubukları İçin (Konteyner Dağılımı)
        public int LowFillCount { get; set; }    // %0-50
        public int MediumFillCount { get; set; } // %50-80
        public int HighFillCount { get; set; }   // %80-100
    }

    public class ChartDataPoint
    {
        public string Date { get; set; } // "Pzt", "Sal"
        public double Amount { get; set; } // Atık miktarı
    }
}