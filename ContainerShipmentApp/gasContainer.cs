namespace ContainerShipmentApp;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(int height, double weight, int depth, string serialNumber, double maxLoadCapacity, double pressure)
        : base(height, weight, depth, serialNumber, maxLoadCapacity)
    {
        Pressure = pressure;
    }

    public override void LoadContainer(double mass)
    {
        
        if (mass > MaxLoadCapacity)
        {
            NotifyHazard($"Mass exceeds allowed max capacity limit");
            throw new OverfillException("Mass exceeds allowed max capacity limit");
        }
        base.LoadContainer(mass);
    }
    
    
    public void UnloadContainer()
    {
        LoadMass = MaxLoadCapacity * 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard warning for container {SerialNumber}: {message}");
    }
}