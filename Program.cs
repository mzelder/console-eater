using System.Diagnostics;

ConsoleKeyInfo keyInfo;
Random rnd = new Random();

var w = Console.WindowWidth;
var h = Console.WindowHeight;
int positionX = w / 2;
int positionY = h / 2;

int appleX;
int appleY;

char appleEmote = '';
char snakeHeadEmote = '□'; 
char snakeBodyEmote = '■';

// 0 - left, 1 - up, 2 - right, 3 - down
int previousDirection;
int direction = 0;

Initialize();

while (true) {
    if (Console.KeyAvailable) {
        previousDirection = direction;
        keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                // Ignore changing direction if the direction is opposite to the current one
                if (previousDirection == 3) break;
                direction = 1;
                break;
            case ConsoleKey.DownArrow:
                if (previousDirection == 1) break;
                direction = 3;
                break;
            case ConsoleKey.LeftArrow:
                if (previousDirection == 2) break;
                direction = 0;
                break;
            case ConsoleKey.RightArrow:
                if (previousDirection == 0) break;
                direction = 2;
                break;
        }
    }
    
    // Move snake every second
    MoveSnake();

    // Check if apple was eaten, if so then generate new one
    if (AppleEaten()) 
        GenerateApple();
     
    UpdateUI();
    
    if (direction % 2 == 0)
        Thread.Sleep(60);
    else 
        Thread.Sleep(120);
}

void Initialize() {
    Console.CursorVisible = false;
    GenerateApple();
    UpdateUI();
}

void UpdateUI() {
    Console.Clear();
    
    Console.SetCursorPosition(positionX, positionY);
    Console.Write(snakeHeadEmote);

    Console.SetCursorPosition(appleX, appleY);
    Console.Write(appleEmote);
}

void GenerateApple() {
    appleX = rnd.Next(w);
    appleY = rnd.Next(h);
}

bool AppleEaten() {
    if (appleX == positionX && appleY == positionY) {
        return true;
    }
    return false;
}

void MoveSnake() {
    switch (direction) {
        case 0:
            positionX--;
            break;
        case 1:
            positionY--;
            break;
        case 2:
            positionX++;
            break;
        case 3:
            positionY++;
            break;
    }   
} 