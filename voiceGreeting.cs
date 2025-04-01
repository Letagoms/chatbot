using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part1
{
    internal class voiceGreeting
    {
        public void playAudio()
        {
            string audioPath = "C:\\Users\\RC_Student_lab\\source\\repos\\Part1\\Voice.wav";

            if (!System.IO.File.Exists(audioPath))
            {
                Console.WriteLine("Audio file not found!");
                return;
            }
            try
            {
                SoundPlayer sound = new SoundPlayer(audioPath);
                sound.Play();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }  

    }     
}