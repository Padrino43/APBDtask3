namespace ContainerManagementApp;

public class Ship(double maxSpeed, int maxContainers, double maxContainersWeight)
{
    private static int _id = 0;

    public int Id { get; } = _id++;
    public double MaxSpeed { get; } = maxSpeed;
    public int MaxContainers { get; } = maxContainers;
    public double MaxContainersWeight { get; } = maxContainersWeight;
    private List<Container> _containers { get; } = [];
    
    
    

}