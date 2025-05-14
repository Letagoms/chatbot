using System;

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
extraEffects effects = new extraEffects();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Console.WriteLine("||                                                                                      ||");
            Console.WriteLine("||                             Welcome to CyberSurfer!                                  ||");
            Console.WriteLine("||                                                                                      ||");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ResetColor();
            Console.WriteLine();


            //introductory message
            Console.Write("                        CyberSurfer Your Cyber Security expert.                       \n");

            
            Console.WriteLine("-----------------------------------------------------------------------------------------"); Console.WriteLine();

            Console.Write("I can explain to you topics pertaining ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("password safety, phishing, safety browsing, Malware, two factor authentication and social engineering\n");

            Console.ForegroundColor = ConsoleColor.White;
           
            Console.WriteLine("-----------------------------------------------------------------------------------------"); Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("                             ***Type 'exit' to quit ***                                \n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("-----------------------------------------------------------------------------------------"); Console.WriteLine();
            Console.WriteLine();
            Console.Write("let's begin the chat...\n");
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
                    ", ask me about Cyber Security topics such as Password security, Phishing, Safety browsing, Malware, two factor authentication and social engineering ");
                Console.WriteLine();
            };

            Interaction Interaction = (string User, string ChatBot) =>
            {

                ProcessResponses response = new ProcessResponses();
                

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
                    string botResponse = response.GetResponse(userInput);

                    //exception handling
                    if (botResponse == "I'm not sure how to help with that. Try asking about password safety, phishing, or safe browsing.")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("CyberSurfer: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Effects.TypeWriterEffect(botResponse, delayPerChar: 8);
                        Console.WriteLine();
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
