public class F16Fighter : Weapon
{
    public F16Fighter() : base("F16 Fighter", "0.5 ton", "building", 8)
    {

    }

    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }


}