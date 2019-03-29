using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }

        class Game
        {
            int lifes = 3;
            int currentRandom = -1;
            int level = 0;
          
            //this function handles the input message
            public int GetInput (string tips= "please enter game level between 1 and 3", bool limit = true)
            {
                Console.WriteLine(tips);
                string level = Console.ReadLine();
                int number;
                bool success = Int32.TryParse(level, out number);
                if(success)
                {
                    if (limit)
                    {
                        if (number >= 1 && number <= 3)
                        {
                            return number;
                        }
                        else
                        {
                            Console.WriteLine("invalid level, please try again");
                            return GetInput();
                        }
                    }
                    else
                    {
                        return number;
                    }
                }
                else
                {
                    Console.WriteLine("invalid number, please try again");
                    return GetInput("please enter a number", false);
                    
                }
                
            }

            // calculate random number
            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

            //create random number
            public int CreateRandom(int num)
            {
                if(num == 1)
                {
                    return RandomNumber(1, 10);
                }else if(num == 2)
                {
                    return RandomNumber(1, 20);
                }
                else
                {
                    return RandomNumber(1, 50);
                }
                
            }

            // reset some parameters
            public void Init()
            {
                lifes = 3;
                currentRandom = -1;
                level = 0;
            }
            
            // start the game
            public void Start()
            {
                if (currentRandom < 0)
                {
                    level = GetInput();
                    currentRandom = CreateRandom(level);
                }
                if (lifes > 0)
                {
                    int guess = GetInput("please enter a number", false);
                    if (guess == currentRandom)
                    {
                        Console.WriteLine("congratulations, you get a bonus ${0}", level*10);
                        Init();
                        Start();
                    }
                    else
                    {
                        lifes--;
                        Console.WriteLine("the number is too {0}, you have {1} lives",guess > currentRandom ? "big" : "small", lifes);
                        Start();
                    }
                }
                else
                {
                    Init();
                    Start();
                }
            }
        }
    }
}
