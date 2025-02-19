var w = Console.WindowWidth;
var h = Console.WindowHeight;
int positionX = w / 2;
int positionY = h / 2;

char appleEmote = '';
char snakeHeadEmote = 'X'; 
char snakeBodyEmote = 'O';

ConsoleKeyInfo keyInfo;

while (true) {
     Initialize();
     
     keyInfo = Console.ReadKey();
     switch (keyInfo.Key)
     {
        case ConsoleKey.UpArrow:
            positionY--;
            break;
        case ConsoleKey.DownArrow:
            positionY++;
            break;
        case ConsoleKey.LeftArrow:
            positionX--;
            break;
        case ConsoleKey.RightArrow:
            positionX++;
            break;
     }

     UpdateUI();

}

void Initialize() {
    Console.CursorVisible = false;
    UpdateUI();
}

void UpdateUI() {
    Console.Clear();
    Console.SetCursorPosition(positionX, positionY);
    Console.Write(snakeHeadEmote);
    for (int i = 0; i < 10; i++) { Console.Write(snakeBodyEmote); }
}