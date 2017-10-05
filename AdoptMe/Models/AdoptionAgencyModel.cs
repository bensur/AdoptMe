using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdoptMe.Models
{
    public class AdoptionAgencyModel
    {
        [Key]
        public int AdoptionAgencyID { get; set; }
        public string AdoptionAgencyName { get; set; }
        public int AdoptionAgencyLocationLat { get; set; }
        public int AdoptionAgencyLocationLng { get; set; }
        public virtual ICollection<AnimalModel> AdoptionAgencyAnimals { get; set; }
    }
}