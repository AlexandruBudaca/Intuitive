using System.ComponentModel.DataAnnotations;
namespace Intuitive.Models
{
	public class AirportGroups
	{
        [Key]
        public int AirportGroupID { get; set; }
        public string? Name { get; set; }

        public List<AirportGroupAssignment> AirportGroupAssignments { get; set; }
    }
}

