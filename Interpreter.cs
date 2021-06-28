using minij.classfile;
using minij.instructions;
using minij.rtda;
using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij
{
    class Interpreter
    {
        public void start(Method  method) {
            Thread thread = new Thread();
            Frame minFrame = thread.newFrame(method);
            thread.pushFrame(minFrame);

            while (true) {
                Frame frame = thread.topFrame();
                CodeReader reader = frame.reader;
                reader.reset(frame.nextPc);

                byte code = frame.reader.read();
                Instruction instruction = Factory.build(code);
                instruction.feachOperationCode(frame.reader);
                instruction.execute(frame);

                frame.nextPc = reader.pc();

                if (thread.isEmpty()) {
                    break;
                }
            }

        }
    }
}
