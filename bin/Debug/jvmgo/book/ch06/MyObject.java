package jvmgo.book.ch06;
public class MyObject {

public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;

public static void main(String[] args) {

	System.out.println(Boolean.class.getName()); // boolean
	System.out.println(boolean.class.getName()); // boolean
	System.out.println(void.class.getName()); // void

	System.out.println(byte.class.getName()); // byte
	System.out.println(char.class.getName()); // char
	System.out.println(short.class.getName()); // short
	System.out.println(int.class.getName()); // int
	System.out.println(long.class.getName()); // long
	System.out.println(float.class.getName()); // float
	System.out.println(double.class.getName()); // double
	System.out.println(Object.class.getName()); // java.lang.Object
	System.out.println(int[].class.getName()); // [I
	System.out.println(int[][].class.getName()); // [[I
	System.out.println(Object[].class.getName()); // [Ljava.lang.Object;
	System.out.println(Object[][].class.getName()); // [[Ljava.lang.Object;
	System.out.println(Runnable.class.getName()); // java.lang.Runnable
	System.out.println("abc".getClass().getName()); // java.lang.String
	System.out.println(new double[0].getClass().getName()); // [D
	System.out.println(new String[0].getClass().getName()); 
	int [][] b = new int[3][3];
	System.out.println(b.getClass().getName()); 
}
}
