using Battleship;

int width = 10;
int height = 10;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to Battleships!");

var p1 = new Player(width, height);
var p2 = new Player(width, height);


if (p1.AddShip(1, 2, new Ship(1), Direction.Vertical))
    Console.WriteLine("Ship added");
else
    Console.WriteLine("Invalid ship position");

if (p1.AddShip(8, 4, new Ship(1), Direction.Vertical))
    Console.WriteLine("Ship added");
else
    Console.WriteLine("Invalid ship position");

Console.WriteLine("Enter attack coordiantes.");
var userInput = Console.ReadLine();

while(userInput != "Q")
{
    try
    {
        var pos = userInput.Split(',');
        var posX = Int32.Parse(pos[0]);
        var posY = Int32.Parse(pos[1]);
        if (p1.TakeAttack(posX, posY))
        {
            Console.WriteLine("HIT!!");
        }
        else
        {
            Console.WriteLine("MISS!!");
        }
    }
    catch
    {
        Console.WriteLine("Invalid input");
    }

    if (p1.GameComplete())
    {
        Console.WriteLine("Game Complete. Press Q to exit.");
    }

    userInput = Console.ReadLine();
}



