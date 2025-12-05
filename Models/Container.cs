using System.ComponentModel.DataAnnotations;

namespace RotasyonWebAPI.Models 
{
    public class Container
    {
        [Key]
        public int Id { get; set; }

        public string ContainerCode { get; set; } = string.Empty; 

        public string Zone { get; set; } = string.Empty; 

        public string Address { get; set; } = string.Empty;

        public DateTime LastCollected { get; set; } = DateTime.UtcNow; 

        public double PredictedFill { get; set; } 

        public string Status { get; set; } = "Planlı"; // Kritik, Öncelikli, Planlı
    }
}