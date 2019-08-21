using System;
using System.Collections.Generic;
using System.Text;

namespace ArtArea.Parsing.Psd
{
    /// <summary>
    /// Represents am Adobe Photoshop .psd file that stores only non-constant data
    /// which will be enough for rebuilding .psd file from it and also finding 
    /// difference (delta) between 2 .psd files
    /// <para>
    ///     For .psd file structure see 
    ///     <see href="https://www.adobe.com/devnet-apps/photoshop/fileformatashtml/">
    ///         Adobe Photoshop File Formats Specification
    ///     </see>
    /// </para>
    /// <seealso cref="PsdParser"/>
    /// </summary>
    public class PsdFile
    {
        #region Header Data Section

        // The file header contains the basic properties of the image.

        /// <summary>
        /// Supported range [1, 56]
        /// <para>Length: 2 bytes</para>
        /// </summary>
        public byte NumberOfChannels { get; set; }
        /// <summary>
        /// The width of the image in pixels. Supported range is 1 to 30000
        /// <para>Length: 4 bytes</para>
        /// </summary>
        public short Width { get; set; }
        /// <summary>
        /// The height of the image in pixels. Supported range is 1 to 30000
        /// <para>Length: 4 bytes</para>
        /// </summary>
        public short Height { get; set; }
        /// <summary>
        /// The number of bits per channel. Supported values are 1, 8, 16 and 32
        /// <para>Length: 2 bytes</para>
        /// </summary>
        public byte Depth { get;set; }
        /// <summary>
        /// The color mode of the file. Supported values are: 
        ///     Bitmap = 0; 
        ///     Grayscale = 1; 
        ///     Indexed = 2; 
        ///     RGB = 3; 
        ///     CMYK = 4; 
        ///     Multichannel = 7; 
        ///     Duotone = 8; 
        ///     Lab = 9
        /// <para>Length: 2 bytes</para>
        /// </summary>
        public byte ColorMode { get; set; }

        #endregion

        #region Color Mode Data Section

        //  Only indexed color and duotone(see the mode field in the File header section) have color 
        //  mode data.For all other modes, this section is just the 4-byte length field, which is 
        //  set to zero.
        //
        //  Indexed color images: length is 768; color data contains the color table for the image, 
        //  in non-interleaved order.
        //
        //  Duotone images: color data contains the duotone specification (the format of which is 
        //  not documented). Other applications that read Photoshop files can treat a duotone image 
        //  as a gray image, and just preserve the contents of the duotone information when reading 
        //  and writing the file.

        /// <summary>
        /// Contains 0 if there is no color data, for Indexed color images contains 768, for Duotone 
        /// images length varies
        /// <para>
        ///     Length: 4 bytes
        /// </para>
        /// </summary>
        public int ColorDataLength { get; set; }
        /// <summary>
        /// Not empty only for images with indexed or Duotone color mode
        /// </summary>
        public byte[] ColorData { get; set; }

        #endregion

        #region Image Resources Section

        #endregion

        #region Layer and Mask Information Section

        #endregion

        #region Image Data Section

        #endregion
    }
}
