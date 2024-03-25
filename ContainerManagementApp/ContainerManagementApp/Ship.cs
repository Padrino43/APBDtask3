namespace ContainerManagementApp;

public class Ship
{
    public static List<Ship> _ships = new();
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

    public bool LoadSingleContainer(Container container, bool moving)
    {
        if (container.IsOnShip && moving == false) return false;
        if(_containers.Count + 1 > MaxContainers) return false;
        if (Weight + container.Weight * 0.001 > MaxContainersWeight) return false;

        Weight += container.Weight * 0.001;
        _containers.Add(container);
        Console.WriteLine("Positive load "+container);

        return true;
    }

    public bool LoadMultipleContainers(List<Container> containers)
    {
        if(containers.Count + _containers.Count > MaxContainers) return false;
        
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
        
        Console.WriteLine("Positive remove: " + container);
    }

    public void MoveContainer(Container container, Ship toShip)
    {
        if (!_containers.Contains(container))
        {
            Console.WriteLine("Error with moving container");
            return;
        }

        if (toShip.LoadSingleContainer(container,true))
        {
            _containers.Remove(container);
            Console.WriteLine("Positive move "+container+" to ship "+toShip);
        }
        
    }

    public Container? ReplaceContainer(Container container, string serialNumber)
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
            double sum = (_containers[index].MaxCapacity + _containers[index].Weight)
                - (container.MaxCapacity + container.Weight);
            
            if (sum <= 0.0 && Math.Abs(sum) <= MaxContainersWeight)
            {
                Container temp = _containers[index];
                _containers[index] = container;
                Console.WriteLine("Positive replace "+container);
                return temp;
            }
            else
            {
                Console.WriteLine("Replace failed because of container weight issue or quantity of it");
            }
            
        }

        return null;
    }
    public int GetContainerListLenght()
    {
        return _containers.Count;
    }

    public Container? GetContainer(int index)
    {
        if (index >= 0 && index < _containers.Count())
        {
            return _containers[index];
        }

        return null;
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