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
    class LocalVars
    {
        private object[] localVars;


        public LocalVars(int i) {
            localVars = new object[i];
        }

        public   void  setInt(int index, int val)
        {
            localVars[index] = val;
        }

        public int getInt(int index)
        {
            return (int)localVars[index];
        }

        public   void  setLong(int index, long i)
        {
            localVars[index] = i;
        }

        public long getLong(int index)
        {
            return  (long)localVars[index];
        }

        public   void  setFloat(int index, float i)
        {
            localVars[index] = i;
        }
        public float getFloat(int index)
        {
            return (float)localVars[index];
        }

        public   void  setDouble(int index, double i)
        {
            localVars[index] = i;
        }
        public double getDouble(int index)
        {
            return (double)localVars[index];
        }

        public   void  setRef(int index, JObject i)
        {
            localVars[index] = i;
        }
        public JObject getRef(int index)
        {
            return (JObject)localVars[index];
        }
    }
}
