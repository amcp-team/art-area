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
    /// The kind of layer mask. Almost universally <see cref="UsePerLayerValue"/>.
    /// </summary>
    public enum LayerMaskKind : byte
    {
        /// <summary>
        /// Color selected, i.e. inverted.
        /// </summary>
        ColorSelected = 0,

        /// <summary>
        /// Color protected.
        /// </summary>
        ColorProtected = 1,

        /// <summary>
        /// Use the values stored with each layer.
        /// </summary>
        UsePerLayerValue = 128
    }
}