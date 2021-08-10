package jvmgo.book.ch06;
public class MyObject {

public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;

public static void main(String[] args) {
	System.out.println(int.class.getName());
	System.out.println("asdf".getClass().getName());
}
}
