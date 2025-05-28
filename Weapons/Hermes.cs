using System.IO.Pipes;

public class Hermes460 : Weapon
{
    public static int count = 1;
    public Hermes460():base("Hermes","person , vehicles", "vechiles",3)
    {
        count++;
    }
    
    public override void setStrike(int newStrike)
    {
        strikes -= newStrike;
    }  

}