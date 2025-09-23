using Kingdee.CDP.WebApi.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace Kingdee.CDP.WebApi.SDK.Test.BasicData
{
    [TestClass]
    public class BD_MATERIAL_FLEX
    {
        public static string Number = "WL" + DateTime.Now.ToString("yyMMddHHmmss");
        public static string materid = "";
        #region 基础管理--基础资料--保存物料
        //本接口用于实现物料 (BD_MATERIAL) 的保存功能
        [TestMethod]
        public void Amaterial_save()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"IsAutoAdjustField\": \"false\",\"InterationFlags\": \"\",\"IgnoreInterationFlag\": \"\",\"IsControlPrecision\": \"false\",\"ValidateRepeatJson\": \"false\",\"Model\": {\"FName\": " + "\"" + Number + "\"" + ",\"FNumber\": " + "\"" + Number + "\"" + ",\"FImgStorageType\": \"A\",\"FCreateOrgId\": {\"FNumber\": \"100\"},\"FUseOrgId\": {\"FNumber\": \"100\"},\"FSubHeadEntity\": {\"FTimeUnit\": \"H\"},\"SubHeadEntity\": {\"FErpClsID\": \"1\",\"FFeatureItem\": \"1\",\"FCategoryID\": {\"FNumber\": \"CHLB01_SYS\"},\"FTaxType\": {\"FNumber\": \"WLDSFL01_SYS\"},\"FTaxRateId\": {\"FNUMBER\": \"SL02_SYS\"},\"FBaseUnitId\": {\"FNumber\": \"Pcs\"},\"FIsPurchase\": true,\"FIsInventory\": true,\"FIsSale\": true,\"FWEIGHTUNITID\": {\"FNUMBER\": \"kg\"},\"FVOLUMEUNITID\": {\"FNUMBER\": \"m\"}},\"SubHeadEntity1\": {\"FStoreUnitID\": {\"FNumber\": \"Pcs\"},\"FUnitConvertDir\": \"1\",\"FIsLockStock\": true,\"FCountCycle\": \"1\",\"FCountDay\": 1,\"FCurrencyId\": {\"FNumber\": \"PRE001\"},\"FSNManageType\": \"1\",\"FSNGenerateTime\": \"1\"},\"SubHeadEntity2\": {\"FSaleUnitId\": {\"FNumber\": \"Pcs\"},\"FSalePriceUnitId\": {\"FNumber\": \"Pcs\"},\"FMaxQty\": 100000,\"FIsReturn\": true,\"FISAFTERSALE\": true,\"FISPRODUCTFILES\": true,\"FWARRANTYUNITID\": \"D\",\"FOutLmtUnit\": \"SAL\"},\"SubHeadEntity3\": {\"FPurchaseUnitId\": {\"FNumber\": \"Pcs\"},\"FPurchasePriceUnitId\": {\"FNumber\": \"Pcs\"},\"FPurchaseOrgId\": {\"FNumber\": \"100\"},\"FQuotaType\": \"1\",\"FIsReturnMaterial\": true,\"FPOBillTypeId\": {\"FNUMBER\": \"CGSQD01_SYS\"},\"FPrintCount\": 1,\"FMinPackCount\": 1},\"SubHeadEntity4\": {\"FPlanningStrategy\": \"1\",\"FMfgPolicyId\": {\"FNumber\": \"ZZCL001_SYS\"},\"FFixLeadTimeType\": \"1\",\"FVarLeadTimeType\": \"1\",\"FCheckLeadTimeType\": \"1\",\"FOrderIntervalTimeType\": \"3\",\"FMaxPOQty\": 100000,\"FEOQ\": 1,\"FVarLeadTimeLotSize\": 1,\"FIsMrpComBill\": true,\"FReserveType\": \"1\",\"FCanDelayDays\": 999,\"FAllowPartDelay\": true,\"FPlanOffsetTimeType\": \"1\",\"FWriteOffQty\": 1},\"SubHeadEntity5\": {\"FProduceUnitId\": {\"FNumber\": \"Pcs\"},\"FProduceBillType\": {\"FNUMBER\": \"SCDD03_SYS\"},\"FOrgTrustBillType\": {\"FNUMBER\": \"SCDD06_SYS\"},\"FBOMUnitId\": {\"FNumber\": \"Pcs\"},\"FIssueType\": \"1\",\"FOverControlMode\": \"1\",\"FMinIssueQty\": 1,\"FMinIssueUnitId\": {\"FNUMBER\": \"Pcs\"},\"FStandHourUnitId\": \"3600\",\"FBackFlushType\": \"1\"},\"SubHeadEntity7\": {\"FSubconUnitId\": {\"FNumber\": \"Pcs\"},\"FSubconPriceUnitId\": {\"FNumber\": \"Pcs\"},\"FSubBillType\": {\"FNUMBER\": \"WWDD01_SYS\"}},\"FEntityInvPty\": [{\"FInvPtyId\": {\"FNumber\": \"01\"},\"FIsEnable\": true},{\"FInvPtyId\": {\"FNumber\": \"02\"},\"FIsEnable\": true},{\"FInvPtyId\": {\"FNumber\": \"03\"}},{\"FInvPtyId\": {\"FNumber\": \"04\"}},{\"FInvPtyId\": {\"FNumber\": \"06\"}}]}}";
            var resultJson = clienter.Save(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                materid = (string)resultJObject["Result"]["Id"];
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--提交物料
        //本接口用于实现物料 (BD_MATERIAL) 的提交功能

        [TestMethod]
        public void Bmaterial_submit()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
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

        #region 基础管理--基础资料--审核物料
        // 本接口用于实现物料 (BD_MATERIAL) 的审核功能

        [TestMethod]
        public void Cmaterial_audit()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"CreateOrgId\": 0,\"Numbers\": [" + "\"" + Number + "\"" + "],\"Ids\": \"\",\"InterationFlags\": \"\",\"NetworkCtrl\": \"\",\"IsVerifyProcInst\": \"\",\"IgnoreInterationFlag\": \"\",\"UseBatControlTimes\": \"false\"}";
            //调用物料提交接口
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

        #region 基础管理--基础资料--弹性域保存物料
        // 本接口用于实现物料 (BD_MATERIAL) 的弹性域保存功能

        [TestMethod]
        public void Dmaterial_FlexSave()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_FLEXITEMDETAILV";
            string jsonData = "{\"Model\":[{\"FFLEX8\":{\"FNumber\": " + "\"" + Number + "\"" + "}}]}";
            var resultJson = clienter.FlexSave(formId, jsonData);
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
