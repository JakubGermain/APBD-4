public class Visit
{
    private static int _idCounter = 1;

    public int Id { get;  set; }
    public DateTime Date { get; set; }
    public int AnimalId { get; set; }
    public string Desc { get; set; }
    public decimal Price { get; set; }

    public Visit()
    {
        Id = _idCounter++;
        Desc = string.Empty;
    }
}