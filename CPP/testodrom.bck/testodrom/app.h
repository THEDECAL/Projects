#pragma once
#include <vector>
#include <string>
#include "tools.cpp"
using namespace std;

namespace app{
	static void start(){
		enum GMENU{ REGISTRATION,LOG_IN };
		const vector<string> startMenu = {"�����������", "����"};

		string title = "����� ���������� � \"TESTODROM - ������� ������������ ������\"\n";
		GMENU select = (GMENU)_menu(startMenu,title,ARROW);
		switch(select){
			case REGISTRATION:{

				break;
			}
			case LOG_IN:{
				string login,password;
				cout << "������� �����:\n"; getline(cin,login);
				cout << "������� ������:\n"; password = enter_password();
				
				break;
			}
		}
	}
}
