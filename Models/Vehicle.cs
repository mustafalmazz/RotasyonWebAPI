using System.ComponentModel.DataAnnotations;

namespace RotasyonWebAPI.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public string Plate { get; set; } = string.Empty;  

        public string Capacity { get; set; } = string.Empty;  
        public string Fuel { get; set; } = string.Empty;      

        public string Status { get; set; } = string.Empty;   

        public string Route { get; set; } = string.Empty;     
    }
}
