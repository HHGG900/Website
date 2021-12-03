using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class appeal
	{
	
		[Required]
		public string US_name { get; set; }

	
		[Required]
		public string user_status { get; set; }

		
		[Required]
		public string phone { get; set; }

		
		[Required]
		public string fall_class { get; set; }

		
		[Required]
		public string conten { get; set; }

		
		
		public string pic_one { get; set; }


		
		[Required]
		public string tim { get; set; }

	}
}