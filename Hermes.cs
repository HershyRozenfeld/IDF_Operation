using System.IO.Pipes;

public class Hermes460 : AttakTools
{
  

    public override  void setFields()
    {
        this.booms = "person , vehicles";
        this.efective = "pepole , vechiles";
 this.strikes = 3;
    public override void setStrike()
    {
        strikes --;
    }

}