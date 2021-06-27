using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**

方法和字段公共字段区
**/
namespace minij.classfile
{
    class BaseInfo
    {
        public AccessFlags accessFlags;
        public UInt16 name_index;
        public UInt16 descriptor_index;
        public UInt16 attributes_count;
    }
}
