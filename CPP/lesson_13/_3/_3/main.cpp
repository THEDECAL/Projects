#include <iostream>
#include "figure.h"

void main(){
	const unsigned amFigures = 4;
	figure *figures[amFigures] = {
		new circle(20.0),
		new rectangle(4.2,8.9),
		new triangle(5.2,6.0,5.2),
		new trapeze(8.9,10.1,12.0)
	};

	for(auto i : figures) i->show();

	system("pause");
}