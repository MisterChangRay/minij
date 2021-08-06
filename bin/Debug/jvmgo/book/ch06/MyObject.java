package jvmgo.book.ch06;
public class MyObject {

public final static int finalVar = 99;
public static int staticVar = 55;
public int instanceVar = 66;

public static void main(String[] args) {
	FuckI[] fucks = new  FuckI[2];


	FuckI f2 = new Fuck2();
	System.out.println( f2.get());
}

public static long getResult(int c) {
	long r = 0;
	for(int i=0; i<=c; i++) {
		r += i;
	}
	return r;
}
}


interface FuckI {
	int get();
}

class Fuck implements FuckI {
	public int name ;
	public int get() {
		return this.name;
	}

	public int get2() {
		return 555;
	}

	public Fuck() {
		this.name = 12 + 55;
	}
}


class Fuck2 extends Fuck {
	public int get() {
		return this.name;
	}
}