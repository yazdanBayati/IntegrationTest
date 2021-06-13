using Core;

public class File: IKey
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public int? ParentId { get; set; }
    public int UserId{ get; set;}

}