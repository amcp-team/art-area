using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace PsdParser
{
    class PsdReader
    {
        public const string FileHeaderSignatire = "8BPS";                               //default
        public const string ImageResourceSignature = "8BIM";                            //default
        public static Dictionary<short, string> ColorMode= new Dictionary<short, string> //all vars of
            {                                                                            //available colormode
               {0,"Bitmap"},
               {1,"GrayScale"},
               {2,"Indexed"},
               {3,"RGB"},
               {4,"CMYK"},
               {7,"Multichannel"},
               {8,"Duotone"},
               {9,"Lab"}

            };
        /// <summary>
        /// Read the header part and fill in some characteristics from it in .txt
        /// </summary>
        /// <param name="input">stream of.psd</param>
        /// <param name="output">stream of.txt</param>
        public static void ReadHeader(BinaryReader input,StreamWriter output)
        {   
            //TODO: change "if-ConsoleWriteline"constructions to "Throw" blocks;
            char[] fileHeaderSugnatire = new char[4];
            fileHeaderSugnatire =input.ReadChars(4);
            string checkOut = new string(fileHeaderSugnatire);
            if (!string.Equals(checkOut, FileHeaderSignatire, StringComparison.Ordinal))
                Console.WriteLine("Wrong header signatire");

            short version = input.ReadInt16();
            if(version<1||version>2)
                Console.WriteLine("Incorrect version");

            byte[] reserved = input.ReadBytes(6);
            foreach(int i in reserved)
                if (reserved[i]!=0)
                    Console.WriteLine("nonzero byte");

            short channels = input.ReadInt16();
            if(channels<1||channels>56)
                Console.WriteLine("Wrong number of channels");
            output.WriteLine("The number of channels is {0}", channels);

            int height = input.ReadInt32();
            if(height<1)
                Console.WriteLine("Smth wrong with height,expected at least 1");
            if(version==1 && height>30000)
                Console.WriteLine("Smth wrong with height,expected at most 30000");
            if (version == 2 && height > 300000)
                Console.WriteLine("Smth wrong with height,expected at most 300000");
            output.WriteLine("The height is{0}", height);

            int width = input.ReadInt32();
            if (width < 1)
                Console.WriteLine("Smth wrong with width,expected at least 1");
            if (version == 1 && width > 30000)
                Console.WriteLine("Smth wrong with width,expected at most 30000");
            if (version == 2 && width > 300000)
                Console.WriteLine("Smth wrong with width,expected at most 300000");
            output.WriteLine("The width is{0}", width);

            short depth = input.ReadInt16();
            if(depth!=1 || depth!=8 || depth != 16 || depth != 32)
                Console.WriteLine("Smth wrong with depth,expected 1,8,16 or 32");
            output.WriteLine("The depth is {0}", depth);

            short colorMode= input.ReadInt16();
            output.WriteLine("The color mode is {0}", ColorMode[colorMode]);

        }


    }
} 
