namespace ContainerManagementApp;

public class CContainer(double height, double weight, double depth, double maxCapacity) 
    : Container(height, weight, depth, "C", maxCapacity)
{
    public Product? ChoosedProduct { get; private set; } = null;
    public double Temperature { get; } = new Random().Next(-300,206) / 10.0;


    public override void LoadCargo(double weightToLoad)
    {
        int option = 100;
        int counter = 0;
        
        Console.WriteLine("Actual Temperature: "+Temperature);
        var arr = Enum.GetValues<Product>();
        while (option > counter || option < 0)
        {
            counter = 0;
            foreach (var product in arr)
            {
                if ((int)product > Temperature)
                {
                    Console.WriteLine("(" + counter + ")" + product);
                    counter++;
                }

            }
            option = Convert.ToInt32(Console.ReadLine());
        }
        
        ChoosedProduct = arr[option];
        base.LoadCargo(weightToLoad);

    }
}

public enum Product
{
    Bananas = 133,
    Chocolate = 180,
    Fish = 20,
    Meat = -150,
    IceCream = -18,
    FrozenPizza = -300,
    Cheese = 72,
    Sausages = 50,
    Butter = 205,
    Eggs = 190
    
}