using Kingdee.CDP.WebApi.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Kingdee.CDP.WebApi.SDK.Test.BasicData
{
    [TestClass]
    public class BD_MATERIAL
    {
        public static string Number = "WL" + DateTime.Now.ToString("yyMMddHHmmss");
        public static string materid =  "";
        public static string fileid = "";
        public static string groupid = "";
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

        #region 基础管理--基础资料--分配物料
        // 本接口用于实现物料 (BD_MATERIAL) 的分配功能

        [TestMethod]
        public void Dmaterial_Allocate()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{ \"PkIds\": " + materid + ", \"TOrgIds\": \"100002\"}";
            Console.WriteLine(jsonData);
            //调用物料提交接口
            var resultJson = clienter.Allocate(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--取消分配物料
        // 本接口用于实现物料 (BD_MATERIAL) 的取消分配功能

        [TestMethod]
        public void Ematerial_CancelAllocate()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{ \"PkIds\": " + materid + ", \"TOrgIds\": \"100002\"}";
            //调用物料提交接口
            var resultJson = clienter.CancelAllocate(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--反审核物料
        // 本接口用于实现物料 (BD_MATERIAL) 的反审核功能

        [TestMethod]
        public void Fmaterial_unaudit()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"CreateOrgId\": 0,\"Numbers\": [" + "\"" + Number + "\"" + "],\"Ids\": \"\",\"InterationFlags\": \"\",\"NetworkCtrl\": \"\",\"IsVerifyProcInst\": \"\",\"IgnoreInterationFlag\": \"\",\"UseBatControlTimes\": \"false\"}";
            var resultJson = clienter.UnAudit(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--附件上传物料
        // 本接口用于实现物料 (BD_MATERIAL) 的附件上传功能

        [TestMethod]
        public void Gmaterial_AttachmentUpLoad()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"FileName\":\"1016.txt\",\"FEntryKey\":\"\",\"FormId\": \"BD_MATERIAL\",\"IsLast\": true,\"InterId\": " + materid + "," +
                "\"BillNO\": " + "\"" + Number + "\"" + ",\"AliasFileName\": \"test\",\"SendByte\": \"6L+Z5piv5rWL6K+V5paH5Lu25ZKMYmFzZTY05a2X56ym5Liy5LqS6L2s\"}";
            var resultJson = clienter.AttachmentUpLoad(jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
                fileid = (string)resultJObject["Result"]["FileId"];
            };
            Assert.IsTrue((bool)isSuccess);
        }
        #endregion

        #region 基础管理--基础资料--附件下载物料
        // 本接口用于实现物料 (BD_MATERIAL) 的附件下载功能

        [TestMethod]
        public void Hmaterial_AttachmentDownLoad()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"FileId\": " +"\""+ fileid + "\""+", \"StartIndex\": 0}";
            var resultJson = clienter.AttachmentDownLoad(jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--禁用物料
        // 本接口用于实现物料 (BD_MATERIAL) 的禁用功能

        [TestMethod]
        public void Imaterial_Forbid()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"CreateOrgId\": 0,\"Numbers\": [" + "\"" + Number + "\"" + "],\"Ids\": \"\",\"InterationFlags\": \"\",\"NetworkCtrl\": \"\",\"IsVerifyProcInst\": \"\",\"IgnoreInterationFlag\": \"\",\"UseBatControlTimes\": \"false\"}";
            var resultJson = clienter.ExcuteOperation(formId, "Forbid", jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--反禁用物料
        // 本接口用于实现物料 (BD_MATERIAL) 的反禁用功能

        [TestMethod]
        public void Jmaterial_Enable()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"CreateOrgId\": 0,\"Numbers\": [" + "\"" + Number + "\"" + "],\"Ids\": \"\",\"InterationFlags\": \"\",\"NetworkCtrl\": \"\",\"IsVerifyProcInst\": \"\",\"IgnoreInterationFlag\": \"\",\"UseBatControlTimes\": \"false\"}";
            var resultJson = clienter.ExcuteOperation(formId, "Enable", jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--查看物料
        // 本接口用于实现物料 (BD_MATERIAL) 的查看功能

        [TestMethod]
        public void Kmaterial_View()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"CreateOrgId\": 0,\"Number\": " + "\"" + Number + "\"" + ",\"Id\": \"\",\"IsSortBySeq\": \"false\"}";
            var resultJson = clienter.View(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--单据查询物料
        // 本接口用于实现物料 (BD_MATERIAL) 的单据查询功能

        [TestMethod]
        public void Lmaterial_ExecuteBillQuery()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\n" +
                "    \"FormId\": \"BD_Material\",\n" +
                "    \"FieldKeys\": \"FMATERIALID,FNumber,FName,FCreateOrgId,FUseOrgId\",\n" +
                "    \"FilterString\": \"FNumber=\'" + Number + "\'\",\n" +
                "    \"OrderString\": \"\",\n" +
                "    \"TopRowCount\": 0,\n" +
                "    \"StartRow\": 0,\n" +
                "    \"Limit\": 2000,\n" +
                "    \"SubSystemId\": \"\"\n" +
                "}";
            var resultJson = clienter.ExecuteBillQuery(jsonData);
            Console.WriteLine(JsonConvert.SerializeObject(resultJson));
         
        }
        #endregion

        #region 基础管理--基础资料--单据查询物料
        // 本接口用于实现物料 (BD_MATERIAL) 的单据查询(json)功能

        [TestMethod]
        public void Lmaterial_BillQuery()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\n" +
                "    \"FormId\": \"BD_Material\",\n" +
                "    \"FieldKeys\": \"FMATERIALID,FNumber,FName,FCreateOrgId,FUseOrgId\",\n" +
                "    \"FilterString\": \"FNumber=\'" + Number + "\'\",\n" +
                "    \"OrderString\": \"\",\n" +
                "    \"TopRowCount\": 0,\n" +
                "    \"StartRow\": 0,\n" +
                "    \"Limit\": 2000,\n" +
                "    \"SubSystemId\": \"\"\n" +
                "}";
            var resultJson = clienter.BillQuery(jsonData);
            Console.WriteLine(resultJson);

        }
        #endregion

        #region 基础管理--基础资料--删除物料
        // 本接口用于实现物料 (BD_MATERIAL) 的删除功能

        [TestMethod]
        public void Nmaterial_Delete()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"CreateOrgId\": 0,\"Numbers\": [" + "\"" + Number + "\"" + "],\"Id\": \"\",\"IsSortBySeq\": \"false\"}";
            var resultJson = clienter.Delete(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--物料分组保存
        // 本接口用于实现物料 (BD_MATERIAL) 的分组保存功能

        [TestMethod]
        public void Omaterial_GroupSave()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"GroupFieldKey\": \"\", \"GroupPkId\": 0, \"FParentId\": 0, \"FNumber\": " + "\"" + Number + "\"" + ", \"FName\": " + "\"" + Number + "\"" + ", \"FDescription\": \"\"}";
            var resultJson = clienter.GroupSave(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                groupid = (string)resultJObject["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Id"];
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--物料分组查询
        // 本接口用于实现物料 (BD_MATERIAL) 的分组查询功能

        [TestMethod]
        public void Pmaterial_QueryGroupInfo()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"FormId\": \"BD_MATERIAL\", \"GroupFieldKey\": \"FMaterialGroup\", \"GroupPkIds\": " + groupid + ", \"Ids\": \"\"}";
            var resultJson = clienter.QueryGroupInfo(jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--物料分组删除
        // 本接口用于实现物料 (BD_MATERIAL) 的分组删除功能

        [TestMethod]
        public void Qmaterial_GroupDelete()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"FormId\": \"BD_MATERIAL\", \"GroupFieldKey\": \"FMaterialGroup\", \"GroupPkIds\": " + groupid + ",}";
            var resultJson = clienter.GroupDelete(jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--物料切换组织
        // 本接口用于实现物料 (BD_MATERIAL) 的切换组织功能

        [TestMethod]
        public void Rmaterial_SwitchOrg()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"OrgNumber\": \"200\"}";
            string jsonData2 = "{\"OrgNumber\": \"100\"}";
            var resultJson = clienter.SwitchOrg(jsonData);
            var resultJson2 = clienter.SwitchOrg(jsonData2);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--物料发送消息
        // 本接口用于实现物料 (BD_MATERIAL) 的发送消息功能

        [TestMethod]
        public void Smaterial_SendMsg()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"Model\":[{\"FTitle\":\"我是标题\",\"FContent\":\"我是内容\",\"FReceivers\":\"demo\",\"FType\":\"1\"}]}";
            var resultJson = clienter.SendMsg(jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--批量保存物料
        //本接口用于实现物料 (BD_MATERIAL) 的批量保存功能
        [TestMethod]
        public void Tmaterial_BatchSave()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_MATERIAL";
            string jsonData = "{\"NumberSearch\":\"true\",\"ValidateFlag\":\"true\",\"IsDeleteEntry\":\"true\",\"IsEntryBatchFill\":\"true\",\"NeedUpDateFields\":[],\"NeedReturnFields\":[],\"SubSystemId\":\"\",\"InterationFlags\":\"\",\"Model\":[{\"FName\": " + "\"" + Number + "\"" + ",\"FNumber\": " + "\"" + Number + "\"" + ",\"FImgStorageType\": \"A\",\"FCreateOrgId\": {\"FNumber\": \"100\"},\"FUseOrgId\": {\"FNumber\": \"100\"},\"FSubHeadEntity\": {\"FTimeUnit\": \"H\"},\"SubHeadEntity\": {\"FErpClsID\": \"1\",\"FFeatureItem\": \"1\",\"FCategoryID\": {\"FNumber\": \"CHLB01_SYS\"},\"FTaxType\": {\"FNumber\": \"WLDSFL01_SYS\"},\"FTaxRateId\": {\"FNUMBER\": \"SL02_SYS\"},\"FBaseUnitId\": {\"FNumber\": \"Pcs\"},\"FIsPurchase\": true,\"FIsInventory\": true,\"FIsSale\": true,\"FWEIGHTUNITID\": {\"FNUMBER\": \"kg\"},\"FVOLUMEUNITID\": {\"FNUMBER\": \"m\"}},\"SubHeadEntity1\": {\"FStoreUnitID\": {\"FNumber\": \"Pcs\"},\"FUnitConvertDir\": \"1\",\"FIsLockStock\": true,\"FCountCycle\": \"1\",\"FCountDay\": 1,\"FCurrencyId\": {\"FNumber\": \"PRE001\"},\"FSNManageType\": \"1\",\"FSNGenerateTime\": \"1\"},\"SubHeadEntity2\": {\"FSaleUnitId\": {\"FNumber\": \"Pcs\"},\"FSalePriceUnitId\": {\"FNumber\": \"Pcs\"},\"FMaxQty\": 100000,\"FIsReturn\": true,\"FISAFTERSALE\": true,\"FISPRODUCTFILES\": true,\"FWARRANTYUNITID\": \"D\",\"FOutLmtUnit\": \"SAL\"},\"SubHeadEntity3\": {\"FPurchaseUnitId\": {\"FNumber\": \"Pcs\"},\"FPurchasePriceUnitId\": {\"FNumber\": \"Pcs\"},\"FPurchaseOrgId\": {\"FNumber\": \"100\"},\"FQuotaType\": \"1\",\"FIsReturnMaterial\": true,\"FPOBillTypeId\": {\"FNUMBER\": \"CGSQD01_SYS\"},\"FPrintCount\": 1,\"FMinPackCount\": 1},\"SubHeadEntity4\": {\"FPlanningStrategy\": \"1\",\"FMfgPolicyId\": {\"FNumber\": \"ZZCL001_SYS\"},\"FFixLeadTimeType\": \"1\",\"FVarLeadTimeType\": \"1\",\"FCheckLeadTimeType\": \"1\",\"FOrderIntervalTimeType\": \"3\",\"FMaxPOQty\": 100000,\"FEOQ\": 1,\"FVarLeadTimeLotSize\": 1,\"FIsMrpComBill\": true,\"FReserveType\": \"1\",\"FCanDelayDays\": 999,\"FAllowPartDelay\": true,\"FPlanOffsetTimeType\": \"1\",\"FWriteOffQty\": 1},\"SubHeadEntity5\": {\"FProduceUnitId\": {\"FNumber\": \"Pcs\"},\"FProduceBillType\": {\"FNUMBER\": \"SCDD03_SYS\"},\"FOrgTrustBillType\": {\"FNUMBER\": \"SCDD06_SYS\"},\"FBOMUnitId\": {\"FNumber\": \"Pcs\"},\"FIssueType\": \"1\",\"FOverControlMode\": \"1\",\"FMinIssueQty\": 1,\"FMinIssueUnitId\": {\"FNUMBER\": \"Pcs\"},\"FStandHourUnitId\": \"3600\",\"FBackFlushType\": \"1\"},\"SubHeadEntity7\": {\"FSubconUnitId\": {\"FNumber\": \"Pcs\"},\"FSubconPriceUnitId\": {\"FNumber\": \"Pcs\"},\"FSubBillType\": {\"FNUMBER\": \"WWDD01_SYS\"}},\"FEntityInvPty\": [{\"FInvPtyId\": {\"FNumber\": \"01\"},\"FIsEnable\": true},{\"FInvPtyId\": {\"FNumber\": \"02\"},\"FIsEnable\": true},{\"FInvPtyId\": {\"FNumber\": \"03\"}},{\"FInvPtyId\": {\"FNumber\": \"04\"}},{\"FInvPtyId\": {\"FNumber\": \"06\"}}]}],\"BatchCount\":\"1\",\"IsVerifyBaseDataField\":\"false\",\"IsAutoAdjustField\":\"false\",\"IgnoreInterationFlag\":\"false\",\"IsControlPrecision\":\"false\",\"ValidateRepeatJson\":\"false\"}";
            var resultJson = clienter.BatchSave(formId, jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                 Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--元数据查询
        //本接口用于实现物料 (BD_MATERIAL) 的元数据查询功能
        [TestMethod]
        public void Umaterial_QueryBusinessInfo()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"FormId\":\"BD_MATERIAL\"}";
            var resultJson = clienter.QueryBusinessInfo(jsonData);
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
