using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class worker_arrive
	{
		[DisplayName("員工姓名")]
		[Required]
		public string worker_name { get; set; }

		[DisplayName("到班時間")]
		[Required]
		public string arrive_time { get; set; }

		[DisplayName("離班時間")]
		[Required]
		public string leave_time { get; set; }

		[DisplayName("日期")]
		[Required]
		public string tim { get; set; }

		public string workButton { get; set; }

		public string offworkButton { get; set; }

		public string time1 { get; set; }
		public string time2 { get; set; }
	}
}