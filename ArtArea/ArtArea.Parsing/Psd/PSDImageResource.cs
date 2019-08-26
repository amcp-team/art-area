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
    public class PSDImageResource
    {
        /// <summary>
        /// Identifier for image resources. Any other value should be treated as error
        /// </summary>
        internal const string Signature = "8BIM";

        /// <summary>
        /// The ID of the image resource.
        /// </summary>
        public short ID { get; set; }

        /// <summary>
        /// The name of the image resource. Very often an empty string.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The data of the image resource.
        /// </summary>
        public byte[] Data { get; set; }
    }
}