using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Part1
{
    public class extraEffects
    {
        //this method is responsible for the type writer effects. the message itself plus its speed is declared as a string first
        public void TypeWriterEffect(string message, int delayPerChar = 15) 
        {
            //for each character in the message add a typeWriter effect.
           foreach(char character in message)
            {
                Console.Write(character);
                System.Threading.Thread.Sleep(delayPerChar);
            }
        }

    }
}
/*
 * 

        public void TypeWriterEffect(string message, int delay, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}*/
