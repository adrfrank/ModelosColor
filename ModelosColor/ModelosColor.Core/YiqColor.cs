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
            throw new NotImplementedException();
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
