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
            if (JVMConfig.config.verbose) {
                Console.WriteLine("打开详细输出模式");
                Console.WriteLine("启动类:" + JVMConfig.config.mainClass);
                Console.WriteLine("用户JRE目录:" + JVMConfig.config.jrehome);
            }
            

            Console.ReadKey(true);
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