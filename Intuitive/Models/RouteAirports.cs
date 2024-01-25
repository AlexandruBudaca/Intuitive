using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Intuitive.Models
{
	public class RouteAirports
	{
        [Key]
        public int RouteId { get; set; }
		public int DepartureAirportId { get; set; }
		public int ArrivalAirportId { get; set; }
    }
}

