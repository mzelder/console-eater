using System.Diagnostics;
using System.Linq.Expressions;

ConsoleKeyInfo keyInfo;
Random rnd = new Random();

var w = Console.WindowWidth;
var h = Console.WindowHeight;
int positionX = w / 2;
int positionY = h / 2;
int score = 0;

int appleX;
int appleY;

char appleEmote = '';
char snakeHeadEmote = '□'; 
char snakeBodyEmote = '■';

// 0 - left, 1 - up, 2 - right, 3 - down
int previousDirection;
int direction = 0;

SnakeElement head = new SnakeElement(positionX, positionY, direction);
SnakeElement body = new SnakeElement(positionX+1, positionY, direction);
SnakeElement[] snakeElements = { head, body };

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
    // Add +1 to score when apple eaten
    if (AppleEaten()) {
        GenerateApple();
        score++;
        AddSnakeElement();
    }
    
    UpdateUI();
    
    // So the snake will be faster in up-down directions (no more explanation needed )
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
    
    // show whole snake
    int counter = 0;
    foreach (var snakeElement in snakeElements) { 
        Console.SetCursorPosition(snakeElement.PositionX, snakeElement.PositionY);
        if (counter == 0)  
            Console.Write(snakeHeadEmote);
        else 
            Console.Write(snakeBodyEmote);

        counter++;
    }

    Console.SetCursorPosition(appleX, appleY);
    Console.Write(appleEmote);
}

void GenerateApple() {
    appleX = rnd.Next(w);
    appleY = rnd.Next(h);
}

bool AppleEaten() {
    if (appleX == head.PositionX && appleY == head.PositionY) {
        return true;
    }
    return false;
}

void MoveSnake() {
    // Moving head of the snake
    int prevX = snakeElements[0].PositionX;
    int prevY = snakeElements[0].PositionY;
    int prevDirect = snakeElements[0].Direction;
    
    switch (direction) {
            case 0:
                snakeElements[0].PositionX--;
                break;
            case 1:
                snakeElements[0].PositionY--;
                break;
            case 2:
                snakeElements[0].PositionX++;
                break;
            case 3:
                snakeElements[0].PositionY++;
                break;
        }  
    

    for (int i = 1; i < snakeElements.Length; i++) {
        int tempX = snakeElements[i].PositionX;
        int tempY = snakeElements[i].PositionY;
        int tempDirect = snakeElements[i].Direction;

        snakeElements[i].PositionX = prevX;
        snakeElements[i].PositionY = prevY;
        snakeElements[i].Direction = prevDirect;

        prevX = tempX;
        prevY = tempY;
        prevDirect = tempDirect;
    }
     
}

void AddSnakeElement() {
    SnakeElement lastElement = snakeElements[snakeElements.Length-1];
    int positionX = lastElement.PositionX;
    int positionY = lastElement.PositionY;
    
    switch (lastElement.Direction) {
        case 0: positionX++; break;
        case 1: positionY++; break;
        case 2: positionX--; break;
        case 3: positionY--; break;
    }

    SnakeElement newElement = new SnakeElement(positionX, positionY, lastElement.Direction);
    Array.Resize(ref snakeElements, snakeElements.Length + 1);
    snakeElements[snakeElements.Length - 1] = newElement;
} 