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
		[DisplayName("���u�m�W")]
		[Required]
		public string worker_name { get; set; }

		[DisplayName("��Z�ɶ�")]
		[Required]
		public string arrive_time { get; set; }

		[DisplayName("���Z�ɶ�")]
		[Required]
		public string leave_time { get; set; }

		[DisplayName("���")]
		[Required]
		public string tim { get; set; }

		public string workButton { get; set; }

		public string offworkButton { get; set; }

		public string time1 { get; set; }
		public string time2 { get; set; }
	}
}