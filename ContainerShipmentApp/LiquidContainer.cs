namespace ContainerShipmentApp;

public class LiquidContainer:Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(int height, double weight, int depth, string serialNumber, double maxLoadCapacity, bool isHazardous)
        : base(height, weight, depth, serialNumber, maxLoadCapacity)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadContainer(double mass)
    {
        double allowableMass = IsHazardous ? MaxLoadCapacity * 0.5 : MaxLoadCapacity * 0.9; // im SOOOOOOO fancy  c(:
        
        if (mass > allowableMass)
        {
            NotifyHazard($"Mass exceeds allowed limit for this container type");
            throw new OverfillException("Mass exceeds allowed limit for this container type");
        }
        base.LoadContainer(mass);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard warning for container {SerialNumber}: {message}");
    }
    public override string ToString()
    {
        return base.ToString() + $", Hazardous: {IsHazardous}";
    }
    
}
