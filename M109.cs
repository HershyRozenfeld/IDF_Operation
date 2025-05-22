public class M109 : AttakTools
{

   

    public override  void setFields()
    {
        this.booms = "explosive shells";
        this.efective = "open areas";
        this.strikes = 40;
    }

    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }
}