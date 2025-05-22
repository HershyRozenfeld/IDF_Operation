public abstract class AttakTools
{
    protected string booms;
    protected string efective;
    protected int strikes;

    public AttakTools(string booms, string efective, int strikes)
    {
        this.booms = booms;
        this.efective = efective;
        this.strikes = strikes;
    }

    public abstract void setStrike(int newStrike);
}