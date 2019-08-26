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

namespace ArtArea.Parsing.Psd
{
    /// <summary>
    /// Image Color Mode
    /// </summary>
    public enum ColorMode : short
    {
        /// <summary>
        /// A bitmap image (0 or 1 for each pixel).
        /// </summary>
        Bitmap = 0,

        /// <summary>
        /// A grayscale image.
        /// </summary>
        Grayscale = 1,

        /// <summary>
        /// An index image (color palette and indices).
        /// </summary>
        Indexed = 2,

        /// <summary>
        /// An RGB image (red, green and blue components).
        /// </summary>
        RGB = 3,

        /// <summary>
        /// A CMYK image (cyan, magenta, yellow and black components).
        /// </summary>
        CMYK = 4,

        /// <summary>
        /// An image with a custom number of channels.
        /// </summary>
        Multichannel = 7,

        /// <summary>
        /// An image with two components (often black and a spot color).
        /// </summary>
        Duotone = 8,

        /// <summary>
        /// An image in the CIE Lab color space.
        /// </summary>
        Lab = 9
    }
}
