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
     public class voiceGreeting
    {
        public void playAudio()
        {
            string audioPath = "C:\\Users\\RC_Student_lab\\source\\repos\\Part1\\Voice.wav";

            //error handling if statement
            if (!System.IO.File.Exists(audioPath))
            {
                //error message
                Console.WriteLine("Audio file not found!");
                return;
            }
            try
            {
                //how the audio will be played
                SoundPlayer sound = new SoundPlayer(audioPath);
                sound.Play();
                Console.WriteLine();
            }
            //catch any exception
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }  

    }     
}