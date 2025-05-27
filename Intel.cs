public class Intel
{
    public Terrorist terrorist;
    public string location;
    public DateTime date;
    public Intel(Terrorist terrorist, string location, DateTime date)
    {
        this.terrorist = terrorist;
        this.location = location;
        this.date = date;
    }
    public override string ToString()
    {
        return $"Target Intel:\n" +
               $"- Location: {location}\n" +
               $"- Date: {date.ToShortDateString()} {date.ToShortTimeString()}\n" +
               $"- Terrorist Info:\n{terrorist}";
    }
}