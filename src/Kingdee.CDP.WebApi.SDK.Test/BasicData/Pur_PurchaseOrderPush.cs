using Kingdee.CDP.WebApi.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace Kingdee.CDP.WebApi.SDK.Test.BasicData
{
    [TestClass]
    public class Pur_PurchaseOrderPush
    {
        public static string Number = "CGDD" + DateTime.Now.ToString("yyMMddHHmmss");
        public static string chaseorderid = "";


        #region 供应链--采购管理--保存采购订单
        //本接口用于实现采购订单 (PUR_PurchaseOrder) 的保存功能
        [TestMethod]
        public void Apurchaseorder_save()
        {
            var clienter = new K3CloudApi();
            string formId = "PUR_PurchaseOrder";
            string jsonData = "{\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"IsAutoAdjustField\": \"false\",\"InterationFlags\": \"\",\"IgnoreInterationFlag\": \"\",\"Model\": {\"FBillTypeID\": {\"FNUMBER\": \"CGDD01_SYS\"},\"FDate\": \"2022-04-25 00:00:00\",\"FSupplierId\": {\"FNumber\": \"SCMGYS000002\"},\"FPurchaseOrgId\": {\"FNumber\": \"100\"},\"FPurchaseDeptId\": {\"FNumber\": \"FINBM000200\"},\"FPurchaserGroupId\": {\"FNumber\": \"FINYWZ000203\"},\"FPurchaserId\": {\"FNumber\": \"FINYG000202\"},\"FProviderId\": {\"FNumber\": \"SCMGYS000002\"},\"FSettleId\": {\"FNumber\": \"SCMGYS000002\"},\"FChargeId\": {\"FNumber\": \"SCMGYS000002\"},\"FChangeStatus\": \"A\",\"FACCTYPE\": \"Q\",\"FPOOrderFinance\": {\"FSettleModeId\": {\"FNumber\": \"JSFS01_SYS\"},\"FPayConditionId\": {\"FNumber\": \"FKTJ01_SYS\"},\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"},\"FExchangeRate\": 1,\"FPriceTimePoint\": \"1\",\"FFOCUSSETTLEORGID\": {\"FNumber\": \"100\"},\"FIsIncludedTax\": true,\"FISPRICEEXCLUDETAX\": true,\"FLocalCurrId\": {\"FNumber\": \"PRE001\"},\"FSupToOderExchangeBusRate\": 1},\"FPOOrderEntry\": [{\"FProductType\": \"1\",\"FMaterialId\": {\"FNumber\": \"SCMWL000012\"},\"FMaterialDesc\": \"SCMWL000012采购(可退物料)\",\"FUnitId\": {\"FNumber\": \"Pcs\"},\"FQty\": 6,\"FPriceUnitId\": {\"FNumber\": \"Pcs\"},\"FPriceUnitQty\": 6,\"FPriceBaseQty\": 6,\"FDeliveryDate\": \"2022-04-25 15:03:00\",\"FPrice\": 796.460177,\"FTaxPrice\": 900,\"FEntryTaxRate\": 13,\"FRequireOrgId\": {\"FNumber\": \"100\"},\"FRequireDeptId\": {\"FNumber\": \"SCMBM000001\"},\"FReceiveOrgId\": {\"FNumber\": \"100\"},\"FEntrySettleOrgId\": {\"FNumber\": \"100\"},\"FStockUnitID\": {\"FNumber\": \"Pcs\"},\"FStockQty\": 6,\"FStockBaseQty\": 6,\"FSupplierLot\": \"11111111111\",\"FDeliveryMaxQty\": 6,\"FDeliveryMinQty\": 6,\"FDeliveryEarlyDate\": \"2022-04-25 15:03:00\",\"FDeliveryLastDate\": \"2022-04-25 15:03:00\",\"FPriceCoefficient\": 1,\"FEntrySettleModeId\": {\"FNumber\": \"JSFS01_SYS\"},\"FReqTraceNo\": \"1111111111\",\"FPlanConfirm\": true,\"FSalUnitID\": {\"FNumber\": \"Pcs\"},\"FSalQty\": 6,\"FCentSettleOrgId\": {\"FNumber\": \"100\"},\"FDispSettleOrgId\": {\"FNumber\": \"100\"},\"FDeliveryStockStatus\": {\"FNumber\": \"KCZT02_SYS\"},\"FSalBaseQty\": 6,\"FEntryPayOrgId\": {\"FNumber\": \"100\"},\"FAllAmountExceptDisCount\": 5400,\"FEntryDeliveryPlan\": [{\"FDeliveryDate_Plan\": \"2022-04-25 15:03:00\",\"FPlanQty\": 6,\"FPREARRIVALDATE\": \"2022-04-25 15:03:00\"}]},{\"FProductType\": \"1\",\"FMaterialId\": {\"FNumber\": \"SCMWL000012\"},\"FMaterialDesc\": \"SCMWL000012采购(可退物料)\",\"FUnitId\": {\"FNumber\": \"Pcs\"},\"FQty\": 6,\"FPriceUnitId\": {\"FNumber\": \"Pcs\"},\"FPriceUnitQty\": 6,\"FPriceBaseQty\": 6,\"FDeliveryDate\": \"2022-04-25 15:03:18\",\"FPrice\": 796.460177,\"FTaxPrice\": 900,\"FEntryTaxRate\": 13,\"FRequireOrgId\": {\"FNumber\": \"100\"},\"FReceiveOrgId\": {\"FNumber\": \"100\"},\"FEntrySettleOrgId\": {\"FNumber\": \"100\"},\"FStockUnitID\": {\"FNumber\": \"Pcs\"},\"FStockQty\": 6,\"FStockBaseQty\": 6,\"FDeliveryMaxQty\": 6,\"FDeliveryMinQty\": 6,\"FDeliveryEarlyDate\": \"2022-04-25 15:03:18\",\"FDeliveryLastDate\": \"2022-04-25 15:03:18\",\"FPriceCoefficient\": 1,\"FEntrySettleModeId\": {\"FNumber\": \"JSFS01_SYS\"},\"FPlanConfirm\": true,\"FSalUnitID\": {\"FNumber\": \"Pcs\"},\"FSalQty\": 6,\"FCentSettleOrgId\": {\"FNumber\": \"100\"},\"FDispSettleOrgId\": {\"FNumber\": \"100\"},\"FDeliveryStockStatus\": {\"FNumber\": \"KCZT02_SYS\"},\"FSalBaseQty\": 6,\"FEntryPayOrgId\": {\"FNumber\": \"100\"},\"FAllAmountExceptDisCount\": 5400,\"FEntryDeliveryPlan\": [{\"FDeliveryDate_Plan\": \"2022-04-25 15:03:18\",\"FPlanQty\": 6,\"FSUPPLIERDELIVERYDATE\": \"2022-04-25 15:03:18\",\"FPREARRIVALDATE\": \"2022-04-25 15:03:18\"}]}],\"FIinstallment\": [{\"FYFRATIO\": 100,\"FYFAMOUNT\": 10800}],\"FBillNo\": " + "\"" + Number + "\"" + ",},\"TargetFormId\": \"0\"}";
            var resultJson = clienter.Save(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                chaseorderid = (string)resultJObject["Result"]["Id"];
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 供应链--采购管理--提交采购订单
        //本接口用于实现采购订单 (PUR_PurchaseOrder) 的提交功能

        [TestMethod]
        public void Bpurchaseorder_submit()
        {
            var clienter = new K3CloudApi();
            string formId = "PUR_PurchaseOrder";
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

        #region 供应链--采购管理--审核采购订单
        // 本接口用于实现采购订单 (PUR_PurchaseOrder) 的审核功能

        [TestMethod]
        public void Cpurchaseorder_audit()
        {
            var clienter = new K3CloudApi();
            string formId = "PUR_PurchaseOrder";
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

        #region 供应链--采购管理--审核采购订单
        // 本接口用于实现采购订单 (PUR_PurchaseOrder)下推采购订单变更单(PUR_POChange)的功能

        [TestMethod]
        public void DpurchaseorderPushPochange_push()
        {
            var clienter = new K3CloudApi();
            string formId = "PUR_PurchaseOrder";
            string jsonData = "{\"Ids\": " + "\"" + chaseorderid + "\"" + ",\"Numbers\": [],\"EntryIds\": \"\",\"RuleId\": \"PUR_PurchaseOrder-PUR_POChange\",\"TargetBillTypeId\": \"d588ab5aeb23490aadbb665874b1eabf\",\"TargetOrgId\": 0,\"TargetFormId\": \"PUR_POChange\",\"IsEnableDefaultRule\": false,\"IsDraftWhenSaveFail\": true,\"CustomParams\": {}}";
            var resultJson = clienter.Push(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion
    }
}
