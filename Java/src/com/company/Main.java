package com.company;

import java.io.IOException;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws IOException {
        var sc = new Scanner(System.in);

	    while(true){
            System.out.print("\nВведите набор символов: ");
	        var text = sc.nextLine();

	        System.out.printf("Вы ввели: %s\n", text);
        }
    }
}
