/*
 * Created by SharpDevelop.
 * User: Mrui
 * Date: 2021/6/26
 * Time: 9:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CommandLine;
using System.Collections.Generic;
using System.Collections;
using minij.classpath;
using minij.classfile;

namespace minij
{
	class Program
	{
		public static void Main(string[] args)
		{
				
            parseArgs(args);
            if(args.Length > 0)
            {
                JVMConfig.config.mainClass = args[0];
            }
            initArgs(JVMConfig.config);

            

            Classpath c = new Classpath();
            c.init(JVMConfig.config);
            byte[] res = c.read(JVMConfig.config.mainClass);
            ClassFile cf = new ClassFile(res);
            cf.parse();
            



            Console.WriteLine(BitConverter.ToString(res));
            Console.ReadKey(true);
		}

        private static void initArgs(JVMConfig config)
        {
       

            if (config.cp != null ) {
                config.classpath = config.cp;
            }
            if (config.classpath != null)
            {
                config.cp = config.classpath;
            }


            if (JVMConfig.config.verbose)
            {
                Console.WriteLine("打开详细输出模式");
                Console.WriteLine("启动类:" + JVMConfig.config.mainClass);
                Console.WriteLine("用户JRE目录:" + JVMConfig.config.Xjre);
                Console.WriteLine("CLASSPATH:" + JVMConfig.config.cp);
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
        }
        public static void parseArgs(string[] args) {
            CommandLine.Parser.Default.ParseArguments<JVMConfig>(args).WithParsed(o =>
            {
                JVMConfig.config = o;
            }).WithNotParsed(o => {
            });
		}
	}
}