#include <iostream>
#include <time.h>
#include <conio.h>
#include "one_armed_b.h"

int main() {
	srand(time(0));

	one_armed_b obj;

	char select=-1;
	do {
		//std::system("clear");
		std::system("cls");
		switch(select) {
			default: {
				std::cout<<"<--One-armed Bandits-->\n";
				std::cout<<"1. Start the game\n";
				std::cout<<"0. Exit\n";
				break;
			}
			case '1': {
				do {
					std::system("clear");
					switch(select) {
						case '1': {
							obj.rotation_barrel();
							obj.add_score();
						}
					}
					obj.get();
					std::cout<<"\tScore: "<<obj.get_score()<<"\n";
					std::cout<<"1. Push\n";
					std::cout<<"0. Finish the game\n";
					//std::cin>>select;
					select=_getch();
				} while(select!='0');
				select=-1;
				continue;
			}
		}
		//std::cin>>select;
		select=_getch();
	} while(select!='0');

	return 0;
}