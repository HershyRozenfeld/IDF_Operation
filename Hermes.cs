public class Hermes460 : AttakTools
{
    public Hermes460() : base("personnel or armored vehicles", "pepole , vechiles", 3)
    {
    }
    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }

}