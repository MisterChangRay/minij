package jvmgo.book.ch06;
public class MyObject {
public static int staticVar;
public int instanceVar;
public static void main(String[] args) {
	int l = 0;
	for(int i=0;i<100;i++) {
		l += i;
	}
	System.out.println(l + "");
}
}
