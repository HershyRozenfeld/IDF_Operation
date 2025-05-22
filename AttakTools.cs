public abstract class AttakTools
{
    private  string _booms;
    private string   _efective;
    protected  int _strikes;

    public AttakTools(string booms,string efective,int strikes)
    {
        this._booms = booms;
        this._efective = efective;
        this._strikes = strikes;
    }

    public abstract void setStrike(int newStrike);
}