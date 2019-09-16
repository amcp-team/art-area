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
    /// A constituent channel of a layer in a PSD file.
    /// </summary>
    public class PSDLayerChannel
    {
        /// <summary>
        /// The ID of this channel.
        /// </summary>
        public short ID { get; set; }

        /// <summary>
        /// The length of the data of the channel. This property is only a mule; the value is eventually stored in
        /// <see cref="PSDLayerChannelDataPlaceholder.DataLength"/> in <see cref="Data"/>.
        /// </summary>
        internal long DataLength { get; set; }

        /// <summary>
        /// A placeholder for the data of this channel.
        /// </summary>
        public PSDLayerChannelDataPlaceholder Data { get; set; }
    }
}