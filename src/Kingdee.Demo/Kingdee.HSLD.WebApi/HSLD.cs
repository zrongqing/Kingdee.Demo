using System.Text;
using Kingdee.CDP.WebApi.SDK;
using Kingdee.HSLD.WebApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kingdee.HSLD.WebApi
{
    [TestClass]
    public class HSLD
    {
        [TestMethod]
        public void Test_Connect()
        {
            var clienter = new K3CloudApi();
            StringBuilder error = new StringBuilder();
            RepoResult reporesult = clienter.CheckAuthInfo();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);
        }

        /// <summary>
        /// 获取所有的项目名字
        /// </summary>
        [TestMethod]
        public void Test_BillQuery_PUZH_Project()
        {
            var clienter = new K3CloudApi();
            RepoResult reporesult = clienter.CheckAuthInfo();
            StringBuilder error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);

            var billQuery = new BillQuery();
            billQuery.FormId = "PUZH_Project";
            billQuery.FieldKeys = "FName,FNumber";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);
        }

        /// <summary>
        /// 获取生产订单
        /// </summary>
        [TestMethod]
        public void Test_BillQuery_PRD_MO()
        {
            var clienter = new K3CloudApi();
            RepoResult reporesult = clienter.CheckAuthInfo();
            StringBuilder error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);

            var billQuery = new BillQuery();
            billQuery.FormId = "PRD_MO";
            billQuery.FieldKeys = "FID,FBillNo,FDate";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);
        }

        /// <summary>
        /// 获取物料
        /// </summary>
        [TestMethod]
        public void Test_BillQuery_BD_MATERIAL()
        {
            var clienter = new K3CloudApi();
            RepoResult reporesult = clienter.CheckAuthInfo();
            StringBuilder error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);
            
            var billQuery = new BillQuery();
            billQuery.FormId = "BD_MATERIAL";
            billQuery.FieldKeys = "FName,FNumber,FMaterialGroup";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);
        }
        
        /// <summary>
        /// 产品配置
        /// </summary>
        /// <remarks>
        /// Bom配置
        /// </remarks>
        [TestMethod]
        public void Test_BillQuery_ENG_BOMCONFIG()
        {
            var clienter = new K3CloudApi();
            RepoResult reporesult = clienter.CheckAuthInfo();
            StringBuilder error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);

            var billQuery = new BillQuery();
            billQuery.FormId = "ENG_BOMCONFIG";
            billQuery.FieldKeys = "FName,FNumber,FBOMCATEGORY,FBOMUSE,FMATERIALID,FITEMNAME,FITEMMODEL,FITEMPPROPERTY";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);
        }

        /// <summary>
        /// PLM文档审核流程单据
        /// </summary>
        [TestMethod]
        public void Test_PLM_WF_DOCUMENTBILL()
        {
            var clienter = new K3CloudApi();
            RepoResult reporesult = clienter.CheckAuthInfo();
            StringBuilder error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);

            var billQuery = new BillQuery();
            billQuery.FormId = "PLM_WF_DOCUMENTBILL";
            billQuery.FieldKeys = "FBillNo,FBillNoName";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);
            
            // FBillNo 2024.09.25-1 100013
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Test_FA_CARD()
        {
            var clienter = new K3CloudApi();
            var reporesult = clienter.CheckAuthInfo();
            var error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);

            var billQuery = new BillQuery();
            billQuery.FormId = "FA_CARD";
            billQuery.FieldKeys = "FAlterID,FName,FAssetNO";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);

            var lookQuery = new LookQuery();
            lookQuery.Id = "102690";
            var lookJson = clienter.View("FA_CARD", JsonConvert.SerializeObject(lookQuery));
            Console.WriteLine("查询数据：" + lookJson);
        }

        /// <summary>
        /// 供应链-采购管理-采购入库单
        /// </summary>
        /// <remarks>
        /// 先查单据，再查看单据中的详细信息
        /// </remarks>
        [TestMethod]
        public void Test_STK_InStock()
        {
            var clienter = new K3CloudApi();
            var reporesult = clienter.CheckAuthInfo();
            var error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);

            var billQuery = new BillQuery();
            billQuery.FormId = "STK_InStock";
            billQuery.FieldKeys = "FBillNo,FDate,FBillTypeID";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);

            var lookQuery = new LookQuery();
            // lookQuery.Id = "102690";
            lookQuery.Number = "RKD231227008055";
            var lookJson = clienter.View("STK_InStock", JsonConvert.SerializeObject(lookQuery));
            Console.WriteLine("查询数据：" + lookJson);
        }
        
        /// <summary>
        /// 供应链-采购管理-采购订单
        /// </summary>
        [TestMethod]
        public void Test()
        {
            var clienter = new K3CloudApi();
            var reporesult = clienter.CheckAuthInfo();
            var error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);

            var billQuery = new BillQuery();
            billQuery.FormId = "PUR_PurchaseOrder";
            billQuery.FieldKeys = "FBillNo,FDocumentStatus,FDate,F_temTypeA";
            var resultJson = clienter.ExecuteBillQuery(JsonConvert.SerializeObject(billQuery));
            Console.WriteLine("查询数据："+resultJson);

            var lookQuery = new LookQuery();
            // lookQuery.Id = "102690";
            lookQuery.Number = "YTHS-CG2312-084";
            var lookJson = clienter.View("PUR_PurchaseOrder", JsonConvert.SerializeObject(lookQuery));
            Console.WriteLine("查询数据：" + lookJson);
        }

        
        [TestMethod]
        public void Test_AttachmentUpload()
        {
            var clienter = new K3CloudApi();
            RepoResult reporesult = clienter.CheckAuthInfo();
            StringBuilder error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);
            
            var fileUpload = new FileUpload2();
            fileUpload.FileName = "0616.txt";
            fileUpload.IsLast = true;
            fileUpload.SendByte = "77u/MTIzNA==";

            var resultJson = clienter.SendMsg(JsonConvert.SerializeObject(fileUpload));
            Console.WriteLine("附件上传：" + resultJson);
        }
        
        [TestMethod]
        public void Test_AttachmentDownLoad()
        {
            var clienter = new K3CloudApi();
            RepoResult reporesult = clienter.CheckAuthInfo();
            StringBuilder error = new StringBuilder();
            Assert.IsTrue(reporesult.ResponseStatus.IsSuccess);
            
            var fileid = "c7be8e41c0d64ee1b1f56f32f1ec6e8c";
            var param = JObject.Parse("{\"FileId\": " + "\"" + fileid + "\"" + ", \"StartIndex\": 0}");
            var resultJson = clienter.AttachmentDownLoad(JsonConvert.SerializeObject(param));
            Console.WriteLine("物料附件下载接口：" + resultJson);
        }
  
    }
}
