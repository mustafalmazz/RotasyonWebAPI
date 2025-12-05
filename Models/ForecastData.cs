using System.ComponentModel.DataAnnotations;

namespace RotasyonWebAPI.Models
{
    public class ForecastData
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } 

        public double PredictedWaste { get; set; } 

        public int HighRiskCount { get; set; } 
    }
}
