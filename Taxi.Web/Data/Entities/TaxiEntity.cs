using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;
namespace Taxi.Web.Data.Entities
{
    public class TaxiEntity : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(7, MinimumLength = 6, ErrorMessage = "The field {0} must have {1} characters")]
        [RegularExpression(@"^([A-Za-z]{3}\d{4})", ErrorMessage = "The field {0} must starts with 3 characters [A-Z] and numbers")]
        public string Plaque { get; set; }

        public ICollection<TripEntity> Trips { get; set; }
    }
}
