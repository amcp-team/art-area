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
    public class PSDLayerChannelDataPlaceholder
    {
        /// <summary>
        /// The method used to compress the layer data.
        /// </summary>
        public CompressionType Compression { get; set; }

        /// <summary>
        /// The byte position in the PSD file at which the layer data starts.
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// The length of the layer data, as it appears in the PSD file (after compression, if any).
        /// </summary>
        public long DataLength { get; set; }
    }
}