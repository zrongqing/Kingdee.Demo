using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kingdee.CDP.WebApi.SDK;
using Newtonsoft.Json.Linq;
using System;

namespace Kingdee.CDP.WebApi.SDK.Test.BasicData
{
    [TestClass]

    #region
    //本接口用于实现科目余额表 (GL_RPT_AccountBalance) 的查询报表数据功能 

    public class GL_RPT_AccountBalance
    {
        [TestMethod]
        public void Accountbalance_GetSysReportData()
        {
            var clienter = new K3CloudApi();
            string formId = "GL_RPT_AccountBalance";
            string jsonData = "{\"FieldKeys\": \"FBALANCEID,FBALANCENAME,FACCTTYPE,FACCTGROUP,FDETAILNUMBER,FDETAILNAME,FCyName\",\"SchemeId\": \"97ffa1271acc4846b209ea05ac8dec9c\",\"StartRow\": 0,\"Limit\": 2000,\"IsVerifyBaseDataField\": \"false\",\"Model\": {  \"FACCTBOOKID\": {    \"FNumber\": \"001\"  },  \"FCURRENCY\": \"1\",  \"FSTARTYEAR\": \"2021\",  \"FSTARTPERIOD\": \"12\",  \"FENDYEAR\": \"2021\",  \"FBALANCELEVEL\": \"1\",  \"FENDPERIOD\": \"12\",  \"FFORBIDBALANCE\": true,  \"FBALANCEZERO\": true,  \"FPERIODNOBALANCE\": true,  \"FYEARNOBALANCE\": true},\"PkEntryIds\": []}";
            //科目余额表 (GL_RPT_AccountBalance) 的查询报表
            var resultJson = clienter.GetSysReportData(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
    }

    #endregion
}
