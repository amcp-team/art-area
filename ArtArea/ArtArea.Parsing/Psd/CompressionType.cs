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

namespace ArtArea.Parse.Psd
{
    /// <summary>
    /// The compression type of image data.
    /// </summary>
    public enum CompressionType : short
    {
        /// <summary>
        /// Raw, uncompressed data.
        /// </summary>
        RawData = 0,

        /// <summary>
        /// Data compressed using the lossless PackBits run-length encoding scheme.
        /// </summary>
        PackBits = 1,

        /// <summary>
        /// Data compressed using the Deflate algorithm.
        /// </summary>
        ZipWithoutPrediction = 2,

        /// <summary>
        /// Data compressed using the Deflate algorithm applied to a per-row delta-encoded version of the data.
        /// </summary>
        ZipWithPrediction = 3
    }
}