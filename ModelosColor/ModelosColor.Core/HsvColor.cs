using ModelosColor.Core.Interfacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.Core
{
    public class HsvColor : IHsvCompatible, IRgbCompatible, ICmykComatible, IXyzCompatible, IYiqCompatible
    {
        float h, s, v;

        public float H
        {
            get { return h; }
            set { h = value; }
        }

        public float S
        {
            get { return s; }
            set { s = value; }
        }

        public float V
        {
            get { return v; }
            set { v = value; }
        }

        public HsvColor ToHsv()
        {
            return this;
        }

        public RgbColor ToRgb(RgbType type = RgbType.Normalized)
        {
            float hh, p, q, t, ff;
            long i;
            RgbColor res = new RgbColor();

            if (this.s <= 0.0)
            {       // < is bogus, just shuts up warnthisgs
                res.R = this.v;
                res.G = this.v;
                res.B = this.v;
                return res;
            }
            hh = this.h;
            if (hh >= 360.0) hh = 0.0F;
            hh /= 60.0F;
            i = (long)hh;
            ff = hh - i;
            p = this.v * (1.0F - this.s);
            q = this.v * (1.0F - (this.s * ff));
            t = this.v * (1.0F - (this.s * (1.0F - ff)));

            switch (i)
            {
                case 0:
                    res.R = this.v;
                    res.G = t;
                    res.B = p;
                    break;
                case 1:
                    res.R = q;
                    res.G = this.v;
                    res.B = p;
                    break;
                case 2:
                    res.R = p;
                    res.G = this.v;
                    res.B = t;
                    break;

                case 3:
                    res.R = p;
                    res.G = q;
                    res.B = this.v;
                    break;
                case 4:
                    res.R = t;
                    res.G = p;
                    res.B = this.v;
                    break;
                case 5:
                default:
                    res.R = this.v;
                    res.G = p;
                    res.B = q;
                    break;
            }
            return res.ToRgb(type);
        }

        public CmykColor ToCmyk(CmykType type = CmykType.CmyNormalized)
        {
            return ToRgb().ToCmyk(type);
        }

        public XyzColor ToXyz()
        {
            return ToRgb().ToXyz();
        }

        public YiqColor ToYiq()
        {
            return ToRgb().ToYiq();
        }
    }
}
