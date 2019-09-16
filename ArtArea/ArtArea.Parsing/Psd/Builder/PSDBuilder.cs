using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArtArea.Parse.Psd.Builder
{
    public static class PsdBuilder
    {
        /// <summary>
        /// Constant signature of .psd file
        /// </summary>
        public const string Signature = "8BPS";

        /// <summary>
        /// Constant signature for layer info
        /// </summary>
        public const string AdditionalLayerInfoSignature = "8BIM";

        /// <summary>
        /// ALternative constant signature for layer info
        /// </summary>
        public const string AdditionalLayerInfoSignature_ = "8B64";

        public static PsdFile Read(Stream stream)
        {
            try
            {
                var psd = new PsdFile();

                ReadHeader(psd, stream);
                ReadColorModeData(psd, stream);
                ReadImageResources(psd, stream);
                ReadLayerAndMaskInformation(psd, stream);
                CreateImagedataPlaceholder(psd, stream);

                return psd;
            }
            catch(PsdBuildException)
            {
                throw;
            }
            catch(Exception e)
            {
                throw new PsdBuildException("Building .psd file object failed", e);
            }
        }

        /// <summary>
        /// Reades Header part of .psd/.psb file
        /// </summary>
        /// <param name="psd">Psd file that should be filled with new header values</param>
        /// <param name="stream">Stream to read .psd file</param>
        private static void ReadHeader(PsdFile psd, Stream stream)
        {
            // read file signature & chack if this file is valid .psd file
            string signature = stream.ReadUsAsciiString(4);

            if (!string.Equals(signature, Signature, StringComparison.Ordinal)) 
                throw new PsdBuildException(
                    $"File signature is not valid. " +
                    $"File signature \"{signature}\", expected signature \"{Signature}\"");

            // read file version (defines whether it .psd or .psb) & check if it's valid
            short version = stream.ReadBigEndianInt16();

            if (version < 1 || version > 2)
                throw new PsdBuildException(
                    $"File version is not valid. " +
                    $"File version \"{version}\", expected version 1 or 2");

            psd.Version = version;

            // read 6 reserved bytes & check if all of them are 0
            byte[] reserved = stream.ReadBytes(6);

            if (reserved.Any(b => b != 0x00))
                throw new PsdBuildException($"Non-zero bytes in reserved 6 bytes section");

            // read number of channels & check if it is limited correctly
            short numberOfChannels = stream.ReadBigEndianInt16();

            if (numberOfChannels < PsdFile.MinChannels || numberOfChannels > PsdFile.MaxChannels)
                throw new PsdBuildException($"Number of channels is out of bounds. " +
                    $"Number if channels {numberOfChannels} should be in [ {PsdFile.MinChannels}, {PsdFile.MaxChannels} ]");

            psd.NumberOfChannels = numberOfChannels;

            // read file height
            int height = stream.ReadBigEndianInt32();

            if (height < 1)
                throw new PsdBuildException($"File height is invalid. File height {height} should be > 0");

            // dependending on version check if file height is not more tham limit
            if (version == 1 ?
                height > PsdFile.PsdMaxDimention :
                height > PsdFile.PsbMaxDemension)
                throw new PsdBuildException(
                    $"File height is invalid. " +
                    $"File height shouldn't be more than {PsdFile.PsdMaxDimention} for .psd and {PsdFile.PsbMaxDemension} for .psb");

            psd.Height = height;

            // read file width
            int width = stream.ReadBigEndianInt32();

            if (width < 1)
                throw new PsdBuildException($"File width is invalid. File width {width} should be > 0");

            // dependending on version check if file width is not more tham limit
            if (version == 1 ?
                width > PsdFile.PsdMaxDimention :
                width > PsdFile.PsbMaxDemension)
                throw new PsdBuildException(
                    $"File width is invalid. " +
                    $"File width shouldn't be more than {PsdFile.PsdMaxDimention} for .psd and {PsdFile.PsbMaxDemension} for .psb");

            psd.Width = width;

            // read depth & chekc if it takes valid values
            short depth = stream.ReadBigEndianInt16();
            if (depth != 1 && depth != 8 && depth != 16 && depth != 32)
                throw new PsdBuildException($"File depth is invalid. File depth is {depth} and should be 1, 8, 16, 32");

            psd.Depth = depth;

            // read color mode, check if it's valid & convert to enum
            short colorMode = stream.ReadBigEndianInt16();
            if (!Enum.IsDefined(typeof(ColorMode), colorMode))
                throw new PsdBuildException($"Color mode takes invalid value. Color mode {colorMode}");

            psd.ColorMode = (ColorMode) colorMode;
        }

        /// <summary>
        /// Reades Color mode data if it's available
        /// </summary>
        /// <param name="psd">Psd file that should be filled with color mode data</param>
        /// <param name="stream">Stream to read .psd file</param>
        private static void ReadColorModeData(PsdFile psd, Stream stream)
        {
            int colorModeDataLength = stream.ReadBigEndianInt32();
            if (colorModeDataLength < 0)
                throw new PsdBuildException($"Color Mode Data Length takes invalid value {colorModeDataLength}");

            bool requiresColorModeData = (psd.ColorMode == ColorMode.Indexed || psd.ColorMode == ColorMode.Duotone);
            bool hasColorModeData = colorModeDataLength > 0;

            if (requiresColorModeData != hasColorModeData)
                throw new PsdBuildException($"Color mode {psd.ColorMode} requires color mode data, but it's length is 0");

            psd.ColorModeDataLength = colorModeDataLength;
            psd.ColorModeData = stream.ReadBytes(colorModeDataLength);
        }

        private static void ReadImageResources(PsdFile psd, Stream stream)
        {
        }

        private static void ReadLayerAndMaskInformation(PsdFile psd, Stream stream)
        {
        }

        private static void CreateImagedataPlaceholder(PsdFile psd, Stream stream)
        {

        }   
    }
}
