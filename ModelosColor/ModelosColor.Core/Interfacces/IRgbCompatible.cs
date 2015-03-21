using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.Core.Interfacces
{
    interface IRgbCompatible
    {
        RgbColor ToRgb(RgbType type = RgbType.Normalized);
    }
}
