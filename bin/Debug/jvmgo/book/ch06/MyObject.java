package jvmgo.book.ch06;
public class MyObject {
public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;
public static void main(String[] args) {
	long r = getResult(100) +staticVar;
	System.out.println(r);
}

public static long getResult(int c) {
	long r = 0;
	for(int i=0; i<=c; i++) {
		r += i;
	}
	return r;
}

public static long getResult2(int c, int c2) {
	long r = c + c2;
	return r;
}



public static int getStatic(int a, long[] b) {
	return staticVar;
}

public static int getStatic() {
	return staticVar;
}
}
