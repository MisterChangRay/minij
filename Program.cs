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
using minij.rtda;
using minij.rtda.heap;
using minij.instructions;

namespace minij
{
	class Program
	{
		public static   void  Main(string[] args)
		{
				
            parseArgs(args);
            if(args.Length > 0)
            {
                JVMConfig.config.mainClass = args[0];
            }
            initArgs(JVMConfig.config);

            initJVM();
            bootJVM();
		}

        private static   void  bootJVM()
        {

            Classpath c = new Classpath();
            c.init(JVMConfig.config);

            ClassLoader loader = new ClassLoader(c);

            Class clz = loader.load(JVMConfig.config.mainClass);
            Method method = clz.getMethod("main", "([Ljava/lang/String;)V", true);
            if(null == method) {
                Console.WriteLine("Not Found Main Method");
                return;
            }
            Interpreter inter = new Interpreter();
            inter.start(method);

        }

        private static   void  initJVM()
        {
            // todo
            NativeMethod.initNativeMethod();
        }

        private static   void  initArgs(JVMConfig config)
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

        static   void  HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
        }
        public static   void  parseArgs(string[] args) {
            CommandLine.Parser.Default.ParseArguments<JVMConfig>(args).WithParsed(o =>
            {
                JVMConfig.config = o;
            }).WithNotParsed(o => {
            });
		}
	}
}