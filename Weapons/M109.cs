public class M109 : Weapon
{
    
    public M109 ():base("M109","explosive shells", "open areas",40) { }

    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }
}