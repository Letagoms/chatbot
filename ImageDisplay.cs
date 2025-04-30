using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace Part1
{
    public class ImageDisplay
    {
        public void LoadImage()
        {
            //if the image file does not exist, display a message signaling that the image does not exist
            Console.ForegroundColor = ConsoleColor.Blue;
            string imagepath = "C:\\Users\\RC_Student_lab\\source\\repos\\Part1\\cyberlogo.jpg";
            if (!File.Exists(imagepath))
            {
                Console.WriteLine("The specified image file does not exist.");
                return;
            }
            //attempt to load the image here
            try
            {
                Image image = Image.FromFile(imagepath);
                //convert the image to ASCII art
                string asciiArt = ConvertToAscii(image);
                Console.WriteLine(asciiArt);
            }
            //exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private static string ConvertToAscii(Image image)
        {
            //adjusting the size
            int consoleWidth = Console.WindowWidth;
            int newWidth = (int)(consoleWidth * 0.75);
            int newHeight = (int)(image.Height * (newWidth / (double)image.Width) * 0.5);

            //to convert to ASCII, first convert to bitmap
            Bitmap resizedBitmap = new Bitmap(image, new Size(newWidth, newHeight));
            
            StringBuilder asciiArt = new StringBuilder();

            //ASCII characters
            string asciiChars = "@%#*+=-:. ";
            //iterate through each pixel in the image(bitmap)
            for (int y = 0; y < resizedBitmap.Height; y++)
            {
                for (int x = 0; x < resizedBitmap.Width; x++)
                {
                    
                    Color pixelcolor = resizedBitmap.GetPixel(x, y);

                    // Convert color to grayscale using human perception weights
                    // (Our eyes are more sensitive to green, hence higher weight)
                    int grayValue = (int)(pixelcolor.R * 0.3 + 
                                          pixelcolor.G * 0.59 + 
                                          pixelcolor.B * 0.11); 

                    // We're essentially stretching the 0-255 brightness range to fit our 10 characters
                    // Formula breakdown: (brightness or max_brightness) × (number_of_characters - 1)
                    int index = grayValue * (asciiChars.Length - 1) / 255;

                    // Add the corresponding ASCII character from our gradient string
                    // Our asciiChars are ordered from visually heaviest (@) to lightest (space)
                    asciiArt.Append(asciiChars[index]);
                }
                
                asciiArt.Append(Environment.NewLine);
            }
            // Finally, we convert our constructed ASCII art to a string
            // This contains the complete text representation of our image
           
            return asciiArt.ToString();
        }
    }
}


