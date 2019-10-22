using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WebpconModel
    {
        public DateTime? MyDate { get; set; }//申請日期

        public String Number { get; set; }//編號
        public String Side { get; set; }//端
        public String System { get; set; }//系統
        public String Module { get; set; }//模組
        public String Project { get; set; }//作業/功能項目
        public String FProject { get; set; }//執行
        public String AddFunction { get; set; }//新增功能
        public String elsetext { get; set; }//其他文字
        public String Description { get; set; }//詳細敘述

    }
}