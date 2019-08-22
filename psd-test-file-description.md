# Description for .psd files used for testing

[**Download files**](https://drive.google.com/file/d/1dt4qlkiyT5oUKGm5DBfYVcxXGDnZ-dt4/view?usp=sharing)

By default files are placed into `\ArtArea\TestSourceFiles\`

## How to undestand file default settings?

For quicker testing names of files cosist of key parameters (devided by `-`) used for building them:

`file_name-width-height-resolution-resolution_type-color_mode-depth-white?`

- `file_name` represents what is in file (if it is empty, than file name is so)
- `width` & `height` obviously represent file width & height
- `resolution` is number (by default it is 300)
- `resultion_type` is number 
  - 1 => Pixels/Inch
  - 2 => Pixels/Centimeter 
- `color_mode` is used color mode
        
  My Photoshop version supports only 
  - 1 => *Bitmap*
  - 2 => *Grayscale* 
  - 3 => *RGB Color* 
  - 4 => *CMYK Color* 
  - 5 => *Lab Color*

- `depth` is amount of bits for color mode option
  - 1 => 8 bit
  - 2 => 16 bit
  - 3 => 32 bit

- `white?` takes 1 for true & 0 for false, which means that this file was basically with white or transparent background 

Defaults:
- Color Profile : Working RGB: sRGB IEC61966-2.1
- Pixel Aspect Ration : Square Pixels

## File list

- `empty-512-512-300-1-3-1-1` : empty file
- `irden-512-512-300-1-3-1-1` : irden sign from Witcher 3 game
- `dots-512-512-300-1-3-1-1` : some randomly place round dots

---

**Add more files** :rocket:
