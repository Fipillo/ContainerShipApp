using System;
using System.Collections.Generic;
using System.Linq;
using ContainerShipmentApp;

public class Ship{
    private List<Container> containers = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxTotalMass { get; set; }

    public Ship(double maxSpeed, int maxContainerCount, double maxTotalMass)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxTotalMass = maxTotalMass;
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
    
}