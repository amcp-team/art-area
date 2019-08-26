// LICENSE NOTICE
//
// This file is part of Art Area.
// 
// Art Area is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Art Area is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Art Area.  If not, see<https://www.gnu.org/licenses/>.

using System.Collections.Generic;

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
    public class PhotoshopFile
    {
        #region File Format Constants

        /// <summary>
        /// The minimum number of channels a PSD file must contain.
        /// </summary>
        public const short MinChannels = 1;

        /// <summary>
        /// The maximum number of channels a PSD file can contain.
        /// </summary>
        public const short MaxChannels = 56;

        /// <summary>
        /// The maximum value supported by PSD version 1 for image width and height.
        /// </summary>
        public const int PsdMaxDimention = 30000;

        /// <summary>
        /// The maximum value supported by PSD version 2 for image width and height.
        /// </summary>
        public const int PsbMaxDemension = 300000;

        #endregion

        #region Header Data Section

        /// The file header contains the basic properties of the image.

        /// <summary>
        /// 1 - for .psd, 2 - for .psb (big file format which causes some field size doubling
        /// <para>Length: 2 bytes</para>
        /// </summary>
        public short Version { get; set; }

        /// <summary>
        /// Supported range [1, 56]
        /// <para>Length: 2 bytes</para>
        /// </summary>
        public short NumberOfChannels { get; set; }

        /// <summary>
        /// The width of the image in pixels. Supported range is 1 to 30000
        /// <para>Length: 4 bytes</para>
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the image in pixels. Supported range is 1 to 30000
        /// <para>Length: 4 bytes</para>
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The number of bits per channel. Supported values are 1, 8, 16 and 32
        /// <para>Length: 2 bytes</para>
        /// </summary>
        public short Depth { get;set; }

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
        public ColorMode ColorMode { get; set; }

        #endregion

        #region Color Mode Data Section

        ///  Only indexed color and duotone(see the mode field in the File header section) have color 
        ///  mode data.For all other modes, this section is just the 4-byte length field, which is 
        ///  set to zero.
        ///
        ///  Indexed color images: length is 768; color data contains the color table for the image, 
        ///  in non-interleaved order.
        ///
        ///  Duotone images: color data contains the duotone specification (the format of which is 
        ///  not documented). Other applications that read Photoshop files can treat a duotone image 
        ///  as a gray image, and just preserve the contents of the duotone information when reading 
        ///  and writing the file.

        /// <summary>
        /// Contains 0 if there is no color data, for Indexed color images contains 768, for Duotone 
        /// images length varies
        /// <para>
        ///     Length: 4 bytes
        /// </para>
        /// </summary>
        public int ColorDataLength { get; set; }

        /// <summary>
        /// Not empty only for images with <see cref="ColorMode.Indexed"/> or 
        /// <see cref="ColorMode.Duotone"/> color mode
        /// </summary>
        public byte[] ColorData { get; set; }

        #endregion

        #region Image Resources Section

        /// Image resource blocks are the basic building unit of several file formats, including 
        /// Photoshop's native file format, JPEG, and TIFF. Image resources are used to store 
        /// non-pixel data associated with images, such as pen tool paths.
        ///
        /// They are referred to as resource blocks because they hold data that was stored in the 
        /// Macintosh's resource fork in early versions of Photoshop.
        ///
        /// The basic structure of image resource blocks is shown in the Image resource block. 
        /// The last field is the data area, which varies by resource type.The makeup of each 
        /// resource type is described in the following sections.


        /// <summary>
        /// Length of image resource section. The length may be zero.
        /// <para>Length: 4 bytes</para>
        /// </summary>
        public int ImageRecourceLength { get; set; }

        /// <summary>
        /// Image resources of the PSD file, primarily metadata.
        /// <para>Length: variable</para>
        /// </summary>
        public List<PSDImageResource> ImageResources { get; set; }
        #endregion

        #region Layer and Mask Information Section

        #endregion

        #region Image Data Section

        #endregion
    }
}
