using System;
using System.ComponentModel;
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
        [DisplayName("Animal Name")]
        public string AnimalName { get; set; }
        [DisplayName("Animal Type")]
        public string AnimalType { get; set; }
        [DisplayName("Animal Breed")]
        public string AnimalBreed { get; set; }
        [DisplayName("Animal Color")]
        public string AnimalColor { get; set; }
        [DisplayName("Animal Agency Name")]
        public string AnimalAgencyName { get; set; }
        [DisplayName("Animal Age")]
        public int AnimalAge { get; set; }
        public virtual AdoptionAgencyModel AnimalAdoptionAgency { get; set; }
    }
}