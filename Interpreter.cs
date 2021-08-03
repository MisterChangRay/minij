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
        public   void  start(Method  method) {
            Thread thread = new Thread();
            Frame minFrame = thread.newFrame(method);
            thread.pushFrame(minFrame);

            while (true) {
                Frame frame = thread.topFrame();
                CodeReader reader = frame.reader;
                reader.reset(frame.nextPc);
                frame.thread.pc = frame.nextPc;

                byte code = frame.reader.read();
                Instruction instruction = Factory.build(code);
                if (JVMConfig.config.verbose) {
                    Console.WriteLine("PC: {0}, execute: {1}, method: {2}.{3}", frame.nextPc, instruction, frame.method.clazz.name, frame.method.name);
                }
                instruction.feachOperationCode(frame.reader);
                frame.nextPc = reader.pc();

                instruction.execute(frame);

                if (thread.isEmpty()) {
                    break;
                }
               
            }
        }
    }
}
