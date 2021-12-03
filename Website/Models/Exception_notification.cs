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
		[DisplayName("�A�ȩm�W")]
		[Required]
		public string working_name { get; set; }
		public string id { get; set; }

		[DisplayName("�ƥ�ԭz")]
		[Required]
		public string event_description { get; set; }

		[DisplayName("���`���O")]
		[Required]
		public string exception_class { get; set; }

		[DisplayName("�Q�j����")]
		[Required]
		public string ten_index { get; set; }

		[DisplayName("�ɶ�")]
		[DataType(DataType.Text)]
		public DateTime tim { get; set; }
		public string execution { get; set; }
		public string tracking { get; set; }
		//�w�������ئ��X��
	}
}