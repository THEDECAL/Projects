#include "_2048.h"
#include <time.h>
#include <conio.h>

int main() {
	srand(time(0));

	_2048 obj;
	obj.random_num();
	obj.random_num();

	char select=0;
	do {
		switch(select) {
			case 'w': { obj.up(); obj.random_num(); break; }
			case 's': { obj.down(); obj.random_num(); break; }
			case 'a': { obj.left(); obj.random_num(); break; }
			case 'd': { obj.right(); obj.random_num(); break; }
		}
		obj.get();
		std::cout<<"\nScore: "<<obj.get_score()<<"\n";
		std::cout<<"\nw - up, s - down, a - left, d - right, q - exit\n";
		select=_getch();
	} while(select!='q');

	return 0;
}
