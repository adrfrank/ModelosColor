using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.Core.Interfacces
{
    interface ICmykComatible
    {
        CmykColor ToCmyk(CmykType type = CmykType.CmyNormalized);
    }
}
