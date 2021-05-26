using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class Assessment
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string year { get; set; }

        [Required]
        public string one { get; set; }

        [Required]
        public string two { get; set; }

        [Required]
        public string there { get; set; }

        [Required]
        public string four { get; set; }

        [Required]
        public string five { get; set; }

        [Required]
        public string six { get; set; }

        [Required]
        public string seven { get; set; }

        [Required]
        public string eight { get; set; }

        [Required]
        public string nine { get; set; }

        [Required]
        public string ten { get; set; }

        [Required]
        public string eleven { get; set; }

        [Required]
        public string twelve { get; set; }

        [Required]
        public string thirteen { get; set; }

        [Required]
        public string fourteen { get; set; }

        [Required]
        public string fifteen { get; set; }

        [Required]
        public string sixteen { get; set; }

        [Required]
        public string seventeen { get; set; }

        [Required]
        public string eighteen { get; set; }

        [Required]
        public string nineteen { get; set; }

        [Required]
        public string twenty { get; set; }

        [Required]
        public string twentyone { get; set; }

        [Required]
        public string twentytwo { get; set; }

        [Required]
        public string twentythere { get; set; }

        [Required]
        public string twentyfour { get; set; }

        [Required]
        public string twentyfive { get; set; }

        
        public float total { get; set; }

        public int gettotal { get; set; }

        public string pic { get; set; }
        public string grade { get; set; }
        public string rewards { get; set; }

        public string tim { get; set; }
    }
}