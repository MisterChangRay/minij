using minij.instructions.control;
using minij.instructions.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.instructions
{
    class Factory
    {
        public static Instruction build(byte code) {
            switch (code) {
                case 0x10:
                    return new BIPUSH();
                case 0x11:
                    return new SIPUSH();

                case 0x12:
                    return new LDC();
                case 0x13:
                    return new LDC_W();
                case 0x14:
                    return new LDC2_W();

                case 0xb8:
                    return new Invokestatic();
                case 0xb6:
                    return new Invokevirtual();

                case 0xb2:
                    return new GET_STATIC();
                case 0xb3:
                    return new PUT_STATIC();


                case 0x60:
                    return new IADD();
                case 0x61:
                    return new LADD();
                case 0x62:
                    return new FADD();
                case 0x63:
                    return new DADD();

                case 0x6c:
                    return new IDIV();
                case 0x6d:
                    return new LDIV();
                case 0x6e:
                    return new FDIV();
                case 0x6f:
                    return new DDIV();

                case 0x68:
                    return new IMUL();
                case 0x69:
                    return new LMUL();
                case 0x6A:
                    return new FMUL();
                case 0x6B:
                    return new DMUL();

                case 0x74:
                    return new INEG();
                case 0x75:
                    return new LNEG();
                case 0x76:
                    return new FNEG();
                case 0x77:
                    return new DNEG();

                case 0x70:
                    return new IREM();
                case 0x71:
                    return new LREM();
                case 0x72:
                    return new FREM();
                case 0x73:
                    return new DREM();

                case 0x64:
                    return new ISUB();
                case 0x65:
                    return new LSUB();
                case 0x66:
                    return new FSUB();
                case 0x67:
                    return new DSUB();

                case 0x78:
                    return new ISHL();
                case 0x79:
                    return new LSHL();

                case 0x7A:
                    return new ISHR();
                case 0x7B:
                    return new LSHR();

                case 0x7C:
                    return new IUSHR();
                case 0x7D:
                    return new LUSHR();

                case 0x7E:
                    return new IAND();
                case 0x7F:
                    return new LAND();

                case 0x80:
                    return new IOR();
                case 0x81:
                    return new LOR();

                case 0x82:
                    return new IXOR();
                case 0x83:
                    return new LXOR();


                case 0x15:
                    return new ILOAD();
                case 0x1A:
                    return new ILOAD_0();
                case 0x1B:
                    return new ILOAD_1();
                case 0x1C:
                    return new ILOAD_2();
                case 0x1D:
                    return new ILOAD_3();

                case 0x16:
                    return new LLOAD();
                case 0x1E:
                    return new LLOAD_0();
                case 0x1F:
                    return new LLOAD_1();
                case 0x20:
                    return new LLOAD_2();
                case 0x21:
                    return new LLOAD_3();

                case 0x17:
                    return new FLOAD();
                case 0x22:
                    return new FLOAD_0();
                case 0x23:
                    return new FLOAD_1();
                case 0x24:
                    return new FLOAD_2();
                case 0x25:
                    return new FLOAD_3();

                case 0x18:
                    return new DLOAD();
                case 0x26:
                    return new DLOAD_0();
                case 0x27:
                    return new DLOAD_1();
                case 0x28:
                    return new DLOAD_2();
                case 0x29:
                    return new DLOAD_3();

                case 0x19:
                    return new ALOAD();
                case 0x2A:
                    return new ALOAD_0();
                case 0x2B:
                    return new ALOAD_1();
                case 0x2C:
                    return new ALOAD_2();
                case 0x2D:
                    return new ALOAD_3();


                case 0x01:
                    return new ACONST_NULL();

                case 0x02:
                    return new ICONST_M1();
                case 0x03:
                    return new ICONST_0();
                case 0x04:
                    return new ICONST_1();
                case 0x05:
                    return new ICONST_2();
                case 0x06:
                    return new ICONST_3();
                case 0x07:
                    return new ICONST_4();
                case 0x08:
                    return new ICONST_5();

                case 0x09:
                    return new LCONST_0();
                case 0x0a:
                    return new LCONST_1();

                case 0x0b:
                    return new FCONST_0();
                case 0x0c:
                    return new FCONST_1();
                case 0x0d:
                    return new FCONST_2();

                case 0x0e:
                    return new DCONST_0();
                case 0x0f:
                    return new DCONST_1();


                case 0x3a:
                    return new ASTORE();
                case 0x4b:
                    return new ASTORE_0();
                case 0x4c:
                    return new ASTORE_1();
                case 0x4d:
                    return new ASTORE_2();
                case 0x4e:
                    return new ASTORE_3();

                case 0x36:
                    return new ISTORE();
                case 0x3b:
                    return new ISTORE_0();
                case 0x3c:
                    return new ISTORE_1();
                case 0x3d:
                    return new ISTORE_2();
                case 0x3e:
                    return new ISTORE_3();


                case 0x37:
                    return new LSTORE();
                case 0x3f:
                    return new LSTORE_0();
                case 0x40:
                    return new LSTORE_1();
                case 0x41:
                    return new LSTORE_2();
                case 0x42:
                    return new LSTORE_3();

                case 0x38:
                    return new FSTORE();
                case 0x43:
                    return new FSTORE_0();
                case 0x44:
                    return new FSTORE_1();
                case 0x45:
                    return new FSTORE_2();
                case 0x46:
                    return new FSTORE_3();

                case 0x39:
                    return new DSTORE();
                case 0x47:
                    return new DSTORE_0();
                case 0x48:
                    return new DSTORE_1();
                case 0x49:
                    return new DSTORE_2();
                case 0x4A:
                    return new DSTORE_3();

                case 0x91:
                    return new I2B();
                case 0x92:
                    return new I2C();
                case 0x93:
                    return new I2S();

                case 0x84:
                    return new IINC();
                case 0x85:
                    return new I2L();
                case 0x86:
                    return new I2F();
                case 0x87:
                    return new I2D();


                case 0x88:
                    return new L2I();
                case 0x89:
                    return new L2F();
                case 0x8A:
                    return new L2D();

                case 0x8B:
                    return new F2I();
                case 0x8C:
                    return new F2L();
                case 0x8D:
                    return new F2D();

                case 0x8E:
                    return new D2I();
                case 0x8F:
                    return new D2L();
                case 0x90:
                    return new D2F();


                case 0x94:
                    return new LCMP();

                case 0x95:
                    return new FCMPL();
                case 0x96:
                    return new FCMPG();

                case 0x97:
                    return new DCMPL();
                case 0x98:
                    return new DCMPG();

                case 0x59:
                    return new DUP();
                case 0x5a:
                    return new DUP_X1();
                case 0x5b:
                    return new DUP_X2();
                case 0x5c:
                    return new DUP2();
                case 0x5d:
                    return new DUP2_X1();
                case 0x5e:
                    return new DUP2_X2();

                case 0x99:
                    return new IFEQ();
                case 0x9A:
                    return new IFNE();
                case 0x9B:
                    return new IFLT();
                case 0x9C:
                    return new IFGE();
                case 0x9D:
                    return new IFGT();
                case 0x9E:
                    return new IFLE();

                case 0xC6:
                    return new IFNULL();
                case 0xC7:
                    return new IFNONNULL();

                case 0x9F:
                    return new IF_ICMPEQ();
                case 0xA0:
                    return new IF_ICMPNE();
                case 0xA1:
                    return new IF_ICMPLT();
                case 0xA2:
                    return new IF_ICMPGE();
                case 0xA3:
                    return new IF_ICMPGT();
                case 0xA4:
                    return new IF_ICMPLE();

                case 0xA5:
                    return new IF_ACMPEQ();
                case 0xA6:
                    return new IF_ACMPNEQ();

                case 0xA7:
                    return new GOTO();
                case 0xC8:
                    return new GOTO_W();

                case 0xB0:
                    return new ARETURN();
                case 0xB1:
                    return new RETURN();
                case 0xAC:
                    return new IRETURN();
                case 0xAD:
                    return new LRETURN();
                case 0xAE:
                    return new FRETURN();
                case 0xAF:
                    return new DRETURN();
                

                default:
                    Console.WriteLine("不能解析的指令" + code);
                    break;

            }
            return null;
        }
    }
}
