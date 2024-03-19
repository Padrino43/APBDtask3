namespace ContainerManagementApp;

public class GContainer(double height, double weight, double depth, double maxCapacity) 
    : Container(height, weight, depth, "G", maxCapacity), IHazardNotifier
{
    public override void UnloadCargo()
    {
        CargoWeight *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("IMPORTANT!: "+message+"("+SerialNumber+")");
    }
}