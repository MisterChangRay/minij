using minij.rtda;
using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
Code_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
    u2 max_stack;
    u2 max_locals;
    u4 code_length;
    u1 code[code_length];
    u2 exception_table_length;
    {   u2 start_pc;
        u2 end_pc;
        u2 handler_pc;
        u2 catch_type;
    } exception_table[exception_table_length];
    u2 attributes_count;
    attribute_info attributes[attributes_count];
}

**/
namespace minij.classfile.attributes
{
    class AttrCode : Attribute
    {

        public UInt16 max_stack;
        public UInt16 max_locals;
        public UInt32 code_length;
        public byte[] code;
        public UInt16 exception_table_length;
        public List<ExceptionTable> exception_table;
        public UInt16 attributes_count;
        public List<Attribute> attributes;
       

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.max_stack = classReader.readUInt16();
            this.max_locals = classReader.readUInt16();
            this.code_length = classReader.readUInt32();
            this.code = classReader.readBytes(Convert.ToInt32(this.code_length), true);
            
            this.exception_table = cf.parseExceptionTable(classReader, cf);
            this.exception_table_length = Convert.ToUInt16(this.exception_table.Capacity);

            this.attributes = cf.parseAttributes();
            this.attributes_count = Convert.ToUInt16(this.attributes.Count);

            return this;


        }


        public string getLineNum(int pc)
        {
            var lineNumberTable = (AttrLineNumberTable) Util.getAttr(this.attributes, "LineNumberTable");
            if (null == lineNumberTable) return "-1";

            string res = null;
            lineNumberTable.line_number_table.Reverse();
            lineNumberTable.line_number_table.ForEach(t =>
            {
                if (t.start_pc < pc)
                {
                    res = t.line_number + "";
                }
            });
            return res;

        }
    }
}
