using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
byte short char int long float double object
**/
namespace minij.rtda
{
    public class OperandStack
    {
        private Object[] stcks;
        private int index = 0;



        public Object getThis(int i) {
            return this.stcks[this.index - 1 - i];
        }

        public OperandStack(int i) {
            stcks = new Object[i];
        }

        public Object pop() {
            index -= 1;
            return (Object)stcks[index];
        }


        public   void  push(Object obj)
        {
            stcks[index]= obj;
            index += 1;
        }


        public   void  pushInt(int i)
        {
            stcks[index] = i;
            index += 1;
        }

        public int popInt()
        {
            index -= 1;
            return (int) stcks[index];
        }

        public   void  pushLong(long i)
        {
            stcks[index] = i;
            index += 2;
        }

        public long popLong()
        {
            index -= 2;
            return (long)stcks[index];
        }

        public   void  pushFloat(float i)
        {
            stcks[index] = i;
            index += 1;
        }
        public float popFloat()
        {
            index -= 1;
            return (float)stcks[index];
        }

        public   void  pushDouble(double i)
        {
            stcks[index] = i;
            index += 2;
        }
        public double popDouble()
        {
            index -= 2;
            return (double)stcks[index];
        }

        public   void  pushRef(JObject i)
        {
            stcks[index] = i;
            index += 1;
        }
        public JObject popRef()
        {
            index -= 1;
            return (JObject)stcks[index];
        }
    }
}
