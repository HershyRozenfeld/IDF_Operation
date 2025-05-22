public class F16Fighter : AttakTools
{
    

    public override void setFields()
    {
        this.booms = "0.5 ton , ton";
        this.efective = "building";
        this.strikes = 8;
    }

    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }


}