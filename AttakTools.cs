public abstract class AttakTools
{
    private  string _booms;
    private string   _efective;
    protected  int _strikes;
    private string name;

    public AttakTools(string name ,string booms,string efective,int strikes)
    {
        this._booms = booms;
        this._efective = efective;
        this._strikes = strikes;
        this.name = name;
    }

    public abstract void setStrike(int newStrike);
}