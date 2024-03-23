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

}