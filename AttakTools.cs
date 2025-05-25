public abstract class Weapon
{
    protected string name;
    protected  string _booms;
    protected string   _efective;
    protected  int _strikes;

    public Weapon(string name ,string booms,string efective,int strikes)
    {
        this._booms = booms;
        this._efective = efective;
        this._strikes = strikes;
        this.name = name;
    }

    public abstract void setStrike(int newStrike);
}