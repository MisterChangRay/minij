# MyJvm
此项目为阅读 <<自己动手写Java虚拟机>> 后的作品


这是学习java虚拟机后的练习。

根据《Java虚拟机规范》第8版编写;

## 演示
编译以下源码;
通过 javac 编译后即可执行 `myjvm Hello`即可观察效果:
```java
// 1
public class Hello {
  public static void main(String[] args) {
    System.out.println("Helloworld");
  }
}
```
