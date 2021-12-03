using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class Exception_notification
	{
		[DisplayName("服務姓名")]
		[Required]
		public string working_name { get; set; }
		public string id { get; set; }

		[DisplayName("事件敘述")]
		[Required]
		public string event_description { get; set; }

		[DisplayName("異常類別")]
		[Required]
		public string exception_class { get; set; }

		[DisplayName("十大指標")]
		[Required]
		public string ten_index { get; set; }

		[DisplayName("時間")]
		[DataType(DataType.Text)]
		public DateTime tim { get; set; }
		public string execution { get; set; }
		public string tracking { get; set; }
		//已完成項目有幾項
	}
}