public class M109 : Weapon
{
    public static int count;
    public M109 ():base("M109","explosive shells", "open areas",40) {
        count++;
    }

    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }
}