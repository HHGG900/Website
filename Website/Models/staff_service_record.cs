using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class staff_service_record
	{
		[Required]
		public string year { get; set; }

		[Required]
		public string season { get; set; }

		[Required]
		public string date { get; set; }

		[Required]
		public string location { get; set; }

		
		public string partner { get; set; }

		[Required]
		public string picture1 { get; set; }

    	[Required]
		public string picture2 { get; set; }

         
		[Required]
		public string picture3 { get; set; }


         
		[Required]
		public string picture4 { get; set; }
		
	}
}