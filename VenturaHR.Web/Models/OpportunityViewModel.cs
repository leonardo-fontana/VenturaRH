using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VenturaHR.Web.Models
{
    public class OpportunityViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public System.DateTime ExpireDate { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        public List<Criterion> Criteria { get { return _criteria; } }

        private List<Criterion> _criteria = new List<Criterion>();

    }

    public class Criterion
    {           
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public short PWD { get; set; }
        [Required]
        public short Weight { get; set; }
    }


}