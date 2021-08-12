package jvmgo.book.ch06;

import java.util.ArrayList;
import java.util.List;


public class MyObject implements Cloneable {

public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;

private double pi = 3.14;
@Override
public MyObject clone() {
try {
return (MyObject) super.clone();
} catch (CloneNotSupportedException e) {
throw new RuntimeException(e);
}
}
public static void main(String[] args) {
MyObject obj1 = new MyObject();
MyObject obj2 = obj1.clone();
obj1.pi = 3.1415926;
System.out.println(obj1.pi);
System.out.println(obj2.pi);

System.out.println(obj2 == obj2);
}
}
