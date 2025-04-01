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


/*bigger picture:
Preparing the Image Size
The program calculates how big the ASCII version should be based on:
The current width of your console window(we don't want it too wide)
The original image's proportions (to avoid stretching)
*/
        private static string ConvertToAscii(Image image)
        {
            //adjusting the size
            int consoleWidth = Console.WindowWidth;
            int newWidth = (int)(consoleWidth * 0.75);
            int newHeight = (int)(image.Height * (newWidth / (double)image.Width) * 0.5);

            //to convert to ASCII, first convert to bitmap
            Bitmap resizedBitmap = new Bitmap(image, new Size(newWidth, newHeight));
            //use a string builder to store and construct the ASCII art
            StringBuilder asciiArt = new StringBuilder();

            //ASCII characters
            string asciiChars = "@%#*+=-:. ";

            //iterate through each pixel in the image(bitmap)
            for (int y = 0; y < resizedBitmap.Height; y++)
            {
                for (int x = 0; x < resizedBitmap.Width; x++)
                {
                    //get the color of the current pixel
                    Color pixelcolor = resizedBitmap.GetPixel(x, y);
                    //convert the pixel color
                    int grayValue = (int)(pixelcolor.R * 0.3 +
                                          pixelcolor.G * 0.59 +
                                          pixelcolor.B * 0.11);
                    //map the gray value to an ASCII character?
                    int index = grayValue * (asciiChars.Length - 1) / 255;
                    //append the ASCII character to the string builder
                    asciiArt.Append(asciiChars[index]);
                }

                asciiArt.Append(Environment.NewLine);
            }
            return asciiArt.ToString();
        }
    }
}
/*
 * The Big Picture
This program takes a digital image and transforms it into a picture made entirely of text characters that you can view in a console/terminal. It works by converting different brightness levels in the image to different ASCII characters that visually represent those brightness levels

Step-by-Step Logical Flow
Checking the Image File

First, the program checks if the image file exists at the specified location

If not found: Shows an error message and stops

If found: Proceeds to process the image

bigger picture:
Preparing the Image Size
The program calculates how big the ASCII version should be based on:
The current width of your console window (we don't want it too wide)
The original image's proportions (to avoid stretching)

It makes the ASCII version smaller than the original because:

Console characters are much larger than image pixels

Each image pixel will become one text character

Console characters are taller than they are wide, so we adjust height accordingly

Converting Colors to Brightness

For each pixel in the resized image:

The program looks at its red, green, and blue (RGB) values

It calculates a "brightness" score using a special formula that accounts for:

Human eye sensitivity (we see green more than red, and red more than blue)

The formula gives more weight to green, less to red, and least to blue

This brightness score ranges from 0 (completely dark) to 255 (completely bright)

Mapping Brightness to Characters

The program has a sequence of characters: @%#*+=-:.

@ looks very "dark" or "dense"

(space) looks very "light"

The other characters create shades in between

It divides the 0-255 brightness range into equal parts matching the number of characters

Darker pixels get characters from the start of the sequence

Brighter pixels get characters from the end

Building the ASCII Art

The program scans the image row by row, left to right

For each pixel, it adds the corresponding ASCII character to a growing text string

After each row of pixels, it adds a "new line" to start the next row

When finished, this text string contains the complete ASCII image

Displaying the Result

The completed ASCII art text is printed to the console

Because of the careful character selection, this creates a recognizable (though abstract) version of the original image

Why This Works Visually

 */