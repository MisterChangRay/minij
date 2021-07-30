package jvmgo.book.ch06;
public class MyObject {
public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;
public static void main(String[] args) {
	System.out.println(getResult());
}

public static int getResult() {
	int r = 0;
	for(int i=0; i<=100; i++) {
		r += i;
	}
	return r;
}


public static int getStatic(int a, long[] b) {
	return staticVar;
}

public static int getStatic() {
	return staticVar;
}
}
