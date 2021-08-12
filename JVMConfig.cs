using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij
{
    public class JVMConfig
    {


        public bool verbose { get; set; }
        public string cp { get; set; }
        public string classpath { get; set; }
        public string Xjre { get; set; }
        public string mainClass { get; set; }
        public string[] bootArgs { get; set; }


    }


}
