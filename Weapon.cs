public abstract class Weapon
{

    public string name;
    public string booms;
    public string effective;
    public int strikes;


    public Weapon(string name ,string booms,string effective,int strikes)
    {
        this.booms = booms;
        this.effective = effective;
        this.strikes = strikes;
        this.name = name;
    }
    public override string ToString()
    {
        return $"Weapon: {name}\n" +
               $"- Boom Type: {booms}\n" +
               $"- Effective Area: {effective}\n" +
               $"- Strikes Left: {strikes}\n";
    }
    public abstract void setStrike(int fgh);
}