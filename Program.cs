using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part1
{
    public class ChatBot
    {
        [STAThread]
        private static void Main(string[] args)
        {
            voiceGreeting voicegreeting = new voiceGreeting();
            voicegreeting.playAudio();

            ImageDisplay imageDisplay = new ImageDisplay();
            imageDisplay.LoadImage();


            chatbegins ChatBegins = new chatbegins();
            ChatBegins.Header_display();
            ChatBegins.introduction();

          

                //fix safety browsing
            
        }
    }
}