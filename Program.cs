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
int direction = 0;

Initialize();

while (true) {
    if (Console.KeyAvailable) {
        keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                direction = 1;
                break;
            case ConsoleKey.DownArrow:
                direction = 3;
                break;
            case ConsoleKey.LeftArrow:
                direction = 0;
                break;
            case ConsoleKey.RightArrow:
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
    //ResizeWindow();
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

void ResizeWindow() {
    try
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "osascript",
            Arguments = "-e \"tell application \\\"Terminal\\\" to set bounds of front window to {100, 100, 800, 800}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = Process.Start(psi))
        {
            // Capture the output and error
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            
            process.WaitForExit();
            
            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Output: " + output);
            }
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error: " + error);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}