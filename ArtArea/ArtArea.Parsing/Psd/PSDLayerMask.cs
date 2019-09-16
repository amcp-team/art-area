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
    public class PSDLayerMask
    {
        /// <summary>
        /// The top offset in pixels, as a difference between the top edge of the layer and the top edge of the image.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// The left offset in pixels, as a difference between the left edge of the layer and the left edge of the
        /// image.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// The bottom offset in pixels, as a difference between the bottom edge of the layer and the bottom edge of
        /// the image.
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// The right offset in pixels, as a difference between the right edge of the layer and the right edge of the
        /// image.
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// The default color of the layer mask, either 0 or 255.
        /// </summary>
        public byte DefaultColor { get; set; }

        /// <summary>
        /// Whether the position of the mask is relative to the position of the layer.
        /// </summary>
        public bool PositionIsRelativeToLayerData { get; set; }

        /// <summary>
        /// Whether the layer mask is currently disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Whether to invert the mask when blending. Should be <c>false</c> in most newer PSD files.
        /// </summary>
        public bool InvertMaskWhenBlending { get; set; }

        /// <summary>
        /// Whether the user mask actually originates from rendering other data.
        /// </summary>
        public bool OriginatesFromRenderingOtherData { get; set; }

        /// <summary>
        /// The density of the user mask, or <c>null</c> if not specified.
        /// </summary>
        public byte? UserMaskDensity { get; set; }

        /// <summary>
        /// The feather of the user mask, or <c>null</c> if not specified.
        /// </summary>
        public double? UserMaskFeather { get; set; }

        /// <summary>
        /// The density of the vector mask, or <c>null</c> if not specified.
        /// </summary>
        public byte? VectorMaskDensity { get; set; }

        /// <summary>
        /// The feather of the vector mask, or <c>null</c> if not specified.
        /// </summary>
        public double? VectorMaskFeather { get; set; }
    }
}