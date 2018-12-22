#pragma once
#include <vector>
#include <memory>
#include <algorithm>
#include <string>
#include "fileMngr.cpp"
#include "profile.cpp"
#include "tools.cpp"
using namespace std;

namespace app{
	using fileMngr::fmngr;
	using profile::user;

	//������ ���������
	static void start(){
		const enum MENU{ REGISTRATION, LOG_IN, EXIT };
		const vector<string> menu = { "�����������", "����", "�����" };

		//�������� �� ������������� �������� ����������
		if(!fmngr::find("accounts")) throw "����������� ���������� ��� ���������";
		if(!fmngr::find("tests")) throw "����������� ���������� ��� ������";
		if(!fmngr::find("passed_tests")) throw "����������� ���������� ��� ���������� ������";

		//���� ��� �������� ����� ������� ���
		if(!fmngr::find(fileMngr::ACCOUNTS + "admin")){
			user admin(profile::ADMIN,"admin","123","","");
		}

		MENU select;
		do{
			string title = "����� ���������� �\n\t\"TESTODROM\"\n������� ������������ ������\n";
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
						cout << "������� ����� (������ " << size << " �������� � a-z):";  getline(cin, login);
						//�������� ������
						for_each(login.begin(), login.end(), [&loginIsCorrect](const char s){
							if(s<'a' || s>'z') loginIsCorrect = false;
						});
						if(!loginIsCorrect || login.size() < size){
							cout << "����� ����� ����������.\n";
							system("pause");
							continue;
						}

						cout << "������� ������ (������ " << size << " ��������, a-z, A-Z � �����):\n"; password = enter_password();
						//�������� ������
						for_each(login.begin(), login.end(), [&loginIsCorrect](const char s){
							if(s<' ' || s>'~') loginIsCorrect = false;
						});
						if(!passwordIsCorrect || password.size() < size){
							cout << "����� ������ ����������.\n";
							system("pause");
							continue;
						}

						cout << "������� ��� (�������������):";  getline(cin, fname);
						cout << "������� ������� (�������������):";  getline(cin, sname);
						pAccount = new user(profile::USER, login, password, fname, sname);
						pAccount->save();

						cout << "�� ������������������ � �������, ������ ������ �������.\n";
						system("pause");

						break;
					} while(1);

					break;
				}
				case LOG_IN:{
					cout << "������� �����:\n"; getline(cin, login);
					cout << "������� ������:\n"; password = enter_password();
					profile::acc_type type = profile::user::load_type(login);

					if(type == profile::ADMIN){ pAccount = new profile::admin; }
					else if(type == profile::TEACHER){ pAccount = new profile::teacher; }
					else if(type == profile::USER){ pAccount = new profile::user; }
					else{
						cerr << "�� ����� ����� ����� ��� ������.\n";
						system("pause");
						break;
					}

					if(!pAccount->log_in(login, password)){ //�����������
						cerr << "�� ����� ����� ����� ��� ������.\n";
						system("pause");
						break;
					}

					if(pAccount->get_status() == profile::LOCK){
						cout << "��� ������� ������������, ���������� � ��������������.\n";
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
