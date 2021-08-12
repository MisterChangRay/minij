package jvmgo.book.ch06;

import java.util.ArrayList;
import java.util.List;


public class MyObject  {

public static void main(String[] args) {
	for(int i=0; i<args.length; i++) {
	System.out.println(args[i]);	
	}
	
}

private static void foo(String[] args) {
try {
bar(args);
} catch (NumberFormatException e) {
System.out.println(e.getMessage());
}
}
private static void bar(String[] args) {
if (args.length == 0) {
throw new IndexOutOfBoundsException("no args!");
}
int x = Integer.parseInt(args[0]);
System.out.println(x);
}
}
