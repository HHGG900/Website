using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Website.Models
{
	public class Daycheck
	{
		[DisplayName("照護員單位代號")]
		[Required]
		public string usr_index { get; set; }


		[DisplayName("照護員")]
		[Required]
		public string usr_name { get; set; }

		[DisplayName("量體溫")]
		[Required]
		public string temperature { get; set; }

		[DisplayName("手部清潔")]
		[Required]
		public string Hand { get; set; }

		[DisplayName("戴口罩")]
		[Required]
		public string Mask { get; set; }

		[DisplayName("戴手套")]
		public string Gloves { get; set; }

		[DisplayName("時間")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime tim { get; set; }

		public string offworkButton { get; set; }

		public string workButton { get; set; }
	}
}