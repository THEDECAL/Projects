#include <iostream>
#include "employee.h"

void main(){
	const unsigned amPeoples = 3;
	employee *_array[amPeoples] = {
		new president("Nikita Zvegintsev","23.08.1990"),
		new manager("Galja Bobrova","17.12.1974"),
		new worker("Vova Kurachkin","19.01.1995")
	};

	for(auto i : _array) i->print();

	system("pause");
}
