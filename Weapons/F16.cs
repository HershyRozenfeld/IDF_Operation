public class F16Fighter : Weapon
{
    public static int count;
    public F16Fighter() : base("F16 Fighter", "0.5 ton", "building", 8)
    {
        count++;
    }

    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }


}