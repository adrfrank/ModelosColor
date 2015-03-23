using ModelosColor.Core.Interfacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.Core
{
    public enum CmykType
    {
        CmykNormalized,
        CmyNormalized
    }

    public class CmykColor : IRgbCompatible, IYiqCompatible, ICmykComatible, IXyzCompatible, IHsvCompatible
    {
        float c, m, y, k;
        CmykType type;

        public CmykType Type
        {
            get { return type; }
            set { type = value; }
        }

        public float C
        {
            get { return c; }
            set { c = value; }
        }

        public float M
        {
            get { return m; }
            set { m = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float K
        {
            get { return k; }
            set { k = value; }
        }

        public CmykColor(CmykType type = CmykType.CmyNormalized){
            Type = type;
        }

        public CmykColor ToCmyk(CmykType type = CmykType.CmyNormalized)
        {
            if (type == Type)
                return this;
            var color = new CmykColor(type);

            if (type == CmykType.CmykNormalized) //cmk to cmyk
            {
                color.k = Math.Min(Math.Min(c, m), y);
                color.c = c - color.k;
                color.m = m - color.k;
                color.y = y - color.k;

            }
            else //cmyk to cmy
            {
                color.c += k;
                color.m += k;
                color.y += k;
            }

            return color;
        }

        public RgbColor ToRgb(RgbType type = RgbType.Normalized)
        {
            var color = ToCmyk(CmykType.CmyNormalized);
            var converted = new RgbColor();
            converted.R = 1 - color.c;
            converted.G = 1 - color.m;
            converted.B = 1 - color.y;
            return converted.ToRgb(type);
        }

        public YiqColor ToYiq()
        {
            return ToRgb().ToYiq();
        }

        public XyzColor ToXyz()
        {
            return ToRgb().ToXyz();
        }

        public HsvColor ToHsv()
        {
            return ToRgb().ToHsv();
        }
    }
}
