using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Website.Models
{
	public class Organization_account
	{
		[DisplayName("Id")]
		[Required]
		public int Id { get; set; }
		[DisplayName("單位名稱")]
		[Required]
		public string unitname { get; set; }

		[DisplayName("單位代碼")]
		[Required]
		public string unitcode { get; set; }

		[DisplayName("帳號")]
		[Required]
		public string name { get; set; }

		[DisplayName("聯絡人姓名")]
		[Required]
		public string nickname { get; set; }

		[DisplayName("連絡電話")]
		[Required]
		public string phone { get; set; }

		[DisplayName("個案狀態")]
		[Required]
		public string status { get; set; }

		[DisplayName("時間")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime? time { get; set; }
	}
}