/*
 * Created by SharpDevelop.
 * User: Mrui
 * Date: 2021/6/26
 * Time: 9:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
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
        public static JVMConfig config = new JVMConfig();

        public static   void  Main(string[] args)
		{
				
            parseArgs(args);
            if (config == null || 
                config.mainClass == null ||
                config.mainClass.Length < 1) {
                return;
            }
            initArgs(config);

            initJVM();
            bootJVM();
		}

        private static   void  bootJVM()
        {

            Classpath c = new Classpath();
            c.init(config);

            ClassLoader loader = new ClassLoader(c);

            Class clz = loader.load(config.mainClass);
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


            if (config.verbose)
            {
                Console.WriteLine("打开详细输出模式");
                Console.WriteLine("启动类:" + config.mainClass);
                Console.WriteLine("用户JRE目录:" + config.Xjre);
                Console.WriteLine("CLASSPATH:" + config.cp);
            }
        }


        public static string safeGetArg(string[] args, int index)
        {
            if (index < 0 || index >= args.Length) return "";
            return args[index];
        }

        public static   void  parseArgs(string[] args) {
            if (args.Length < 1) return;
            for (int i = 0; i < args.Length; i+=1)
            {
                string key = safeGetArg(args, i);
                string val = safeGetArg(args, i + 1);
                if (key.Contains("-"))
                {
                    key = key.ToLower();

                    var count = setArg(key, val);

                    i += count;

                }
                else
                {
                    config.mainClass = key;
                }


            }
		}


        
        private static int setArg(string key, string v)
        {
            switch(key)
            {
                case "-cp":
                case "-classpath":
                    config.cp = v;
                    config.classpath = v;
                    return 1;
                case "-verbose":
                case "-v":
                    config.verbose = true;
                    return 0;
                case "-xjre":
                    config.Xjre = v;
                    return 1;
                case "-mainclass":
                    config.mainClass = v;
                    return 1;
            }
            return 0;
        }
    }
}