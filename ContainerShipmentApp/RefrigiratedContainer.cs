namespace ContainerShipmentApp
{
    public class RefrigeratedContainer : Container, IHazardNotifier
    {
        public string ContentType { get; set; }
        public double RequiredTemperature { get; private set; }

        public RefrigeratedContainer(int height, double weight, int depth, string serialNumber, double maxLoadCapacity, double requiredTemperature) 
            : base(height, weight, depth, serialNumber, maxLoadCapacity)
        { 
            RequiredTemperature = requiredTemperature;
        }

        public void LoadContainer(double mass, string contentType)
        {
            if (LoadMass == 0) 
            {
                ContentType = contentType;
            }

            if (mass > MaxLoadCapacity) 
            {
                throw new OverfillException("Mass exceeds MaxLoad");
            }
            
            if(contentType == ContentType)
            { 
                NotifyHazard($"Types of contents does not match");
                throw new Exception("Types of contents does not match");
            }
                    
            base.LoadContainer(mass);
        }

        public void UnloadContainer()
        {
            base.UnloadContainer();
            ContentType = null;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Hazard warning for container {SerialNumber}: {message}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Required Temp: {RequiredTemperature}°C";
        }
    }
}