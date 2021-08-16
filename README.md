# MyJvm
此项目为阅读 <<自己动手写Java虚拟机>> 后的作品


这是学习java虚拟机后的练习。

根据《Java虚拟机规范》第8版编写;
参考文档:
https://docs.oracle.com/javase/specs/jvms/se7/html/jvms-4.html#jvms-4.1

## 演示
下载发布版本
通过 javac 编译后即可执行 `minij.exe Hello`即可观察效果:
加参数`minij.exe Hello -v` 可以观察到详细指令执行流程.
```java
// 1.
public class Hello {
  public static void main(String[] args) {
    System.out.println("Helloworld");
  }
}

// 2.
public class Hello {
  public static void main(String[] args) {
              
        int i = 1;
        System.out.println(i);
        String s1 = "test1";
        System.out.println(s1); // test1
        String s2 = "test";
        s2 = s2 + i;
        System.out.println(s2); // test1
        System.out.println(s1 == s2); // false
        System.out.println(s1.equals(s2)); // true
        s2.intern();
        System.out.println(s1 == s2); // false
        s2 = s2.intern();
        System.out.println(s1 == s2); // true

        
  }
}
```
