using System.IO.Pipes;

public class Hermes460 : AttakTools
{
     
    public Hermes460():base("person , vehicles", "pepole , vechiles",3) { } 
    
    public override void setStrike(int newStrike)
    {
        _strikes -= newStrike;
    }

}