#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <conio.h>
using std::string;
using std::vector;
using std::cout;
using std::endl;
using std::istream;
using std::cin;
using std::cerr;

enum KEYS { ENTER = 13, BACKSPACE = 8, S = 83,W = 87,s = 115,w = 119};
enum MTYPE{ ARROW, NUMBER };

static string enter_password(){
	string password;
	char select;
	for(;;){
		for(size_t i = 0; i < password.size(); i++){ cout << '*'; }
		cout << '\r';
		select = _getch();
		if(select == ENTER) return password;
		else if(select > ' ' && select < '~') password += select;
	}
}
static string enter_text(const string& title =""){
	string text;
	for(;;){
		cout << title;
		getline(cin, text);
		if(text.size() && text[0]!=' ') return text;
		else{
			cerr << "Поле должно быть заполнено и не иметь пробелов в начале.\n";
			system("pause");
		}
	}
}
static unsigned _menu(const vector<string> menu,const string& title = "", const MTYPE &type =NUMBER){
	unsigned select = -1;
	if(type == NUMBER){
		for(;;){
			system("cls");
			cout << title << endl;
			for(size_t i = 0; i < menu.size(); i++){
				cout << i + 1 << ". " << menu[i] << endl;
			}
			cout << endl << endl;
			cout << "Введите номер пункта меню\n";
			select = _getch() - 49;
			if(select >= 0 && select < menu.size()) return select;
		}
	}
	else if(type == ARROW){
		int arrow = 0;
		for(;;){
			if(arrow < 0) arrow = menu.size() - 1;
			else if(arrow > (int)menu.size() - 1) arrow = 0;

			system("cls");
			cout << title << endl;
			for(size_t i = 0; i < menu.size(); i++){
				(arrow == i)?cout << "-> ":cout << "   ";
				cout << menu[i] << endl;
			}
			cout << endl << endl;
			cout << "<Enter> выбрать ответ, <W\\w> вверх, <S\\s> вниз\n";
			select = _getch();
			switch(select){
				case w:case W:{ arrow--; break; }
				case s:case S:{ arrow++; break; }
				case ENTER:{ return arrow; }
			}
		}
	}
	else throw;
}
