using ContainerShipmentApp;

public class Ship{
    public List<Container> containers = new List<Container>();
    public string Name { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxTotalMass { get; set; }

    public Ship(double maxSpeed, int maxContainerCount, double maxTotalMass, string name)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxTotalMass = maxTotalMass;
        Name = name;
    }

    public void AddContainer(Container container)
    {
        if (containers.Count >= MaxContainerCount)
        {
            throw new Exception("Adding this container would exceed maximum number of containers");
        }

        double currentTotalMass = containers.Sum(c => c.LoadMass + c.ContWeight);
        if (currentTotalMass + container.ContWeight + container.LoadMass > MaxTotalMass)
        {
            throw new Exception("Adding this container would exceed max total mass of the ship");
        }

        containers.Add(container);
    }

    public double CalculateCurrentLoad()
    {
        return containers.Sum(c => c.LoadMass + c.ContWeight);
    }
    
    public override string ToString()
    {
        string shipInfo = $"Ship Details:\n" +
                          $"Name: {Name}\n" +
                          $"Max Speed: {MaxSpeed} knots\n" +
                          $"Max Container Count: {MaxContainerCount}\n" +
                          $"Max Total Mass: {MaxTotalMass} kg\n" +
                          $"Current Load: {CalculateCurrentLoad()} kg\n" +
                          $"Current Container Count: {containers.Count}\n";

        if (containers.Any())
        {
            shipInfo += "Containers on the ship:\n";
            foreach (var container in containers)
                shipInfo += $"- {container.ToString()}\n";
            
        }
        else
        {
            shipInfo += "No containers on the ship.\n";
        }

        return shipInfo;
    }
}