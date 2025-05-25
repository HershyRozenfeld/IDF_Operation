using System.IO.Pipes;

public class Hermes460 : Weapon
{
    public Hermes460():base("Hermes","person , vehicles", "vechiles",3) { } 
    
    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }  

}