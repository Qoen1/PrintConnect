namespace PrintConnect.Adapter.PrusaLink;

public class FolderInfo
{
    public string name { get; set; }
    public bool read_only { get; set; }
    public string type { get; set; }
    public List<FileInfo> children { get; set; }
}