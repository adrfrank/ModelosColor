using ModelosColor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.UI.ViewModels
{
    public enum ColorModel
    {
        Rgb, RgbPerc, RgbByte, Cmy, Cmyk, Hsv, Xyz, Yiq
    }
    class ConvertColorsViewModel : AdrfrankLibrary.Core.NotifyPropetryAdapter
    {
        RgbColor basecolor = new RgbColor();
        bool changingValues = false;
        float rgbR, rgbG, rgbB,
            rgbPercR, rgbPercG, rgbPercB,
            rgbByteR, rgbByteG, rbgByteB,
            cmyC, cmyM, cmyY,
            cmykC, cmykM, cmykY, cmykK,
            hsvH, hsvS, hsvV,
            xyzX, xyzY, xyzZ,
            yiqY, yiqI, yiqQ;

        public float RgbR
        {
            get { return rgbR; }
            set { rgbR = value; }
        }

        public float RgbG
        {
            get { return rgbG; }
            set { rgbG = value; }
        }

        public float RgbB
        {
            get { return rgbB; }
            set { rgbB = value; }
        }

        public float RgbPercR
        {
            get { return rgbPercR; }
            set { rgbPercR = value; }
        }

        public float RgbPercG
        {
            get { return rgbPercG; }
            set { rgbPercG = value; }
        }

        public float RgbPercB
        {
            get { return rgbPercB; }
            set { rgbPercB = value; }
        }

        public float RgbByteR
        {
            get { return rgbByteR; }
            set { rgbByteR = value; }
        }

        public float RgbByteG
        {
            get { return rgbByteG; }
            set { rgbByteG = value; }
        }

        public float RbgByteB
        {
            get { return rbgByteB; }
            set { rbgByteB = value; }
        }

        public float CmyC
        {
            get { return cmyC; }
            set { cmyC = value; }
        }

        public float CmyM
        {
            get { return cmyM; }
            set { cmyM = value; }
        }

        public float CmyY
        {
            get { return cmyY; }
            set { cmyY = value; }
        }

        public float CmykC
        {
            get { return cmykC; }
            set { cmykC = value; }
        }

        public float CmykM
        {
            get { return cmykM; }
            set { cmykM = value; }
        }

        public float CmykY
        {
            get { return cmykY; }
            set { cmykY = value; }
        }

        public float CmykK
        {
            get { return cmykK; }
            set { cmykK = value; }
        }

        public float HsvH
        {
            get { return hsvH; }
            set { hsvH = value; }
        }

        public float HsvS
        {
            get { return hsvS; }
            set { hsvS = value; }
        }

        public float HsvV
        {
            get { return hsvV; }
            set { hsvV = value; }
        }

        public float XyzX
        {
            get { return xyzX; }
            set { xyzX = value; }
        }

        public float XyzY
        {
            get { return xyzY; }
            set { xyzY = value; }
        }

        public float XyzZ
        {
            get { return xyzZ; }
            set { xyzZ = value; }
        }

        public float YiqY
        {
            get { return yiqY; }
            set { yiqY = value; }
        }

        public float YiqI
        {
            get { return yiqI; }
            set { yiqI = value; }
        }

        public float YiqQ
        {
            get { return yiqQ; }
            set { yiqQ = value; }
        }
        public ConvertColorsViewModel()
        {

        }

        void update(ColorModel source)
        {
            basecolor = new RgbColor();
            switch (source)
            {
                case ColorModel.Rgb:
                    basecolor.R = rgbR;
                    basecolor.G = rgbG;
                    basecolor.B = rgbB;
                    break;
                case ColorModel.RgbPerc:

                    break;
                case ColorModel.RgbByte:
                    break;
                case ColorModel.Cmy:
                    break;
                case ColorModel.Cmyk:
                    break;
                case ColorModel.Hsv:
                    break;
                case ColorModel.Xyz:
                    break;
                case ColorModel.Yiq:
                    break;
                default:
                    break;
            }
        }

        
    }
}
