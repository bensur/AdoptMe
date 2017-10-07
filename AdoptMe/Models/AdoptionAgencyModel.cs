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
        public float AdoptionAgencyLocationLat { get; set; }
        public float AdoptionAgencyLocationLng { get; set; }
        public virtual ICollection<AnimalModel> AdoptionAgencyAnimals { get; set; }
    }
}