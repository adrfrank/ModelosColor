using ModelosColor.Core.Interfacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.Core
{
    public class YiqColor : IRgbCompatible, ICmykComatible, IHsvCompatible, IXyzCompatible, IYiqCompatible
    {
        static float[,] rgbmatconv = { 
                                    {1.0f,1.0f,0.0f},
                                   {1.0f, -0.509f, -0.194f},
                                   {1.0f, 0.0f, 1.0f}
                                   };

        float y, i, q;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float I
        {
            get { return i; }
            set { i = value; }
        }

        public float Q
        {
            get { return q; }
            set { q = value; }
        }


        public RgbColor ToRgb(RgbType type = RgbType.Normalized)
        {
            float[] colors = { y, i, q };
            var converted = new RgbColor();
            for (int j = 0; j < 3; j++)
            {
                converted.R += rgbmatconv[0, j] * colors[j];
                converted.G += rgbmatconv[1, j] * colors[j];
                converted.B += rgbmatconv[2, j] * colors[j];

            }
            return converted.ToRgb(type);
        }

        public CmykColor ToCmyk(CmykType type = CmykType.CmyNormalized)
        {
            return ToRgb().ToCmyk(type);
        }

        public HsvColor ToHsv()
        {
            return ToRgb().ToHsv();
        }

        public XyzColor ToXyz()
        {
            return ToRgb().ToXyz();
        }

        public YiqColor ToYiq()
        {
            return this;
        }
    }
}
