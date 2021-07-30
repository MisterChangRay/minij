package jvmgo.book.ch06;
public class MyObject {
public static int staticVar = 55;
public int instanceVar = 66;
public static void main(String[] args) {
	int l = 0;
	l = getStatic() + new MyObject().instanceVar;
}

public static int getStatic(int a, long[] b) {
	return staticVar;
}

public static int getStatic() {
	return staticVar;
}
}
