using ModelosColor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ModelosColor.UI.ViewModels
{
    public enum ColorModel
    {
        Rgb, RgbPerc, RgbByte, Cmy, Cmyk, Hsv, Xyz, Yiq, hex
    }
    public class ConvertColorsViewModel : AdrfrankLibrary.Core.NotifyPropetryAdapter
    {
        RgbColor basecolor = new RgbColor();
        bool changingValues = false;
        float rgbR, rgbG, rgbB,
            rgbPercR, rgbPercG, rgbPercB,
            rgbByteR, rgbByteG, rgbByteB,
            cmyC, cmyM, cmyY,
            cmykC, cmykM, cmykY, cmykK,
            hsvH, hsvS, hsvV,
            xyzX, xyzY, xyzZ,
            yiqY, yiqI, yiqQ;
        string hex;

        public string Hex
        {
            get {
                hex = hex ?? basecolor.Hex;
                return hex; }
            set { hex = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.hex); }
        }

        #region Color Properties

        public float RgbR
        {
            get { return rgbR; }
            set { rgbR = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.Rgb);  }
        }

        public float RgbG
        {
            get { return rgbG; }
            set { rgbG = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Rgb); }
        }

        public float RgbB
        {
            get { return rgbB; }
            set { rgbB = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Rgb); }
        }

        public float RgbPercR
        {
            get { return rgbPercR; }
            set { rgbPercR = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.RgbPerc); }
        }

        public float RgbPercG
        {
            get { return rgbPercG; }
            set { rgbPercG = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.RgbPerc); }
        }

        public float RgbPercB
        {
            get { return rgbPercB; }
            set { rgbPercB = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.RgbPerc); }
        }

        public float RgbByteR
        {
            get { return rgbByteR; }
            set { rgbByteR = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.RgbByte); }
        }

        public float RgbByteG
        {
            get { return rgbByteG; }
            set { rgbByteG = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.RgbByte); }
        }

        public float RgbByteB
        {
            get { return rgbByteB; }
            set { rgbByteB = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.RgbByte); }
        }

        public float CmyC
        {
            get { return cmyC; }
            set { cmyC = value; OnPropertyChanged(); if(!changingValues) update(ColorModel.Cmy); }
        }

        public float CmyM
        {
            get { return cmyM; }
            set { cmyM = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Cmy); }
        }

        public float CmyY
        {
            get { return cmyY; }
            set { cmyY = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Cmy); }
        }

        public float CmykC
        {
            get { return cmykC; }
            set { cmykC = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Cmyk); }
        }

        public float CmykM
        {
            get { return cmykM; }
            set { cmykM = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Cmyk); }
        }

        public float CmykY
        {
            get { return cmykY; }
            set { cmykY = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Cmyk); }
        }

        public float CmykK
        {
            get { return cmykK; }
            set { cmykK = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Cmyk); }
        }

        public float HsvH
        {
            get { return hsvH; }
            set { hsvH = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Hsv); }
        }

        public float HsvS
        {
            get { return hsvS; }
            set { hsvS = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Hsv); }
        }

        public float HsvV
        {
            get { return hsvV; }
            set { hsvV = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Hsv); }
        }

        public float XyzX
        {
            get { return xyzX; }
            set { xyzX = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Xyz); }
        }

        public float XyzY
        {
            get { return xyzY; }
            set { xyzY = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Xyz); }
        }

        public float XyzZ
        {
            get { return xyzZ; }
            set { xyzZ = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Xyz); }
        }

        public float YiqY
        {
            get { return yiqY; }
            set { yiqY = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Yiq); }
        }

        public float YiqI
        {
            get { return yiqI; }
            set { yiqI = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Yiq); }
        }

        public float YiqQ
        {
            get { return yiqQ; }
            set { yiqQ = value; OnPropertyChanged(); if (!changingValues) update(ColorModel.Yiq); }
        }

        #endregion

        public SolidColorBrush RectColor
        {
            get
            {
                var c = basecolor.ToRgb(RgbType.Byte);
                SolidColorBrush color = new SolidColorBrush(new Color() { R = (byte)c.R, G = (byte)c.G, B = (byte)c.B, A = 255 });
                Debug.WriteLine(color);
                return color;
            }
        }

        public ConvertColorsViewModel()
        {
            update(ColorModel.Rgb);
        }

        RgbColor GetBaseColor(ColorModel source)
        {
            basecolor = new RgbColor();
            switch (source)
            {
                case ColorModel.Rgb:
                    basecolor.R = RgbR;
                    basecolor.G = RgbG;
                    basecolor.B = RgbB;
                    break;
                case ColorModel.RgbPerc:
                    basecolor = new RgbColor(RgbType.Percent) { R = RgbPercR, G = RgbPercG, B = RgbPercB }.ToRgb();
                    break;
                case ColorModel.RgbByte:
                    basecolor = new RgbColor(RgbType.Byte) { R = RgbByteR, G = RgbByteG, B = RgbByteB }.ToRgb();
                    break;
                case ColorModel.Cmy:
                    basecolor = new CmykColor() { C = CmyC, M = CmyM, Y = CmyY }.ToRgb();
                    break;
                case ColorModel.Cmyk:
                    basecolor = new CmykColor(CmykType.CmykNormalized) { C = CmykC, M = CmykM, Y = CmykY, K = CmykK }.ToRgb();
                    break;
                case ColorModel.Hsv:
                    basecolor = new HsvColor() { H = HsvH, S = HsvS, V = HsvV }.ToRgb();
                    break;
                case ColorModel.Xyz:
                    basecolor = new XyzColor() { X = XyzX, Y = XyzY, Z = XyzZ }.ToRgb();
                    break;
                case ColorModel.Yiq:
                    basecolor = new YiqColor() { Y = YiqY, I = YiqI, Q = YiqQ }.ToRgb();
                    break;
                case ColorModel.hex:
                    basecolor = new RgbColor(){ Hex= Hex}.ToRgb();
                    break;
            }
            return basecolor;
        }

        void update(ColorModel source)
        {
            changingValues = true;
            GetBaseColor(source);
            if (source != ColorModel.Rgb)
            {
                RgbR = basecolor.R;
                RgbG = basecolor.G;
                RgbB = basecolor.B;
            }
            if (source != ColorModel.RgbPerc)
            {
                try
                {
                    var c = basecolor.ToRgb(RgbType.Percent);
                    RgbPercR = c.R;
                    RgbPercG = c.G;
                    RgbPercB = c.B;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }
            }
            if (source != ColorModel.RgbByte)
            {
                var c = basecolor.ToRgb(RgbType.Byte);
                RgbByteR = c.R;
                RgbByteG = c.G;
                RgbByteB = c.B;
            }
            if (source != ColorModel.Cmy)
            {
                var c = basecolor.ToCmyk();
                CmyC = c.C;
                CmyM = c.M;
                CmyY = c.Y;
            }
            if (source != ColorModel.Cmyk)
            {
                var c = basecolor.ToCmyk(CmykType.CmykNormalized);
                CmykC = c.C;
                CmykM = c.M;
                CmykY = c.Y;
                CmykK = c.K;
            }
            if (source != ColorModel.Hsv)
            {
                try
                {
                    var c = basecolor.ToHsv();
                    HsvH = c.H;
                    HsvS = c.S;
                    HsvV = c.V;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            if (source != ColorModel.Xyz)
            {
                var c = basecolor.ToXyz();
                XyzX = c.X;
                XyzY = c.Y;
                XyzZ = c.Z;
            }
            if (source != ColorModel.Yiq)
            {
                var c = basecolor.ToYiq();
                YiqY = c.Y;
                YiqI = c.I;
                YiqQ = c.Q;
            }
            if (source != ColorModel.hex)
            {
                var c = basecolor;
                Hex = c.Hex;
            }
            OnPropertyChanged("RectColor");
            changingValues = false;
        }

    }
}
