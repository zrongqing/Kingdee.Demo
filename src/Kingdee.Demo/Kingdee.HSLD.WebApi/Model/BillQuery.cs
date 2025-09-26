using Newtonsoft.Json;

namespace Kingdee.HSLD.WebApi.Model;

/// <summary>
/// 单据查询
/// </summary>
public class BillQuery
{
    [JsonProperty("FieldKeys")]
    public string FieldKeys { get; set; } = string.Empty;

    [JsonProperty("FilterString")]
    public string[] FilterString { get; set; } = Array.Empty<string>();

    [JsonProperty("FormId")]
    public string FormId { get; set; } = string.Empty;

    [JsonProperty("Limit")]
    public long Limit { get; set; } = 2000;

    [JsonProperty("OrderString")]
    public string OrderString { get; set; } = string.Empty;

    [JsonProperty("StartRow")]
    public long StartRow { get; set; } = 0;

    [JsonProperty("SubSystemId")]
    public string SubSystemId { get; set; } = string.Empty;

    [JsonProperty("TopRowCount")]
    public long TopRowCount { get; set; } = 0;
}
