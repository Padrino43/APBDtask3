namespace ContainerManagementApp;

public class Ship
{
    private static List<Ship> _ships = new();
    private static int _id = 1;
    
    public int Id;
    public double MaxSpeed;
    public int MaxContainers;
    public double MaxContainersWeight;
    private double Weight;
    private List<Container> _containers;
    
    public Ship(double maxSpeed, int maxContainers, double maxContainersWeight)
    {
        _ships.Add(this);
        Id = _id++;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxContainersWeight = maxContainersWeight;
        Weight = 0.0;
        _containers = [];

    }

    public bool LoadSingleContainer(Container container)
    {
        if (container.IsOnShip) return false;
        if(_containers.Count + 1 > MaxContainers) return false;
        if (Weight + container.Weight * 0.001 > MaxContainersWeight) return false;

        Weight += container.Weight * 0.001;
        _containers.Add(container);
        Console.WriteLine("Positive load "+container);

        return true;
    }

    public bool LoadMultipleContainers(List<Container> containers)
    {
        if(_containers.Count + containers.Count > MaxContainers) return false;
        
        double sum = 0;
        foreach (var container in containers)
        {
            if (container.IsOnShip) return false;
            sum += container.Weight * 0.001;
        }
        
        if (Weight + sum > MaxContainersWeight) return false;

        foreach (var container in containers)
        {
            container.IsOnShip = true;
        }
        Weight += sum;
        _containers.AddRange(containers);

        return true;
    }

    public void RemoveContainer(Container container)
    {
        if (!_containers.Contains(container)) return;

        _containers.Remove(container);
        container.IsOnShip = false;
        
        Console.WriteLine("Positive remove :" + container);
    }

    public void MoveContainer(Container container, Ship toShip)
    {
        if(!_containers.Contains(container)) return;

        if (toShip.LoadSingleContainer(container))
        {
            _containers.Remove(container);
            Console.WriteLine("Positive move "+container+" to ship "+toShip);
        }
        
    }

    public void ReplaceContainer(Container container, String serialNumber)
    {
        bool finded = false;
        int index = 0;

        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].SerialNumber.Equals(serialNumber))
            {
                finded = true;
                index = i;
                break;
            }
        }

        if (finded)
        {
            _containers[index] = container;
            Console.WriteLine("Positive replace "+container);
        }
        
    }

    public override string ToString()
    {
        string toReturn = $"Ship {Id} (speed={MaxSpeed}, maxContainerNum={MaxContainers}, " +
                          $"maxWeight={MaxContainersWeight})\n";
        if (_containers.Count > 0)
        {
            foreach (var container in _containers)
            {
                toReturn += container + "\n";
            }
            
        }
        
        return toReturn;
    }
}