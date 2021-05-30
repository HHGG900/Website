using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Website.Models
{
	public class case_information
	{
		public string name { get; set; }
		public string six { get; set; }  //性別
		public string birthday { get; set; }	//生日
		public string identity { get; set; }	//身分證
		public string telephone { get; set; }	//電話
		public string economic { get; set; }	//經濟
		public string obstacleclass { get; set; }	//障礙類別
		public string obstacledegree { get; set; }	//障礙程度
		public string contact { get; set; }	//聯絡人
		public string phone { get; set; }	//手機
		public string notedate { get; set; }	//照會日期
		public string CMS { get; set; }	//CMS等級
		public string BA1project { get; set; }
		public string BA2project { get; set; }
		public string BA3project { get; set; }
		public string BA4project { get; set; }
		public string BA5poject { get; set; }
		public string BA6project { get; set; }
		public string BA7project { get; set; }
		public string BA8project { get; set; }
		public string BA9project { get; set; }
		public string BA10project { get; set; }
		public string BA1amount { get; set; }
		public string BA2amount { get; set; }
		public string BA3amount { get; set; }
		public string BA4amount { get; set; }
		public string BA5amount { get; set; }
		public string BA6amount { get; set; }
		public string BA7amount { get; set; }
		public string BA8amount { get; set; }
		public string BA9amount { get; set; }
		public string BA10amount { get; set; }
		public string nateunit { get; set; }    //照會單位
		public string waiter { get; set; }
		public string status { get; set; }	//服務員別
		public string no_service_reason { get; set; }	//無服務緣由
		public string no_service_date { get; set; }	//無服務日期
		
	}
}