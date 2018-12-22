#pragma once
//#include <iostream>
#include <vector>
#include <memory>
#include <algorithm>
#include <string>
#include "fileMngr.h"
#include "profile.h"
#include "tools.cpp"
using namespace std;

namespace app{
	using fileMngr::fmngr;
	using profile::user;

	//Проверка на существование ключевых директорий
	static void check_folders(){
		if(!fmngr::find(fileMngr::ACCOUNTS)) throw "Отсутсвует дериктория для аккаунтов";
		if(!fmngr::find(fileMngr::TESTS)) throw "Отсутсвует дериктория для тестов";
	}

	//Запуск программы
	static void start(){
		const enum MENU{ REGISTRATION, LOG_IN, EXIT };
		const vector<string> menu = { "Регистрация", "Вход", "Выход" };
		//const enum AMENU{ BLOCK_USER, ADD_TEST, EDIT_TEST, REMOVE_TEST };
		//const vector<string> startMenu = { "Блокировать пользователя","Добавить тест", "Изменить тест", "Удалить тест", "Выход" };
		//const enum TMENU{ ADD_TEST, EDIT_TEST, REMOVE_TEST, CHECK_TEST };
		//const enum UMENU{ RUN_TEST, SHOW_STAT,  };

		MENU select;
		do{
			string title = "Добро пожаловать в \"TESTODROM - система тестирования знаний\"\n";
			select = (MENU)_menu(menu, title, ARROW);

			string login, password;
			profile::user* pAccount = NULL;
			system("cls");
			switch(select){
				case REGISTRATION:{
					do{
						const unsigned size = 5;
						bool loginIsCorrect = true;
						bool passwordIsCorrect = true;
						string fname = "-", sname = "-";
						cout << "Введите логин (больше " << size << " символов и a-z):";  getline(cin, login);
						//Проверка логина
						for_each(login.begin(), login.end(), [&loginIsCorrect](const char s){
							if(s<'a' || s>'z') loginIsCorrect = false;
						});
						if(!loginIsCorrect || login.size() < size){
							cout << "Такой логин недопустим.\n";
							system("pause");
							continue;
						}

						cout << "Введите пароль (больше " << size << " символов, a-z, A-Z и знаки):\n"; password = enter_password();
						//Проверка пароля
						for_each(login.begin(), login.end(), [&loginIsCorrect](const char s){
							if(s<' ' || s>'~') loginIsCorrect = false;
						});
						if(!passwordIsCorrect || password.size() < size){
							cout << "Такой пароль недопустим.\n";
							system("pause");
							continue;
						}

						cout << "Введите имя (необязательно):";  getline(cin, fname);
						cout << "Введите фамилию (необязательно):";  getline(cin, sname);
						pAccount = new user(profile::USER, login, password, fname, sname);
						pAccount->save();

						cout << "Вы зарегестрировались в системе, теперь можете входить.\n";
						system("pause");

						break;
					} while(1);

					break;
				}
				case LOG_IN:{
					cout << "Введите логин:\n"; getline(cin, login);
					cout << "Введите пароль:\n"; password = enter_password();
					profile::acc_type type = profile::user::load_type(login);

					if(type == profile::ADMIN){ pAccount = new profile::admin; }
					else if(type == profile::TEACHER){ pAccount = new profile::teacher; }
					else if(type == profile::USER){ pAccount = new profile::user; }
					else{
						cerr << "Не верно введён логин или пароль.\n";
						system("pause");
						break;
					}

					if(!pAccount->log_in(login, password)){ //Авторизация
						cerr << "Не верно введён логин или пароль.\n";
						system("pause");
						break;
					}

					if(pAccount->get_status() == profile::LOCK){
						cout << "Ваш аккаунт заблокирован, обратитесь к администратору.\n";
						system("pause");
					}
					else pAccount->menu();

					break;
				}
							delete pAccount;
			}
		} while(select != EXIT);
	}
}
