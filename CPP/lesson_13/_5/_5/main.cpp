#include <iostream>
#include "equation.h"

void main(){
	const unsigned amEquation = 2;
	equation* _equation[amEquation] = {
		new linear_eq(-3,2),
		new quadratic_eq(0.2,-33,4)
	};

	for(auto i : _equation) i->roots();

	system("pause");
}
