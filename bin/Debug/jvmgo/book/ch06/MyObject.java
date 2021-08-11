package jvmgo.book.ch06;
public class MyObject {

public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;

public static void main(String[] args) {

	String s1 = "abc1";
String s2 = "abc1";
System.out.println(s1 == s2); // true
int x = 1;
String s3 = "abc" + x;
System.out.println(s1 == s3); // false
s3 = s3.intern();
System.out.println(s1 == s3); // true

}
}
