using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace Kingdee.CDP.WebApi.SDK.Test.BasicData
{
    [TestClass]
    public class BD_Customer
    {
        public static string Number = "BC" + DateTime.Now.ToString("yyMMddHHmmss");
        public static string FName = "kh" + DateTime.Now.ToString("yyMMddHHmmss");
        public static string customerid = "";

        #region 基础管理--基础资料--保存客户
        //本接口用于实现客户 (BD_Customer) 的保存功能
        [TestMethod]
        public void  Acustomer_save()  
        {
            string url = System.Configuration.ConfigurationManager.AppSettings.Get("X-KDApi-ServerUrl");
            if (url == null) {
                url =  "https://api.kingdee.com/galaxyapi/";//默认使用网关
            }
            var clienter = new K3CloudApi(url);
            SaveResult sRet = clienter.Save<Customer>("BD_Customer", new SaveParam<Customer>(
                new Customer() 
                {
                    FCreateOrgId = new OrgBase { FNumber = "100" },
                    FName = FName,
                    FNumber = Number
                }));
            if (sRet.Result.ResponseStatus.IsSuccess) {
                var resultJson = JsonConvert.SerializeObject(sRet.Result);
                var resultJObject = JObject.Parse(resultJson);
                customerid = (string)resultJObject["Id"];
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion

        #region 基础管理--基础资料--提交客户
        //本接口用于实现客户 (BD_Customer) 的提交功能
        [TestMethod]
        public void Bcustomer_submit()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings.Get("X-KDApi-ServerUrl");
            if (url == null)
            {
                url = "https://api.kingdee.com/galaxyapi/";//默认使用网关
            }

            var clienter = new K3CloudApi(url,120);
            OperatorResult sRet = clienter.Submit("BD_Customer", new OperateParam()
            {
                Numbers = new string[1] { Number },
            });
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess,JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion

        #region 基础管理--基础资料--撤销客户
        //本接口用于实现客户 (BD_Customer) 的撤销功能
        [TestMethod]
        public void Ccustomer_CancelAssign()
        {
            var clienter = new K3CloudApi();
            string jsonData = "{\"CreateOrgId\": 0,\"Numbers\": [" + "\"" + Number + "\"" + "],\"Id\": \"\",\"IsSortBySeq\": \"false\"}";
            var resultJson = clienter.CancelAssign("BD_Customer", jsonData);
            var resultJObject = JObject.Parse(resultJson);
            var isSuccess = resultJObject["Result"]["ResponseStatus"]["IsSuccess"];
            if ((bool)isSuccess)
            {
                Console.WriteLine(resultJson);
            };
            Assert.IsTrue((bool)isSuccess, resultJson);
        }
        #endregion

        #region 基础管理--基础资料--提交客户
        //本接口用于实现客户 (BD_Customer) 的提交功能
        [TestMethod]
        public void Dcustomer2_submit()
        {
            var clienter = new K3CloudApi();
            OperatorResult sRet = clienter.Submit("BD_Customer", new OperateParam()
            {
                Numbers = new string[1] { Number },
            });
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion

        #region 基础管理--基础资料--审核客户
        //本接口用于实现客户 (BD_Customer) 的审核功能
        [TestMethod]
        public void Ecustomer_Aduit()
        {
            var clienter = new K3CloudApi();
            OperatorResult sRet = clienter.Audit("BD_Customer", new OperateParam()
            {
                Numbers = new string[1] { Number },
            });
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion

        #region 基础管理--基础资料--分配客户
        //本接口用于实现客户 (BD_Customer) 的分配功能
        [TestMethod]
        public void Fcustomer_Allocate()
        {
            var clienter = new K3CloudApi();
            OperatorResult sRet = clienter.Allocate("BD_Customer", new AllocateParam()
            {
                PkIds = customerid,
                TOrgIds = "100002",

            });
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion

        #region 基础管理--基础资料--取消分配物料
        // 本接口用于实现客户 (BD_Customer)的取消分配功能

        [TestMethod]
        public void Gcustomer_CancelAllocate()
        {
            var clienter = new K3CloudApi();
            string formId = "BD_Customer";
            string jsonData = "{ \"PkIds\": " + customerid + ", \"TOrgIds\": \"100002\"}";
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

        #region 基础管理--基础资料--反审核客户
        //本接口用于实现客户 (BD_Customer) 的反审核功能
        [TestMethod]
        public void Hcustomer_UnAudit()
        {
            var clienter = new K3CloudApi();
            OperatorResult sRet = clienter.UnAudit("BD_Customer", new OperateParam()
            {
                Numbers = new string[1] { Number },
            });
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion

        #region 基础管理--基础资料--查看客户
        //本接口用于实现客户 (BD_Customer) 的查看功能
        [TestMethod]
        public void Icustomer_View()
        {
            var clienter = new K3CloudApi();
            OperatorResult sRet = clienter.View("BD_Customer", new OperateParam()
            {
                Number = Number,
            });
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion


        #region 基础管理--基础资料--单据查询客户table
        //本接口用于实现客户 (BD_Customer) 的单据查询功能
        [TestMethod]
        public void Jcustomer_ExecuteBillQueryToTable()
        {
            var clienter = new K3CloudApi();
            bool result = false;
            try
            {
                var table = clienter.ExecuteBillQueryToTable(new QueryParam()
                {
                    FormId = "BD_Customer",
                    FieldKeys = "FNumber,FName",
                    FilterString = "FNumber='" + Number + "'",
                    Limit = 1000,
                });
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(row[column]);
                    }
                }
                Assert.IsTrue(table?.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(result);
            }
        }
        #endregion


        #region 基础管理--基础资料--单据查询客户
        //本接口用于实现客户 (BD_Customer) 的单据查询功能
        [TestMethod]
        public void Kcustomer_ExecuteBillQuery()
        {
            var clienter = new K3CloudApi();
            List<Customer> response = new List<Customer>();
            var ret = clienter.ExecuteBillQuery<Customer>(new QueryParam()
            {
                FormId = "BD_Customer",
                FieldKeys = "FNumber,FName",
                FilterString = "FNumber='" + Number + "'",
            });
            foreach (Customer cus in ret) {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(cus));
            }
            Assert.IsTrue(ret.Count > 0);
        }
        #endregion

        #region 基础管理--基础资料--删除客户
        //本接口用于实现客户 (BD_Customer) 的删除功能
        [TestMethod]
        public void Lcustomer_Delete()
        {
            var clienter = new K3CloudApi();
            OperatorResult sRet = clienter.Delete("BD_Customer", new OperateParam()
            {
                Numbers = new string[1] { Number },
            });
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion


        #region 基础管理--基础资料--暂存客户
        //本接口用于实现客户 (BD_Customer) 的暂存功能
        [TestMethod]
        public void Mcustomer_Draft()
        {
            var clienter = new K3CloudApi();
            DraftResult sRet = clienter.Draft<Customer>("BD_Customer", new DraftParam<Customer>(
                new Customer()
                {
                    FCreateOrgId = new OrgBase { FNumber = "100" },
                    FName = FName,
                    FNumber = Number
                }));
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion

        #region 基础管理--基础资料--批量保存客户
        //本接口用于实现客户 (BD_Customer) 的批量保存功能
        [TestMethod]
        public void Ncustomer_batchsave()
        {
            var clienter = new K3CloudApi();
            List<Customer> moreCustomer = new List<Customer>();
            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(1000);
                moreCustomer.Add(
                    new Customer()
                    {
                        FCreateOrgId = new OrgBase { FNumber = "100" },
                        FNumber = "BC" + DateTime.Now.ToString("yyMMddHHmmss"),
                        FName = "kh" + DateTime.Now.ToString("yyMMddHHmmss")
                    });
            }
            var sRet = clienter.BatchSave<Customer>("BD_Customer", new BatchSave<Customer>(moreCustomer));
            if (sRet.Result.ResponseStatus.IsSuccess)
            {
                Console.WriteLine(JsonConvert.SerializeObject(sRet.Result));
            }
            Assert.IsTrue(sRet.Result.ResponseStatus.IsSuccess, JsonConvert.SerializeObject(sRet.Result));
        }
        #endregion
    }
}
