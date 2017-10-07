using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdoptMe.Models
{
    public class AnimalModel
    {
        [Key]
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }
        public string AnimalColor { get; set; }
        public string AnimalAgencyName { get; set; }
        public int AnimalAge { get; set; }
        //public int AdoptionAgencyID { get; set; }
        public virtual AdoptionAgencyModel AnimalAdoptionAgency { get; set; }
    }
}