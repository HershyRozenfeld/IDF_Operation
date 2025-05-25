public class F16Fighter : AttakTools
{
       
    public F16Fighter() : base("F16","0.5 ton , ton", "building", 8) { }
    

    public override void setStrike(int newStrike)
    {
        _strikes -= newStrike;
    }


}