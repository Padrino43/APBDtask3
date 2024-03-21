namespace ContainerManagementApp;

public class CContainer(double height, double weight, double depth, double maxCapacity) 
    : Container(height, weight, depth, "C", maxCapacity)
{
    public Product? ChoosedProduct { get; private set; } = null;
    public double Temperature { get; } = new Random().Next(-300,206) / 10.0;


    public override void LoadCargo(double weightToLoad)
    {
        base.LoadCargo(weightToLoad);
        int option = 100;
        int counter = -1;
        
        Console.WriteLine("Actual Temperature: "+Temperature+" C");
        var arr = Enum.GetValues<Product>();
        Console.WriteLine("Select product to be stored in container");
        while (option < 0 || option > counter)
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
        Console.WriteLine("Positive choosed : "+ ChoosedProduct);
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