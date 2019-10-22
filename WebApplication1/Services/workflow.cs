using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class workflow
    {
        public string test(string account ,string did , Cwma model = null) {
           
            WebReference.WorkflowServiceService ws = new WebReference.WorkflowServiceService();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Textbox9", model.Department);//申請單位
            dic.Add("Textbox10", model.Applicant);//申請人/分機
            dic.Add("Date0",model.MyDate.ToString());//申請日期
            dic.Add("Date1", model.StartDay?.ToString());//刊登時間(始)
            dic.Add("Date2", model.EndDay?.ToString());//刊登時間(末)
            dic.Add("Time12", model.Mytime1?.ToString());//刊登時間(始)
            dic.Add("Time13", model.Mytime2?.ToString());//刊登時間(末)
            dic.Add("Textbox13", model.Purpose);//目的
            dic.Add("Checkbox16", model.ApplicantMatter);//申請事項  ApplicantMatter
            dic.Add("Checkbox17", model.AssistanceMatter);//協助事項 AssistanceMatter
            dic.Add("TextArea1", model.Description);//申請事項說明

            string FormoId = ws.findFormOIDsOfProcess("PKG15459841889111");
            string FormTemplate = ws.getFormFieldTemplate(FormoId);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlReader.Create(new StringReader(FormTemplate)));
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("L1105137216").ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;

                if (dic.ContainsKey(xe.GetAttribute("id")))
                {
                    xe.InnerText = dic[xe.GetAttribute("id")];
                }
            }

            MemoryStream memStream = new MemoryStream(500);
            xmlDoc.Save(memStream);
            string result = Encoding.UTF8.GetString(memStream.ToArray());
            string pid = "";

            pid = ws.invokeProcess("PKG15459841889111", account, did, FormoId, result, "");

            return pid;

        }


        public string Webpconwork(string account ,string did ,Webpcon model = null)
        {
            WebReference.WorkflowServiceService ws = new WebReference.WorkflowServiceService();
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("Date04", model.MyDate.ToString()); //申請日期
            dic.Add("Textbox8", model.Number); //編號
            dic.Add("Checkbox1", model.Side); //端
            dic.Add("Textbox2", model.System); //系統
            dic.Add("Textbox5", model.Module); //模組
            dic.Add("Textbox9", model.Project); //作業/功能項目
            dic.Add("Checkbox2", model.FProject); //
            dic.Add("Checkbox3", model.AddFunction); //新增功能
            dic.Add("Textbox0", model.elsetext); //其他輸入欄位
            dic.Add("TextArea11", model.Description); //詳細敘述

            string FormoId = ws.findFormOIDsOfProcess("PKG15666550428311");//流程編號
            string FormTemplate = ws.getFormFieldTemplate(FormoId);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlReader.Create(new StringReader(FormTemplate)));
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("WebPcon").ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;

                if (dic.ContainsKey(xe.GetAttribute("id")))
                {
                    xe.InnerText = dic[xe.GetAttribute("id")];
                }
            }

            MemoryStream memStream = new MemoryStream(500);
            xmlDoc.Save(memStream);
            string result = Encoding.UTF8.GetString(memStream.ToArray());
            string pid = "";

            pid = ws.invokeProcess("PKG15666550428311", account , did, FormoId, result, "");

            return pid;

        }
    }
}