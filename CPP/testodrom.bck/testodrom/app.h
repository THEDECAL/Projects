#pragma once
#include <vector>
#include <string>
#include "tools.cpp"
using namespace std;

namespace app{
	static void start(){
		enum GMENU{ REGISTRATION,LOG_IN };
		const vector<string> startMenu = {"Регистрация", "Вход"};

		string title = "Добро пожаловать в \"TESTODROM - система тестирования знаний\"\n";
		GMENU select = (GMENU)_menu(startMenu,title,ARROW);
		switch(select){
			case REGISTRATION:{

				break;
			}
			case LOG_IN:{
				string login,password;
				cout << "Введите логин:\n"; getline(cin,login);
				cout << "Введите пароль:\n"; password = enter_password();
				
				break;
			}
		}
	}
}
