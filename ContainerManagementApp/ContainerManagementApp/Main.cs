using System.Collections.Concurrent;
using ContainerManagementApp;

Console.WriteLine("dawda");
Ship ship = new Ship(20, 2, 100);
GContainer c1 = new GContainer(200, 20000, 400, 40000);
CContainer c2 = new CContainer(200, 20000, 400, 40000);
ship.LoadSingleContainer(c1);
c1.LoadCargo(20000);
ship.LoadSingleContainer(c2);
Console.WriteLine(ship);
