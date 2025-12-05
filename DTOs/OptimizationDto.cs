namespace RotasyonWebAPI.DTOs
{
    // Frontend'den gelen istek
    public class OptimizeRequestDto
    {
        public string Region { get; set; } = "Tümü";
        public int VehicleCount { get; set; } = 4;
        public string Objective { get; set; } = "Yakıt"; // Yakıt, Mesafe, Süre
    }

    // Frontend'e döneceğimiz cevap
    public class OptimizeResultDto
    {
        public string Distance { get; set; }
        public string Duration { get; set; }
        public string Fuel { get; set; }
        public string Saving { get; set; }
    }
}