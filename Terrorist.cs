{
    private  string name;
    protected  string weapon;
    protected  int rank;
    protected bool status = true;

    public Terrorist(string name,string weapon,int rank)
    {
        this.name = name;
        this.weapon = weapon;
        this.rank = rank;
    }

    public void dead()
    {
        this.status = false;
    }

    public string getName()
    {
        return name;
    }

    public string getWeapon()
    {
        return weapon;
    }

    public int getRank()
    {
        return rank;
    }

    public bool getStatus()
    {
        return status;
    }
}