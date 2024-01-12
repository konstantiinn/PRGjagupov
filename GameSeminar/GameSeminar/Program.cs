//HRA PONG - upravil jsem klasickou verzi pongu aby to nebylo to stejne, ted hrac dostane za kazdy odrazeny micek bod
//         - musi dat 33 bodu(bud tim ze odrazi micek 33krat nebo eventuelne se stane to ze pocitac neodehraje balon, ale to jen velmi zridka)
//         - naopak vyhraje pocitac kdyz skoruje jen a pouze 7 bodu!
//         - je dost mozny, ze hra nebude vhodna pro epileptiky protoze by skoncili hned, diky skvelemu refreshovani :)))
//         - chapu taky, ze pong neni primo objektovan aby byl sestrojen v konzoli ale byl to prvni a to je ten nejlepsi napad takze whynot.
//         - nekdy se stane bug s tim ze se micek jakoby zasekne za palkou hrace a baunsuje tam nekolikrat a tim si hrac nazene hodne bodu, chatgpt mi s tim neporadil a ja taktez nevim.
//         - GL playing!!!

using System;
using System.Threading;

class Program
{
    //spousta promennych
    static int paddleHeight = 5;
    static int paddleWidth = 1;
    static int paddleSpeed = 1;
    static int ballSpeedX = 1;
    static int ballSpeedY = 1;

    static int playerPaddlePos = 10;
    static int computerPaddlePos = 10;

    static int ballPosX = 30;
    static int ballPosY = 15;

    static int playerScore = 0;
    static int computerScore = 0;

    static bool isGameOver = true;

    static bool isComputerPaddleStopped = false;
    static DateTime stopComputerPaddleUntil;
    //tady zakladni menu pro start(spusti se vsechny veci) nebo quit
    static void Main()
    {
        Console.WindowHeight = 30;
        Console.WindowWidth = 80;
        Console.BufferHeight = 30;
        Console.BufferWidth = 80;

        Console.CursorVisible = false;

        while (true)
        {
            if (isGameOver)
            {
                ShowStartMenu();
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.S)
                {
                    StartGame();
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Clear();
                DrawGame();
                GetUserInput();
                MoveBall();
                MoveComputerPaddle();
                CheckCollision();
                Thread.Sleep(50);
            }
        }
    }

    static void ShowStartMenu()
    {
        Console.Clear();
        Console.SetCursorPosition(30, 12);
        Console.Write("Hra PONG");
        Console.SetCursorPosition(15, 15);
        Console.Write("Hra konci kdyz ma hrac 33 bodu nebo pocitac 7!");
        Console.SetCursorPosition(15, 18);
        Console.Write("Zmacknete 'S' pro start hry nebo 'Q' pro ukonceni");
    }
    // rozhrani - palka hrace a robota, micek
    static void DrawGame()
    {
        if (!isGameOver)
        {
            DrawPaddle(2, playerPaddlePos);
            DrawPaddle(75, computerPaddlePos);

            Console.SetCursorPosition(ballPosX, ballPosY);
            Console.Write("O");

            Console.SetCursorPosition(35, 2);
            Console.Write($"Score: {playerScore} - {computerScore}");
        }
    }

    static void DrawPaddle(int x, int y)
    {
        for (int i = 0; i < paddleHeight; i++)
        {
            int posY = y + i;
            if (posY >= 0 && posY < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, posY);
                Console.Write("|");
            }
        }
    }
    //pohyb pomoci W a S - nahoru / dolu - nebo muze hrac ragequitnout a zmacknout Q :))
    static void GetUserInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (!isGameOver)
            {
                if (key.Key == ConsoleKey.W && playerPaddlePos > 0)
                {
                    playerPaddlePos -= paddleSpeed;
                }

                if (key.Key == ConsoleKey.S && playerPaddlePos < Console.WindowHeight - paddleHeight)
                {
                    playerPaddlePos += paddleSpeed;
                }

                if (key.Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
    //pohyb micku
    static void MoveBall()
    {
        ballPosX += ballSpeedX;
        ballPosY += ballSpeedY;

        if (ballPosY <= 0 || ballPosY >= Console.WindowHeight - 1)
        {
            ballSpeedY = -ballSpeedY;
        }

        if (ballPosX <= 3 && (ballPosY >= playerPaddlePos && ballPosY <= playerPaddlePos + paddleHeight) && ballPosX >= 0)
        {
            ballSpeedX = -ballSpeedX;
            PlayerScoresPoint();
        }

        if (ballPosX >= 73 && (ballPosY >= computerPaddlePos && ballPosY <= computerPaddlePos + paddleHeight) && ballPosX <= Console.WindowWidth - 1)
        {
            if (!isComputerPaddleStopped)
            {
                ballSpeedX = -ballSpeedX;
            }
        }
        //konec hry nebo reset
        if (ballPosX < 0 || ballPosX > Console.WindowWidth - 1)
        {
            if (ballPosX < 0)
            {
                ComputerScoresPoint();
            }
            else
            {
                PlayerScoresPoint();
            }

            if (playerScore >= 33 || computerScore >= 7)
            {
                isGameOver = true;
            }
            else
            {
                ResetBall();
            }
        }
    }
    //tady ta cast kodu pomoci GPT, protoze me nenapadl zpusob vymyslet nahodny pohyb palky robota
    static void MoveComputerPaddle()
    {
        if (isComputerPaddleStopped && DateTime.Now < stopComputerPaddleUntil)//?
        {
            return;
        }

        Random random = new Random();
        int randomMove = random.Next(-1, 2);

        if (ballPosY + ballSpeedY < computerPaddlePos + paddleHeight / 2 && computerPaddlePos > 0)
        {
            computerPaddlePos -= paddleSpeed + randomMove;
        }
        else if (ballPosY + ballSpeedY > computerPaddlePos + paddleHeight / 2 && computerPaddlePos < Console.WindowHeight - paddleHeight)
        {
            computerPaddlePos += paddleSpeed + randomMove;
        }
    }
    //kontrola zda byl / nebyl bod skorovan
    static void CheckCollision()
    {
        if (ballPosX < 0)
        {
            ResetBall();
        }

        if (ballPosX > Console.WindowWidth - 1)
        {
            ResetBall();
        }
    }

    static void ResetBall()
    {
        ballPosX = Console.WindowWidth / 2;
        ballPosY = Console.WindowHeight / 2;
    }
    //start charakteristics
    static void StartGame()
    {
        isGameOver = false;
        playerScore = 0;
        computerScore = 0;
        playerPaddlePos = 10;
        computerPaddlePos = 10;
        ballPosX = 30;
        ballPosY = 15;
        paddleSpeed = 1;
        isComputerPaddleStopped = false;
    }
    //zmena skore
    static void PlayerScoresPoint()
    {
        playerScore++;
    }

    static void ComputerScoresPoint()
    {
        computerScore++;
    }
}
