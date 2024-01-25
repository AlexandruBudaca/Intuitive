using System;
using System.ComponentModel.DataAnnotations;

namespace Intuitive.Models
{
    public class GeographyLevel1
    {
        public int GeographyLevel1Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Airport>? Airports {get; set;}
    }

}

