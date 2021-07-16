﻿using minij.classfile;
using minij.classfile.constant;
using minij.rtda.heap.constantpool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    class Class : ConstantPool
    {
        public bool inited;
        public JObject clzObj;

        public UInt32 magic;
        public UInt16 minorVersion;
        public UInt16 majorVersion;
        public string name;
        public List<ConstantPool> cpInfo; // 常量池信息
        public AccessFlags accessFlags;
        public string superClazzName;
        public string[] interfacesNames;

        public Class thisClazz;
        public Class superClazz;
        public Class[] interfaces;
        public List<Field> fields;
        public List<Method> methods;
        public List<classfile.attributes.Attribute> attributes;

        public object[] staticVars;  // 静态变量

        public ClassLoader loader;


        public Method getMethod(string name, string descriptor)
        {
            foreach (var item in this.methods)
            {
                if (item.name == name && item.descriptor == descriptor)
                {
                    return item;
                }
            }
            return null;
        }

        public Method getMethod(string name, string descriptor, bool isStatic)
        {
            foreach(var item in this.methods)
            {
                if(isStatic && !item.accessFlags.ACC_STATIC())
                {
                    continue;
                }

                if (item.name == name && item.descriptor == descriptor
                    && item.accessFlags.ACC_STATIC() == isStatic) {
                    return item;
                }
            }
            return null;
        }

        public JObject newObject()
        {
            return JObject.newJObject(this);
        }

        internal   void  initFieldsSolotId()
        {
            int staticId = 0, instantId = 0;
            foreach(var field in this.fields)
            {
                if (field.accessFlags.ACC_STATIC())
                {
                    field.slotId = staticId;
                    staticId += 1;
                }
                else {
                    field.slotId = instantId;
                    instantId += 1;
                }
            }
        }

        public   void  init(ClassFile clzFile)
        {
            this.magic = clzFile.magic;
            this.minorVersion = clzFile.minorVersion;
            this.majorVersion = clzFile.majorVersion;

            this.name = clzFile.getClassName(clzFile.thisClass);
            this.accessFlags =  clzFile.accessFlags;
            this.thisClazz = this;
      
            // 初始化常量池
            this.copyConstantPool(clzFile);

            // 初始化字段
            this.copyFileds(clzFile);

            this.copyMethod(clzFile);

            this.superClazzName = clzFile.getClassName(clzFile.superClass);
            // 初始化接口
            this.interfacesNames = new string[clzFile.interfaces.Length];
            for (int i = 0; i < clzFile.interfaces.Length; i++)
            {
                this.interfacesNames[i] = clzFile.getClassName(clzFile.interfaces[i]);
            }


        }

        private   void  copyMethod(ClassFile clzFile)
        {
            this.methods = new List<Method>();
            foreach (var cm in clzFile.methods)
            {
                Method m = new Method();
                m.accessFlags = cm.accessFlags;
                m.name = clzFile.getString(cm.name_index);
                m.descriptor = clzFile.getString(cm.descriptor_index);

                m.attrs = cm.attrs;
                m.clazz = this;
                this.methods.Add(m);
            }
        }

        private   void  copyFileds(ClassFile clzFile)
        {
            this.fields = new List<Field>();
            foreach(var cf in clzFile.fields)
            {
                Field f = new Field();
                f.accessFlags = cf.accessFlags;
          
                f.name_index = cf.name_index;
                f.name = clzFile.getString(cf.name_index);

                f.descriptor = clzFile.getString(cf.descriptor_index);
                f.descriptor_index = cf.descriptor_index;

                f.attrs = cf.attrs;

                this.fields.Add(f);
            }


        }


        // 复制 常量池
        private   void  copyConstantPool(ClassFile clzFile)
        {
            this.cpInfo = new List<ConstantPool>();
            this.cpInfo.Add(null);
            string clzName = null;
            for (int i = 1; i < clzFile.cpInfo.Count; i++)
            {
                var cpTmp = clzFile.cpInfo[i];
                if (cpTmp is CONSTANT_Class)
                {
                    this.cpInfo.Add(parseClassIndex(i, clzFile));
                }
                if (cpTmp is CONSTANT_Fieldref_info)
                {
                    this.cpInfo.Add(parseFiledRefInfo(i, clzFile));
                }

                if (cpTmp is CONSTANT_Methodref_info)
                {
                    this.cpInfo.Add(parseMethodRef(i, clzFile));
                }
                if (cpTmp is CONSTANT_InterfaceMethodref_info)
                {
                    this.cpInfo.Add(parseInterfaceMethodRef(i, clzFile));
                }
                if (cpTmp is CONSTANT_MethodHandle_info)
                {
                    this.cpInfo.Add(parseMethodHandle(i, clzFile));
                }

                if (cpTmp is CONSTANT_Utf8_info)
                {
                    var u1 = (CONSTANT_Utf8_info)cpTmp;
                    Utf8 u2 = new Utf8();
                    u2.str = u1.str;

                    this.cpInfo.Add(u2);
                }
                if (cpTmp is CONSTANT_String_info)
                {
                    var u1 = (CONSTANT_String_info)cpTmp;
                    constantpool.String u2 = new constantpool.String();
                    u2.str = clzFile.getString(u1.string_index);

                    this.cpInfo.Add(u2);
                }
                if (cpTmp is CONSTANT_Integer_info)
                {
                    var u1 = (CONSTANT_Integer_info)cpTmp;
                    constantpool.Integer u2 = new constantpool.Integer();
                    u2.val = u1.val;

                    this.cpInfo.Add(u2);
                }

                if (cpTmp is CONSTANT_Long_info)
                {
                    var u1 = (CONSTANT_Long_info)cpTmp;
                    constantpool.Long u2 = new constantpool.Long();
                    u2.val = u1.val;
                    

                   this.cpInfo.Add(u2);
                   this.cpInfo.Add(null);
                    i++;
                }
                if (cpTmp is CONSTANT_Double_info)
                {
                    var u1 = (CONSTANT_Double_info)cpTmp;
                    constantpool.Double u2 = new constantpool.Double();
                    u2.val = u1.val;

                    this.cpInfo.Add(u2);
                    this.cpInfo.Add(null);
                    i++;
                }
                if (cpTmp is CONSTANT_Float_info)
                {
                    var u1 = (CONSTANT_Float_info)cpTmp;
                    constantpool.Float u2 = new constantpool.Float();
                    u2.val = u1.val;

                    this.cpInfo.Add(u2);
                }
               


            }
         


        }

        private ConstantPool parseMethodHandle(int i, ClassFile clzFile)
        {
            var tmp = (CONSTANT_MethodHandle_info)clzFile.cpInfo[i];
            MethodHandle methodHandle = new MethodHandle();
            
            throw new NotImplementedException();
        }

        private ConstantPool parseInterfaceMethodRef(int i, ClassFile clzFile)
        {
            var tmp = (CONSTANT_InterfaceMethodref_info)clzFile.cpInfo[i];

            InterfaceMethodref method = new InterfaceMethodref();
            method.clazz = parseClassIndex(tmp.classIndex, clzFile);
            method.nameAndType = parseNameAndTypeIndex(tmp.name_and_type_index, clzFile);
            method.name = method.nameAndType.name;
            method.descriptor = method.nameAndType.descriptor;

            return method;
        }

        private ConstantPool parseMethodRef(int i, ClassFile clzFile)
        {
            var tmp = (CONSTANT_Methodref_info) clzFile.cpInfo[i];

            Method method = new Method();
            method.clazz = parseClassIndex(tmp.classIndex, clzFile);
            method.nameAndType = parseNameAndTypeIndex(tmp.name_and_type_index, clzFile);
            method.name = method.nameAndType.name;
            method.descriptor = method.nameAndType.descriptor;

            return method;
        }

        private ConstantPool parseFiledRefInfo(int i, ClassFile clzFile)
        {
            var tmp = (CONSTANT_Fieldref_info)clzFile.cpInfo[i];

            Fieldref f = new Fieldref();
            f.clazz = parseClassIndex(tmp.classIndex, clzFile);
            f.nameAndType = parseNameAndTypeIndex(tmp.name_and_type_index, clzFile);
            f.name = f.nameAndType.name;
            f.descriptor = f.nameAndType.descriptor;

            return f;
        }


        private NameAndType parseNameAndTypeIndex(ushort name_and_type_index, ClassFile clzFile)
        {
            CONSTANT_NameAndType_info c = (CONSTANT_NameAndType_info) clzFile.cpInfo[name_and_type_index];

            NameAndType n = new NameAndType();
            n.name = clzFile.getString(c.nameIndex);
            n.descriptor = clzFile.getString(c.descriptorIndex);
            return n;
        }

        private Class parseClassIndex(int classIndex, ClassFile clzFile)
        {
            var tmp = (CONSTANT_Class)clzFile.cpInfo[classIndex];
            string clzName = clzFile.getString(tmp.nameIndex);

            return this;
        }

        public   void  initFinalVars()
        {
        }

        public override void  reslove()
        {
            if (this.inited) return ;
            this.inited = true;

            this.superClazz = this.loader.load(this.superClazzName);

            // 初始化接口
            this.interfaces = new Class[this.interfacesNames.Length];
            for (int i = 0; i < this.interfaces.Length; i++)
            {
                this.interfaces[i] = this.loader.load(this.interfacesNames[i]);
            }
            
        }
    }
}