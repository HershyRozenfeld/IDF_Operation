public class F16Fighter : Weapon
{
    public F16Fighter() : base("0.5 ton", "building", 8)
    {

    }

    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }


}