namespace Kingdee.HSLD.WebApi.Model;

public class LookQuery
{
    public long CreateOrgId { get; set; } = 0;
    public string Number { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public string IsSortBySeq = "false";
}
