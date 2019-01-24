#include <iostream>
#include <windows.h>
#include <conio.h>
#include "../BlackJack/suit_name.h"
using namespace std;

void gotoxy(const int x,const int y){
	COORD c={x, y};
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),c);
}

void get(const int x=0) {
	suit _suit=spade;
	name _name=ace;
	int y=0;
	char tmp;
	switch(_name) {
		case jocker: tmp='J'; break;
		case jack: tmp='J'; break;
		case queen: tmp='Q'; break;
		case king: tmp='K'; break;
		case ace: tmp='A'; break;
	};
	gotoxy(x,y);
	std::cout<<(char)218<<(char)196<<(char)196<<(char)196<<(char)196<<(char)196;
	std::cout<<(char)196<<(char)196<<(char)196<<(char)196<<(char)191;
	gotoxy(x,y+1);
	if(_name==card10) std::cout<<(char)179<<" "<<(char)_suit<<_name<<"     "<<(char)179;
	else if(_name<card10) std::cout<<(char)179<<" "<<(char)_suit<<_name<<"      "<<(char)179;
	else std::cout<<(char)179<<" "<<(char)_suit<<tmp<<"      "<<(char)179;
	gotoxy(x,y+2);
	std::cout<<(char)179<<"         "<<(char)179;
	gotoxy(x,y+3);
	std::cout<<(char)179<<"         "<<(char)179;
	gotoxy(x,y+4);
	std::cout<<(char)179<<"    "<<(char)_suit<<"    "<<(char)179;
	gotoxy(x,y+5);
	std::cout<<(char)179<<"         "<<(char)179;
	gotoxy(x,y+6);
	std::cout<<(char)179<<"         "<<(char)179;
	gotoxy(x,y+7);
	if(_name==card10) std::cout<<(char)179<<"     "<<(char)_suit<<_name<<" "<<(char)179;
	else if(_name<card10) std::cout<<(char)179<<"      "<<(char)_suit<<_name<<" "<<(char)179;
	else std::cout<<(char)179<<"      "<<(char)_suit<<tmp<<" "<<(char)179;
	gotoxy(x,y+8);
	std::cout<<(char)192<<(char)196<<(char)196<<(char)196<<(char)196<<(char)196;
	std::cout<<(char)196<<(char)196<<(char)196<<(char)196<<(char)217;
	std::cout<<"\n";
}

int main(){
	for(int i=0,j=0; i<3;i++,j+=11)
		get(j);

	system("pause");
	return 0;
}