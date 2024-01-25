using System.ComponentModel.DataAnnotations;

namespace Intuitive.Models
{
	public class AirportGroupAssignment
	{
        [Key]
        public int AirportGroupId { get; set; }
        public AirportGroups AirportGroup { get; set; }

        public int AirportId { get; set; }
        public Airport Airport { get; set; }
    }
}

