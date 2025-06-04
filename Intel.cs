using System;

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
        string output = $"│ Target Intel\n";
        output += $"│ Location: {location}\n";
        output += $"│ Date: {date.ToShortDateString()} {date.ToShortTimeString()}\n";
        output += $"│ Terrorist Info:\n{terrorist.ToString()}";
        return output;
    }
}
