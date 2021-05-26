using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class Personnel
	{
		public string edit_data { get; set; }
		
		[DisplayName("�m�W")]
		
		public string name { get; set; }

		[DisplayName("¾�Ȥ@")]
		public string post1 { get; set; }

		[DisplayName("¾�ȤG")]
		public string post2 { get; set; }

        [DisplayName("�ʧO")]
		public string six { get; set; }

		[DisplayName("�嫬")]
		public string blood { get; set; }

		[DisplayName("�X��")]
		public string born { get; set; }

		
        [DisplayName("ñ��")]
		public string signature { get; set; }//�Ϥ�

		[DisplayName("�����Ҧr��")]
		public string ID_number { get; set; }

		[DisplayName("���")]
		public string phone { get; set; }

		[DisplayName("���y")]
		public string census { get; set; }

        [DisplayName("�pô�覡")]
		public string contact { get; set; }

		
		[DisplayName("�����ҥ���")]
		public string identity_card_positive { get; set; }//�Ϥ�

		[DisplayName("�����Ҥϭ�")]
		public string identity_card_rebel { get; set; }//�Ϥ�

		[DisplayName("�̰��Ǿ�")]
		public string education { get; set; }//�Ϥ�

		[DisplayName("�M�~�Ү�")]
		public string professional_license { get; set; }//�Ϥ�

		[DisplayName("CPR�V�m�Ү�")]
		public string CPR_training_certificate { get; set; }//�Ϥ�

		[DisplayName("���Ӥu�@��")]
		public string Long_term_work_permit { get; set; }//�Ϥ�

		[DisplayName("�����ҩ��@")]
		public string related_training1 { get; set; }//�Ϥ�

		[DisplayName("�����ҩ��G")]

		public string related_training2 { get; set; }//�Ϥ�

		[DisplayName("�����ҩ��T")]
		public string related_training3 { get; set; }//�Ϥ�

		[DisplayName("�����ҩ��|")]
		public string related_training4 { get; set; }//�Ϥ�

		[DisplayName("�u�@�������y")]
		public string work_contract_scan { get; set; }//�Ϥ�

	}
}