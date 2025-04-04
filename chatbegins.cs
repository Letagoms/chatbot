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

            //welcome header
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Console.WriteLine("||                                                                                      ||");
            Console.WriteLine("||                             Welcome to CyberSurfer!                                  ||");
            Console.WriteLine("||                                                                                      ||");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ResetColor();
            Console.WriteLine();

           //introductory message
            Console.WriteLine("I'm CyberSurfer your Cyber Security expert.");
            Console.WriteLine("I can explain to you topics pertaining password safety, phishing, and safety browsing.\n");
            Console.WriteLine("***Type 'exit' to quit ***\n");
            Console.WriteLine("let's begin the chat.\n");
        }

        public void introduction()
        {
            //the name of the chatbot
            string Chatbot = "CyberSurfer";

            //color of the chabtot
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Chatbot);
            Console.ForegroundColor = ConsoleColor.White;

            //the chatbot prompts the user for their name
            Console.Write(": " + "Kindly share your name: ");
            Console.WriteLine();

            
            //reads the username
            string User = Console.ReadLine();
            Console.WriteLine();
             
            //greets the user and establishes the topic
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Chatbot);
            Console.ForegroundColor = ConsoleColor.White;
            extraEffects Effects = new extraEffects();
            Effects.TypeWriterEffect(": " + "Hey " + User + 
                " ,ask me about Cyber Security topics such as Password security, Phishing and Safety browsing");
            
            Console.WriteLine();
            
            //before delving into various conditions the System Response class needs to be called
            SystemResponse response = new SystemResponse();
            response.Key(); 
            response.filered_words(); 

            //beginning a loop condition
            while (true)
            {
                //converts the user's name to green throughout the chat
                Console.ForegroundColor = ConsoleColor.Green;
                //places the user's next response underneath the chatbot response
                Console.WriteLine();
                Console.Write(User);
                Console.Write(": ");
                

                //now read the user's input(question or statement)
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine();

                
                //if the user enters exit regardless of the cases then exit the app
                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                { 
                    
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.Write(Chatbot);
                    //display the goodbye message then end the conversation
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(":"+" Goodbye, till next time!");
                    break;
                }


                //using a string to store the bot response which will process the question according to the condition set in the previous class. 
                //the user input which will be scanned is called
                string botResponse = response.process_Question(userInput);
                //note: exception is handled in the System responds class so i'm saying that if that exception message matches then set the color to red.
                //why? because we convert the color from return which is where it's handled.

                if (botResponse == "Please ask something relevant to the topics mentioned above")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("CyberSurfer: ");
                    Console.ForegroundColor=ConsoleColor.Red;
                    Effects.TypeWriterEffect(botResponse, delayPerChar: 8);
                }

                //else print out the response stored by in the system.
                else
                {
                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("CyberSurfer: ");
                    Console.ForegroundColor=ConsoleColor.White;
                    Effects.TypeWriterEffect(botResponse, delayPerChar: 8);

                    Console.WriteLine();
                }
            }
            


        }
    }
}