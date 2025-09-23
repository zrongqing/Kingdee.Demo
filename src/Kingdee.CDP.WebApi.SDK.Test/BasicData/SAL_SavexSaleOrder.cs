using Kingdee.CDP.WebApi.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace Kingdee.CDP.WebApi.SDK.Test.BasicData
{
    [TestClass]
    public class SAL_SavexSaleOrder
    {
        public static string Number = "XSDD" + DateTime.Now.ToString("yyMMddHHmmss");
        public static string saleid = "";

        #region 供应链--销售管理--保存销售订单 
        //本接口用于实现销售订单  (SAL_SaleOrder) 的保存功能
        [TestMethod]
        public void AsaleOrder_save()
        {
            var clienter = new K3CloudApi();
            string formId = "SAL_SaleOrder";
            string jsonData = "{\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"False\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"IsAutoAdjustField\": \"False\",\"InterationFlags\": \"\",\"IgnoreInterationFlag\": \"\",\"IsControlPrecision\": \"False\",\"Model\": {\"FBillTypeID\": {\"FNUMBER\": \"XSDD01_SYS\"},\"FDate\": \"2022-04-27 00:00:00\",\"FSaleOrgId\": {\"FNumber\": \"100\"},\"FCustId\": {\"FNumber\": \"SCMKH100001\"},\"FReceiveId\": {\"FNumber\": \"SCMKH100001\"},\"FSaleDeptId\": {\"FNumber\": \"SCMBM000001\"},\"FSalerId\": {\"FNumber\": \"SCMYG000001_SCMGW000001_1\"},\"FSettleId\": {\"FNumber\": \"SCMKH100001\"},\"FChargeId\": {\"FNumber\": \"SCMKH100001\"},\"FSaleOrderFinance\": {\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FIsPriceExcludeTax\": 'true',\"FIsIncludedTax\": 'true',\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"}},\"FSaleOrderEntry\": [{\"FRowType\": \"Standard\",\"FMaterialId\": {\"FNumber\": \"SCMWL100002\"},\"FUnitID\": {\"FNumber\": \"Pcs\"},\"FQty\": 10,\"FPriceUnitId\": {\"FNumber\": \"Pcs\"},\"FPrice\": 8.849558,\"FTaxPrice\": 10,\"FEntryTaxRate\": 13,\"FDeliveryDate\": \"2022-04-27 15:15:54\",\"FStockOrgId\": {\"FNumber\": \"100\"},\"FSettleOrgIds\": {\"FNumber\": \"100\"},\"FSupplyOrgId\": {\"FNumber\": \"100\"},\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FOwnerId\": {\"FNumber\": \"100\"},\"FReserveType\": \"1\",\"FPriceBaseQty\": 10,\"FStockUnitID\": {\"FNumber\": \"Pcs\"},\"FStockQty\": 10,\"FStockBaseQty\": 10,\"FOUTLMTUNIT\": \"SAL\",\"FOutLmtUnitID\": {\"FNumber\": \"Pcs\"},\"FAllAmountExceptDisCount\": 100,\"FOrderEntryPlan\": [{\"FPlanDate\": \"2022-04-27 15:15:54\",\"FPlanQty\": 10}]}],\"FSaleOrderPlan\": [{\"FRecAdvanceRate\": 100,\"FRecAdvanceAmount\": 100}],\"FBillNo\":" + "\"" + Number + "\"" + ",}}";
            var resultJson = clienter.Save(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                saleid = (string)resultJObject["Result"]["Id"];
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 供应链--销售管理--提交销售订单 
        //本接口用于实现销售订单  (SAL_SaleOrder) 的提交功能

        [TestMethod]
        public void BsaleOrder_submit()
        {
            var clienter = new K3CloudApi();
            string formId = "SAL_SaleOrder";
            string jsonData = "{\"CreateOrgId\":0,\"Numbers\":[" + "\"" + Number + "\"" + "],\"Ids\":\"\",\"SelectedPostId\":0,\"NetworkCtrl\":\"\",\"IgnoreInterationFlag\":\"\"}";
            var resultJson = clienter.Submit(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 供应链--销售管理--审核销售订单 
        // 本接口用于实现销售订单  (SAL_SaleOrder) 的审核功能

        [TestMethod]
        public void CsaleOrder_audit()
        {
            var clienter = new K3CloudApi();
            string formId = "SAL_SaleOrder";
            string jsonData = "{\"CreateOrgId\": 0,\"Numbers\": [" + "\"" + Number + "\"" + "],\"Ids\": \"\",\"InterationFlags\": \"\",\"NetworkCtrl\": \"\",\"IsVerifyProcInst\": \"\",\"IgnoreInterationFlag\": \"\",\"UseBatControlTimes\": \"false\"}";
            var resultJson = clienter.Audit(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 供应链--销售管理--自定义接口销售订单新变更单 
        // 本接口用于实现自定义接口销售订单新变更单

        [TestMethod]
        public void DxsaleOrder_save()
        {
            var clienter = new K3CloudApi();
            var  testResult = clienter.View("SAL_SaleOrder", "{\"CreateOrgId\": 0,\"Number\": " + "\"" + Number + "\"" + ",\"Id\": \"\",\"IsSortBySeq\": \"false\"}");
            string requestUrl = "Kingdee.K3.SCM.WebApi.ServicesStub.SaveXSaleOrderWebApi.SaveXSaleOrder";
            object[] paramInfo = new object[] { "{\"SaleOrderBillNo\": " + "\"" + Number + "\"" + ",\"SaleOrderBillId\":" + saleid + ",}" };
            var resultJson = clienter.Execute<string>(requestUrl, paramInfo);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);

        }
        #endregion
    }
}
