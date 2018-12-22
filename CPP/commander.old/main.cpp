#include <iostream>
#include <string.h>
#include "commander.h"
using namespace std;

commander* commander::ptr=new commander;

void main(){
	const commander* _commander=commander::getRef();
	setlocale(LC_ALL,"rus");

	char line[SIZE_LINE]{};
	while(strcmp(line,"exit")!=0){
		cout<<_getcwd(NULL,NULL)<<'>';
		gets_s(line);
		_commander->input(line);
	}
}
