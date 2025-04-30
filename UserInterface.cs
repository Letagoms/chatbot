using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Part1
{
    public class UserInterface
    {
        //adding delegates
        public delegate string Username(string ChatBot);
        public delegate string chatbot_Name(string User);
        public delegate void ChatBot_introduction(string User);
        public delegate void Interaction(string User, string ChatBot);
        extraEffects Effects = new extraEffects();


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

            extraEffects effects = new extraEffects();
            //introductory message
            effects.TypeWriterEffect("                        CyberSurfer Your Cyber Security expert.                       \n");
            Console.WriteLine("-----------------------------------------------------------------------------------------"); Console.WriteLine();
            effects.TypeWriterEffect("I can explain to you topics pertaining ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            effects.TypeWriterEffect("password safety, phishing, and safety browsing. \n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------------------------------------"); Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            effects.TypeWriterEffect("                             ***Type 'exit' to quit ***                                \n");
            Console.ForegroundColor = ConsoleColor.White;
            effects.TypeWriterEffect("let's begin the chat...\n");
        }

        public void delegates()
        {
            Username Username = (string ChatBot) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(ChatBot);
                Console.ForegroundColor = ConsoleColor.White;
                Effects.TypeWriterEffect(": " + "Kindly share your name: ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                string User = Console.ReadLine();
                return User;
            };

            chatbot_Name chatbot_Name = (string User) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                string ChatBot = "CyberSurfer";
                Console.Write(ChatBot);
                return ChatBot;

            };

            ChatBot_introduction ChatBot_introduction = (string User) =>
            {
                Console.ForegroundColor = ConsoleColor.White;
                Effects.TypeWriterEffect(": " + "Hey " + User +
                    ", ask me about Cyber Security topics such as Password security, Phishing and Safety browsing ");
                Console.WriteLine();
            };

            Interaction Interaction = (string User, string ChatBot) =>
            {
                SystemResponse response = new SystemResponse();
                response.Key();
                response.filered_words();

                //beginning a loop condition
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();

                    Console.Write(User); Console.Write(": ");

                    Console.ForegroundColor = ConsoleColor.White;
                    string userInput = Console.ReadLine();

                    //exit condition
                    if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(ChatBot);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(":" + " Goodbye, till next time!");
                        break;
                    }

                    //calling the method where the question is processed
                    string botResponse = response.process_Question(userInput);

                    //exception handling
                    if (botResponse == "Please ask something relevant to the topics mentioned above")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("CyberSurfer: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Effects.TypeWriterEffect(botResponse, delayPerChar: 8);
                    }

                    //else print out the response stored by in the system.
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(ChatBot); Console.Write(": ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Effects.TypeWriterEffect(botResponse, delayPerChar: 8);

                        Console.WriteLine();
                    }


                }//endwhile


            }; //end delegate
            string chatbot = "CyberSurfer"; // Initialize the chatbot name
            string user = Username(chatbot); // Pass the chatbot name to the Username delegate
            string chatbotName = chatbot_Name(user); // Pass the user name to the chatbot_Name delegate
            ChatBot_introduction(user); // Pass the user name to the ChatBot_introduction delegate
            Interaction(user, chatbotName);


        } //end delegate method

    } //class
} //namespace
