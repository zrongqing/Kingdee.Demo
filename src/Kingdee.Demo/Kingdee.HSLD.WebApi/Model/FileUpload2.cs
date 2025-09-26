using Newtonsoft.Json;

namespace Kingdee.HSLD.WebApi.Model;

public class FileUpload2
{
    [JsonProperty("FileName")]
    public string FileName { get; set; }
    
    [JsonProperty("IsLast")]
    public bool IsLast { get; set; }

    [JsonProperty("FileId")]
    public string FileId { get; set; }

    [JsonProperty("SendByte")]
    public string SendByte { get; set; }
}
