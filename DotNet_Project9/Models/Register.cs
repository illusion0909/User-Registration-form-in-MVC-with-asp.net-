using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DotNet_Project9.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public GenderType Gender { get; set; }
        public bool Subscribe { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }
        public City City { get; set; }
        [NotMapped]
        [Display(Name = "State")]
        public int StateId { get; set; }
        [NotMapped]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
    }
}