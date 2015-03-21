using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelosColor.Core.Interfacces;

namespace ModelosColor.Core
{

    public enum RgbType
    {
        Normalized,
        Byte, 
        Percent
    }

    public class RgbColor: IRgbCompatible, IYiqCompatible,ICmykComatible, IXyzCompatible
    {
        #region static values
        static float[,] yiqmatconv ={
                                    {0.229f, 0.587f, 0.114f},
                                    {0.701f, -0.587f, -0.114f },
                                    {-0.299f, -0.587f, 0.886f} 
                                    };
        static float[,] xyzmatconv ={
                                    {0.48872f, 0.31068f, 0.20060f},
                                    {0.17620f, 0.81298f, 0.01081f },
                                    {0.0f, 0.01020f, 0.98980f} 
                                    };   
                                                                      
                                        
        #endregion

        float r, g, b;
        RgbType type;

        public RgbType Type
        {
            get { return type; }
            private set { type = value; }
        }

        public float R
        {
            get { return r; }
            set { r = value; }
        }

        public float G
        {
            get { return g; }
            set { g = value; }
        }

        public float B
        {
            get { return b; }
            set { b = value; }
        }

        public string Hex {
            set { }

        }

        public RgbColor(RgbType type = RgbType.Normalized) {
            Type = type;
        }

        #region Interfaces
        public RgbColor ToRgb(RgbType type = RgbType.Normalized)
        {
            RgbColor color;
            if (type == RgbType.Normalized)
            {
                color = this;
                switch (Type)
                {
                    case RgbType.Percent:
                        color = new RgbColor(type);
                        color.r = r / 100f;
                        color.g = g / 100f;
                        color.b = b / 100f;
                        break;
                    case RgbType.Byte:
                        color = new RgbColor(type);
                        color.r = r / 255f;
                        color.g = g / 255f;
                        color.b = b / 255f;
                        break;
                }
            }
            else
            {
                if (Type == RgbType.Normalized)
                {
                    color = this;
                    switch (type)
                    {
                        case RgbType.Byte:
                            color = new RgbColor(type);
                            color.r = (int)(r * 255);
                            color.g = (int)(g * 255);
                            color.b = (int)(b * 255);
                            break;
                        case RgbType.Percent:
                            color = new RgbColor(type);
                            color.r = r * 100f;
                            color.g = g * 100f;
                            color.b = b * 100f;
                            break;
                    }
                }
                else
                {
                    color = ToRgb().ToRgb(type);
                }
            }
            return color;
        }

        #endregion


        public YiqColor ToYiq()
        {
            var color = ToRgb(); //normalize
            float[] colors = { color.r, color.g, color.b };
            var converted = new YiqColor();
            for (int i = 0; i < 3; i++)
            {
                converted.Y += yiqmatconv[0, i] * colors[i];
                converted.I += yiqmatconv[1, i] * colors[i];
                converted.Q += yiqmatconv[2, i] * colors[i];
               
            }
            return converted;
        }

        public CmykColor ToCmyk(CmykType type=CmykType.CmyNormalized)
        {
            var color = ToRgb();//normalize
            var converted = new CmykColor();
            converted.C = 1 - color.r;
            converted.M = 1 - color.g;
            converted.Y = 1 - color.b;

            return converted.ToCmyk(type);
        }

        public XyzColor ToXyz()
        {
            var color = ToRgb(); //normalize
            float[] colors = { color.r, color.g, color.b };
            var converted = new XyzColor();
            for (int i = 0; i < 3; i++)
            {
                converted.X += xyzmatconv[0, i] * colors[i];
                converted.Y += xyzmatconv[1, i] * colors[i];
                converted.Z += xyzmatconv[2, i] * colors[i];

            }
            return converted;
        }
    }
}
