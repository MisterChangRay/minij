using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile.attributes;
using minij.classfile.constant;

/**
class 文件结构

jvm 定义结构
URL: https://docs.oracle.com/javase/specs/jvms/se7/html/jvms-4.html#jvms-4.1
ClassFile {
    u4             magic;
    u2             minor_version;
    u2             major_version;
    u2             constant_pool_count;
    cp_info        constant_pool[constant_pool_count-1];
    u2             access_flags;
    u2             this_class;
    u2             super_class;
    u2             interfaces_count;
    u2             interfaces[interfaces_count];
    u2             fields_count;
    field_info     fields[fields_count];
    u2             methods_count;
    method_info    methods[methods_count];
    u2             attributes_count;
    attribute_info attributes[attributes_count];
}
**/
namespace minij.classfile
{
    class ClassFile
    {
        private ClassReader reader;

        public UInt32 magic;
        public UInt16 minorVersion;
        public UInt16 majorVersion;
        public UInt16 constantPoolCount; // 常量池大小
        public List<Constant> cpInfo; // 常量池信息
        public AccessFlags accessFlags;
        public UInt16 thisClass;
        public UInt16 superClass;
        public UInt16 interfacesCount;
        public UInt16[] interfaces;

        public List<FieldAndMethodInfo> fields;
        public List<FieldAndMethodInfo> methods;
        public List<attributes.Attribute> attributes;


        public ClassFile(byte[] classfile) {
            ClassReader t = new ClassReader(classfile);
            this.reader = t;
        }

        public string getClassName(int index) {
            if (0 == index) return null;

            Constant c = this.cpInfo[index];
            CONSTANT_Class uf = (CONSTANT_Class)c;
            
            return getString(uf.nameIndex);
        }

        // 解析类文件
        public ClassFile parse()
        {
            this.magic = reader.readUInt32();
            this.minorVersion = reader.readUInt16();
            this.majorVersion = reader.readUInt16();
            this.parseConstantPool();
            this.accessFlags = new AccessFlags(reader.readUInt16());
            this.thisClass = reader.readUInt16();
            this.superClass = reader.readUInt16();

            this.interfacesCount = reader.readUInt16();
            this.interfaces = reader.readUInt16s(this.interfacesCount);

            this.fields = this.parseFields();
            this.methods = this.parseMethods();
            this.attributes = this.parseAttributes();

            return this;
        }


        private List<FieldAndMethodInfo> parseMethods()
        {
            UInt16 cont = reader.readUInt16();
            List<FieldAndMethodInfo> res = new List<FieldAndMethodInfo>();

            for (int i = 0; i < cont; i++)
            {
                FieldAndMethodInfo f = new FieldAndMethodInfo();
                f.parse(reader, this);
                res.Add(f);
            }

            return res;
        }

        private List<FieldAndMethodInfo> parseFields()
        {
            return parseMethods();
        }

        /**
        get utf8 val
            **/
        public String getString(int cpIndex) {
            Constant c = this.cpInfo[cpIndex];
            CONSTANT_Utf8_info uf = (CONSTANT_Utf8_info)c;
            return uf.str;
        }


        /**
        解析常量池
        **/
        public List<Constant> parseConstantPool()
        {
            UInt16 len = reader.readUInt16();
            this.constantPoolCount = len;

            List<Constant> c = new List<Constant>();
            c.Add(null);
            for (int i = 1; i < len; i++)
            {
                byte tag = reader.readUint8();
                var t = parseConstantPool(tag);
                c.Add(t);
                if (t is CONSTANT_Double_info || t is CONSTANT_Long_info) {
                    i++;
                    c.Add(null);
                }
            }

            this.cpInfo = c;
            return c;
        }

        private Constant parseConstantPool(byte tag)
        {
            Constant c = null;
            switch (tag)
            {
                case 7: //CONSTANT_Class
                    c = new CONSTANT_Class();
                    break;
                case 9: //CONSTANT_Fieldref
                    c = new CONSTANT_Fieldref_info();
                    
                    break;
                case 10: //CONSTANT_Methodref
                    c = new CONSTANT_Methodref_info();
               
                    break;
                case 11: //CONSTANT_InterfaceMethodref
                    c = new CONSTANT_InterfaceMethodref_info();
                    break;
                case 8: //CONSTANT_String
                    c = new CONSTANT_String_info();
                    break;
                case 3: //CONSTANT_Integer
                    c = new CONSTANT_Integer_info();
                    break;
                case 4: //CONSTANT_Float
                    c = new CONSTANT_Float_info();
                    break;
                case 5: //CONSTANT_Long
                   c = new CONSTANT_Long_info();
                    break;
                case 6: //CONSTANT_Double
                    c = new CONSTANT_Double_info();
                    break;
                case 12: //CONSTANT_NameAndType
                    c = new CONSTANT_NameAndType_info();
                    break;
                case 1: //CONSTANT_Utf8
                   c = new CONSTANT_Utf8_info();
                    break;
                case 15: //CONSTANT_MethodHandle
                    c = new CONSTANT_MethodHandle_info();
                    break;
                case 16: //CONSTANT_MethodType
                    c = new CONSTANT_MethodType_info();
                    break;
                case 18: //CONSTANT_InvokeDynamic
                    c = new CONSTANT_InvokeDynamic_info();
                    break;

            }
            if (c != null) {
                c.tag = tag;
                c.parse(reader, this);
            }
            return c;

        }




        /**
        解析异常表
        **/
        public  List<ExceptionTable> parseExceptionTable(ClassReader classReader, ClassFile cf)
        {
            int len = classReader.readUInt16();
            List<ExceptionTable> c = new List<ExceptionTable>();
            for (int i = 0; i < len; i++)
            {
                ExceptionTable e = new ExceptionTable();
                e.parse(classReader, cf);
                c.Add(e);
            }
            return c;
        }
    
        public  List<attributes.Attribute> parseAttributes()
        {
            List<attributes.Attribute> res = new List<attributes.Attribute>();

            UInt16 len = reader.readUInt16();
            for (int i = 0; i < len; i++)
            {
                res.Add(parseAttr());
            }
            return res;


        }
        /**
            解析属性表
            attribute_info {
                u2 attribute_name_index;
                u4 attribute_length;
                u1 info[attribute_length];
            }
          **/
        private attributes.Attribute parseAttr()
        {
            UInt16 attribute_name_index = reader.readUInt16();
            UInt32 attribute_length = reader.readUInt32();

            String attrName = this.getString(attribute_name_index);
            attributes.Attribute attr = null;
            switch (attrName)
            {
                case "ConstantValue":
                    attr = new AttrConstantValue();
                    break;
                case "Code":
                    attr = new AttrCode();
                    break;
                case "Exceptions":
                    attr = new AttrExceptions();
                    break;
                case "Synthetic":
                    attr = new AttrSynthetic();
                    break;
                case "SourceFile":
                    attr = new AttrSourceFile();
                    break;
                case "LineNumberTable":
                    attr = new AttrLineNumberTable();
                    break;
                case "LocalVariableTable":
                    attr = new AttrLocalVariableTable();
                    break;
                default:
                    //Console.WriteLine("unparse attr:" + attrName);
                    reader.readBytes(Convert.ToInt32(attribute_length), true);
                    break;
            }
            if (attr != null) {
                attr.parse(reader, this);
                attr.name = attrName;
                attr.attribute_name_index = attribute_name_index;
                attr.attribute_length = attribute_length;
            }
            return attr;

        }
    }
}

