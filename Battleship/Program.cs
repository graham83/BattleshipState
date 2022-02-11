using Battleship;

int width = 10;
int height = 10;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to Battleships!");

var p1 = new Player(width, height);
var p2 = new Player(width, height);


if (p1.AddShip(1, 1, new Ship(2), Direction.Horizontal))
    Console.WriteLine("Ship added 1,1 horizontal length 2");
else
    Console.WriteLine("Invalid ship position");

if (p1.AddShip(1,2, new Ship(3), Direction.Vertical))
    Console.WriteLine("Ship added 1,2 veritcal length 3");
else
    Console.WriteLine("Invalid ship position");

Console.WriteLine("Enter Player Name");

p1.Name = Console.ReadLine() ?? "Tester";

Console.WriteLine($"Hi {p1.Name} - keep entering coordinates from your opponent in format 'x,y'");

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

    if (p1.PlayerLostGame())
    {
        Console.WriteLine($"Game Complete. Your rating is {p1.GetRating()}. Press Q to exit.");
    }

    userInput = Console.ReadLine();
}



