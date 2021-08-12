using minij.classfile;
using minij.classfile.attributes;
using minij.rtda.heap.constantpool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    public  class Method : ConstantPool
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

        public string getLineNum(int pc)
        {
            var lineNumberTable = (AttrLineNumberTable)this.getAttribute("LineNumberTable");
            if (null == lineNumberTable) return "-1";

            string res = null;
            lineNumberTable.line_number_table.Reverse();
            lineNumberTable.line_number_table.ForEach(t =>
            {
                if(null == res && t.start_pc < pc)
                {
                    res = t.line_number + "";
                }
            });
            return res;

        }

 

        public minij.classfile.attributes.Attribute getAttribute(string name) {
            foreach(var attr in attrs)
            {
                if (attr == null) continue;
                if(attr.name == name)
                {
                    return attr;
                }
            }
            return null;

        }

  

        public void injectNativeMethodCodeAttr()
        {
            if(this.attrs == null)
            {
                this.attrs = new List<classfile.attributes.Attribute>();
            }

            AttrCode ac = new AttrCode();
            ac.max_locals = 6;
            ac.max_stack = 6;
            ac.name = "Code";

            switch (this.argsAndReturn.res[0]) {
                case 'V':
                    ac.code = new byte[] { 0xfe, 0xb1}; // return
                    break;
                case 'D':
                    ac.code = new byte[] { 0xfe, 0xaf}; // dreturn
                    break;
                case 'F':
                    ac.code = new byte[] { 0xfe, 0xae}; // freturn
                    break;
                case 'J':
                    ac.code = new byte[] { 0xfe, 0xad}; // lreturn
                    break;
                case '[':
                case 'L':
                    ac.code = new byte[] { 0xfe, 0xb0}; // areturn
                    break;
                default:
                    ac.code = new byte[] { 0xfe, 0xac}; // ireturn
                    break;
            }

            this.attrs.Add(ac);
        }
    }

    public class ArgAndReturn {
        public int argCount;
        public List<string> args;
        public string res;
    }
}
