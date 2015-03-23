using ModelosColor.Core.Interfacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.Core
{
    public class XyzColor : IRgbCompatible, IYiqCompatible, ICmykComatible, IXyzCompatible, IHsvCompatible
    {
        #region static values
        static float[,] rgbmatconv = { 
                                     { 2.37067f, -0.90004f, -0.47063f }, 
                                     {-0.51388f, 1.42530f, 0.08858f }, 
                                     {0.00530f, -0.01469f, 1.00940f } };
        #endregion

        float x, y, z;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Z
        {
            get { return z; }
            set { z = value; }
        }


        public RgbColor ToRgb(RgbType type = RgbType.Normalized)
        {
   
            float[] colors = { x,y,z };
            var converted = new RgbColor();
            for (int i = 0; i < 3; i++)
            {
                converted.R += rgbmatconv[0, i] * colors[i];
                converted.G += rgbmatconv[1, i] * colors[i];
                converted.B += rgbmatconv[2, i] * colors[i];

            }
            return converted.ToRgb  (type);
        }

        public YiqColor ToYiq()
        {
            return ToRgb().ToYiq();
        }

        public CmykColor ToCmyk(CmykType type = CmykType.CmyNormalized)
        {
            return ToRgb().ToCmyk(type);
        }

        public XyzColor ToXyz()
        {
            return this;
        }

        public HsvColor ToHsv()
        {
            return ToRgb().ToHsv();
        }
    }
}
