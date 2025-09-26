using Newtonsoft.Json;

namespace Kingdee.HSLD.WebApi.Model;

public class FileUpload
{
    [JsonProperty("AliasFileName")]
    public string AliasFileName { get; set; }

    [JsonProperty("BillNO")]
    public string BillNo { get; set; }

    [JsonProperty("FileName")]
    public string FileName { get; set; }

    [JsonProperty("FormId")]
    public string FormId { get; set; }

    [JsonProperty("InterId")]
    public string InterId { get; set; }

    [JsonProperty("IsLast")]
    public bool IsLast { get; set; }

    [JsonProperty("SendByte")]
    public string SendByte { get; set; }
}
