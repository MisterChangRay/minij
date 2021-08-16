package jvmgo.book.ch06;

import java.util.ArrayList;
import java.util.List;


public class MyObject  {

public static void main(String[] args) {
System.out.println(args[0]);
	foo(args);
}

private static void foo(String[] args) {
try {
bar(args);
} catch (NumberFormatException e) {
System.out.println(e.getMessage());
}
}
private static void bar(String[] args) {
System.out.println(args.length);	
if (args.length == 0) {
	throw new IndexOutOfBoundsException("no args!");
}
int x = Integer.parseInt(args[0]);
System.out.println(x);
}
}
