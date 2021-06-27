# MyJvm
此项目为阅读 <<自己动手写Java虚拟机>> 后的作品


这是学习java虚拟机后的练习。

根据《Java虚拟机规范》第8版编写;
参考文档:
https://docs.oracle.com/javase/specs/jvms/se7/html/jvms-4.html#jvms-4.1

## 演示
下载发布版本
通过 javac 编译后即可执行 `minij.exe Hello`即可观察效果:
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
        Integer i = 12;
        System.out.println(i);
        String s1 = "test12";
        System.out.println(s1); // test12
        String s2 = "test" + 1;
        System.out.println(s1.equals(s2)); // false
        s2.intern();
        System.out.println(s1.equals(s2)); // true
  }
}
```
