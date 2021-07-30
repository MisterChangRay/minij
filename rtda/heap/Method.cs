using minij.classfile;
using minij.rtda.heap.constantpool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    class Method : ConstantPool
    {
        public AccessFlags accessFlags;
        public string name;
        public string descriptor;
        public NameAndType nameAndType;
        public List<minij.classfile.attributes.Attribute> attrs;
        public Class clazz;
        public ArgAndReturn argsAndReturn;




        /**
        * 解析参数类型和所占局部变量表数量
        *
        **/
        public void parseArgsAndReturn() {
            this.argsAndReturn = new ArgAndReturn();
            this.argsAndReturn.args = new List<string>();

            // [数组标志, 类标志]
            var mutilFlags = new int[]{ 0, 0};
            string tmp = "";
            for (int i = 1; i < this.descriptor.Length; i++)
            {
                var chars = this.descriptor[i];
                if (chars == '[')
                {
                    // 数组开始
                    mutilFlags[0] = 1;
                    tmp += chars;

                } else 
                if (chars == 'L')
                {
                    // 类名开始
                    mutilFlags[1] = 1;
                    tmp += chars;

                }
                else if (chars == ';')
                {
                    // 类名结束
                    mutilFlags[0] = 0;
                    mutilFlags[1] = 0;

                    tmp += chars;

                    this.argsAndReturn.args.Add(tmp);
                    tmp = "";
                }
                else if (chars == ')')
                {
                    // 方法参数解析结束
                    this.argsAndReturn.res = this.descriptor.Substring(i + 1);
                    break;
                }
                else {
                    // 其他解析
                    if (mutilFlags[0] == 1 && mutilFlags[1] == 0) {
                        tmp += chars;
                        this.argsAndReturn.args.Add(tmp);
                        tmp = "";

                    } else if (mutilFlags[1] == 1) {
                        tmp += chars;
                    } else {
                        this.argsAndReturn.args.Add(chars + "");
                    }
                }

            }


            // 计算槽位数
            int soltCount = 0;
            foreach (var c in this.argsAndReturn.args)
            {
                soltCount ++;
                if (c == "D" || c == "J")
                {
                    // long or double
                    soltCount ++;
                }
            }
            if (!this.accessFlags.ACC_STATIC()) {
                soltCount ++;
            }

            this.argsAndReturn.argCount = soltCount;
        }


        public minij.classfile.attributes.Attribute getAttribute(string name) {
            foreach(var attr in attrs)
            {
                if(attr.name == name)
                {
                    return attr;
                }
            }
            return null;

        }

    }

    class ArgAndReturn {
        public int argCount;
        public List<string> args;
        public string res;
    }
}
