//STAN GRY
string heroName = "Barry";
int health = 70;
int maxHealth = 100;
int gold = 15;
int strength = 6;
int weaponDamage = 3;
bool isRunning = true;
//Listy do zadań z lambdami
List<string>inventory = new List<string>() { "Miecz", "Mikstura", "Łuk" };

//GŁÓWNA PĘTLA GRY

while (isRunning)
{
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();

    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage(strength, weaponDamage);
        Console.WriteLine($"Zadajesz {damage} obrażeń manekinowi!");
    }
    else if (command == "2")
    {
        health = Heal(health, 10, maxHealth);
        Console.WriteLine($"Odpoczywasz, masz teraz {health} HP.");
    }
    else if (command == "3")
    {
        isRunning = false;
    }

    if (IsGameOver(health))
    {
        Console.WriteLine("Umierasz! Koniec Gry!");
        isRunning = false;
    }
   
}

//DEFINICJE FUNKCJI

void ShowPanelTitle(string title, ConsoleColor color)
{
    Console.ResetColor();
    Console.ForegroundColor = color;
    Console.WriteLine($" {title.ToUpper()} ");
    Console.ResetColor();
}

void ShowStatus(string name, int health, int maxHealth, int gold)
{
    ShowPanelTitle("Menu Bohatera", ConsoleColor.DarkBlue);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"Bohater: ");
    Console.ResetColor();
    Console.WriteLine(name);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"Zdrowie: ");
    Console.ResetColor();
    Console.WriteLine($"{health}/{maxHealth} HP");
 
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"Złoto: ");
    Console.ResetColor();
    Console.WriteLine(gold);
}

void ShowMenu()
{
    ShowPanelTitle("Menu", ConsoleColor.DarkGreen);
    Console.WriteLine("1. Walcz z manekinem");
    Console.WriteLine("2. Odpocznij");
    Console.WriteLine("3. Zakończ grę");
    Console.Write("Wybierz akcję: ");
}

string ReadCommand()
{
    while (true)
    {
        Console.Write("Wybór: ");
        string? command = Console.ReadLine();
        if (command == "1" || command == "2" || command == "3")
        {
            return command;
        }
        else
        {
            Console.WriteLine("Nieprawidłowa komenda. Wybierz 1, 2 lub 3.");
        }
    }
}

int CalculateDamage(int strength, int weaponDamage) => strength + weaponDamage ;

int Heal(int health, int  amount, int maxHealth)
{
    int newHealth = health + amount;
    return newHealth > maxHealth ? maxHealth : newHealth;
}
bool IsGameOver(int health) => health <= 0;