using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosColor.Core
{
    public class HsvColor
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
    }
}
