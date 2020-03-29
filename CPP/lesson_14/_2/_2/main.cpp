#include <iostream>
#include <string>
#include <ctime>
#include "stack.h"

void main(){
	try{
		srand(time(NULL));

		const unsigned size = 10;
		stack<char> _stack(size);

		std::cout << "Initialization stack size "<< size << ".\n\n";
		for(size_t i = 0; i < size; i++) _stack.push(97 + (rand() % 26));

		std::cout << "Stack content: ";
		for(auto i : _stack) std::cout << i;
		std::cout << std::endl << std::endl;

		//std::cout << "Erase element 2: ";
		//_stack.erase(_stack.begin()+1);
		//for(auto i : _stack) std::cout << i;
		//std::cout << std::endl << std::endl;

		std::cout << "Attempt to add "<< size+1 <<" element:\n";
		_stack.push(97 + (rand() % 26));
		std::cout << std::endl << std::endl;
	}
	catch(const char* message){ std::cout << "\tERROR. " << message; }
	catch(...){ std::cout << "\tUnexpected Error\n"; }

	system("pause");
}
