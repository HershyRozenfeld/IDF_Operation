public class M109 : AttakTools
{
    
    public M109 ():base("explosive shells", "open areas",40) { }

    public override void setStrike(int newStrike)
    {
        _strikes -= newStrike;
    }
}