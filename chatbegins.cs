using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Part1
{
    public class chatbegins
    {
        public void Header_display()

        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Console.WriteLine("||                                                                                      ||");
            Console.WriteLine("||                             Welcome to CyberSurfer!                                  ||");
            Console.WriteLine("||                                                                                      ||");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ResetColor();
            Console.WriteLine();

           
            Console.WriteLine("I'm CyberSurfer your Cyber Security expert.");
            Console.WriteLine("I can explain to you topics on password security, phishing, and safety browsing.\n");
            Console.WriteLine("***Type 'exit' to quit ***\n");
            Console.WriteLine("let's begin the chat.\n");
        }

        public void introduction()
        {
            //the name of the chatbot
            string Chatbot = "CyberSurfer";

            //color of the chabtot
            Console.ForegroundColor = ConsoleColor.Blue;
            //the chatbot prompts the user for their name
            Console.Write(Chatbot);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": " + "Kindly share your name: ");
            Console.WriteLine();
            //reads and stores the name as user
            string User = Console.ReadLine();

            //color is given to the chatbot again as part of the introduction 
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Chatbot);
            Console.ForegroundColor = ConsoleColor.White;
            //greets the user and establishes the topic
            Console.Write(": " + "Hey " + User + " Ask me about Cyber Security topics such as Password security, Phishing and Safety browsing");
            Console.WriteLine();
            
            //calling the System Response but why??
            SystemResponse response = new SystemResponse();
            response.Key(); 
            response.filered_words(); 

            //beginning a loop condition
            while (true)
            {
                //converts the user's name to green throughout the chat
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write(User);
                Console.Write(": ");
                Console.ForegroundColor = ConsoleColor.White;

                //creating a user input variable and read what's inside it
                string userInput = Console.ReadLine();

                /*exit plan*/

                //if the user input is equal to exit then exit the app (ignore case is applied)
                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    //color of the chatbot
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.Write(Chatbot);
                    //display the goodbye message then end the conversation
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(":"+" Goodbye, till next time!");
                    Console.WriteLine();
                    break;
                }


                //using a string to store the bot response which will process the question according to the condition set in the previous class. 
                //the user input which will be scanned is called
                string botResponse = response.process_Question(userInput);
                //note: exception is handled in the System responds class so i'm saying that if that exception message matches then set the color to red. why? because we convert the color from return which is where it's handled.
                if (botResponse == "ask something relevant to the topics mentioned above")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("CyberSurfer: ");
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.Write(botResponse);
                    Console.ResetColor();
                }
                //however if that condition does not match output the response on the bot. 
                //reminder: the question is processed and properly handled in the other class. keeping the color blue. this will loop throughout
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("CyberSurfer: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(botResponse);
                }
            }
            


        }
    }
}