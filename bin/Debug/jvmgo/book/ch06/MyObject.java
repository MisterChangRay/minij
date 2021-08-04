package jvmgo.book.ch06;
public class MyObject {

public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;

public static void main(String[] args) {
	long r = getResult(100) + staticVar + finalVar;
	Fuck f = new Fuck();
	r += f.get();
	System.out.println(r);
}

public static long getResult(int c) {
	long r = 0;
	for(int i=0; i<=c; i++) {
		r += i;
	}
	return r;
}
}


class Fuck {
	private int i ;
	public int get() {
		return this.i;
	}

	public Fuck() {
		this.i = 99;
	}
}
