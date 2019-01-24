#include <iostream>
#include <ctime>
#include "printer.h"

int main(){
	srand(time(NULL));
	printer obj;
	std::cout<<"Clients in the print queue:\n";
	obj.get();
	std::cout<<"\n\n";

	obj.print();
	obj.print();
	obj.print();
	obj.print();
	std::cout<<"Print clients:\n";
	obj.get_stat();
	std::cout<<"\n\n";

	std::cout<<"Clients after printing:\n";
	obj.get();
	std::cout<<"\n\n";

	std::system("pause");
	return 0;
}
