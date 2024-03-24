namespace ContainerShipmentApp;

public abstract class Container
{
    public double LoadMass { get; set; }
    public int Height { get; private set; }
    public double ContWeight { get; private set; }
    public int Depth { get; private set; }
    public string SerialNumber { get; private set; }
    public double MaxLoadCapacity { get; private set; }

    protected Container(int height, double weight, int depth, string serialNumber, double maxLoadCapacity)
    {
        Height = height;
        ContWeight = weight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoadCapacity = maxLoadCapacity;
    }
    
    private static string SerialNumberGenerator(string containerType)
    {
        return $"KON-{containerType}-{new Random().Next(1000, 9999)}";
    }
    
    public virtual void LoadContainer(double mass)
    {
        if (mass > MaxLoadCapacity)
            throw new OverfillException("Mass exceeds MaxLoad");
        
        LoadMass = mass;
    }

    public void UnloadContainer()
    {
        LoadMass = 0;
    }
    
    public override string ToString()
    {
        return $"Serial: {SerialNumber}, Height: {Height}, Weight: {ContWeight}, Depth: {Depth}, Max Load: {MaxLoadCapacity}";
    }

}