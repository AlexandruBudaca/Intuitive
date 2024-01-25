using System;
using System.ComponentModel.DataAnnotations;

namespace Intuitive.Models
{
	public class Airport
	{
        [Key]
        public int AirportId { get; set; }
        public string? IataCode { get; set; }
        public int GeographyLevel1Id { get; set; }
        public GeographyLevel1? GeographyLevels{ get; set; } 
        public string? Type { get; set; }
        public List<AirportGroupAssignment> AirportGroupAssignments { get; set; }
    }
}

