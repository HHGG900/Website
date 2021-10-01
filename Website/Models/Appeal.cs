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
		[DisplayName("")]
		[Required]
		public string US_name { get; set; }

		[DisplayName("")]
		[Required]
		public string user_status { get; set; }

		[DisplayName("")]
		[Required]
		public string phone { get; set; }

		[DisplayName("")]
		[Required]
		public string fall_class { get; set; }

		[DisplayName("")]
		[Required]
		public string conten { get; set; }

		[DisplayName("")]
		[Required]
		public string pic_one { get; set; }


		[DisplayName("")]
		[Required]
		public string tim { get; set; }

	}
}