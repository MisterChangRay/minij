package jvmgo.book.ch06;
public class MyObject {

public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;

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
        System.out.println(s1 == s2); // true

        MyObject a3 = new MyObject();
        System.out.println(a3.toString()); // true

}
}
