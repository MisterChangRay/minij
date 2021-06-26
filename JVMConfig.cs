using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij
{
    public class JVMConfig
    {
        public static JVMConfig config;

        [Option(shortName: 'v', longName:"verbose", Required = false, HelpText = "set out to verbose message")]
        public bool verbose { get; set; }
        [Option(longName: "cp", Required = false, HelpText = "set classpath")]
        public string cp { get; set; }
        [Option(longName:"classpath", Required = false, HelpText = "set classpath")]
        public string classpath { get; set; }
        [Option(longName:"jrehome", Required = false, HelpText = "set jre home dir")]
        public string jrehome { get; set; }

        [Option(longName: "mainClass", Required = false, HelpText = "set main class")]
        public string mainClass { get; set; }
    }
}
