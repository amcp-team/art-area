using System;
using System.Collections.Generic;
using System.IO;
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

        public static PsdFile Read(FileStream stream)
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

        private static void ReadHeader(PsdFile psd, FileStream stream)
        {
        }

        private static void ReadColorModeData(PsdFile psd, FileStream stream)
        {
        }

        private static void ReadImageResources(PsdFile psd, FileStream stream)
        {
        }

        private static void ReadLayerAndMaskInformation(PsdFile psd, FileStream stream)
        {
        }

        private static void CreateImagedataPlaceholder(PsdFile psd, FileStream stream)
        {
        }   
    }
}
