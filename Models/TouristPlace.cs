using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ex19.Models
{
    public class TouristPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TouristPlaceId { get; set; }
        [Required]
        public string TouristPlaceName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location {  get; set; }
        
        public bool Status {  get; set; }
        [Required]
        public string MoreInfo { get; set; }
        
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Files { get; set; }
    }
}