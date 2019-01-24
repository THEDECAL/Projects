#include <iostream>
#include "matrix.h"

int main() {
	std::cout<<"Matrix first:\n";
	matrix<unsigned> first(3,3);
	first.show();

	std::cout<<"Matrix second:\n";
	matrix<unsigned> second(3,3);
	second.show();

	std::cout<<"Sum of two matrix second and first:\n";
	matrix<unsigned> third=first+second;
	third.show();
	
	std::cout<<"Multiplication of two matrix second and first:\n";
	third=first*second;
	third.show();

	std::system("pause");
	return 0;
}
