using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Part1
{
    public class ChatBot
    {
        
        private static void Main(string[] args)
        {
            

            voiceGreeting voicegreeting = new voiceGreeting();
            voicegreeting.playAudio();

            ImageDisplay imageDisplay = new ImageDisplay();
            imageDisplay.LoadImage();


            UserInterface UI = new UserInterface();
            UI.Header_display();
            UI.delegates();


            
        }
    }
}