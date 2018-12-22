#pragma once
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include "test.h"
#include "fileMngr.h"
using std::string;
using std::vector;

namespace profile{
	using tst::answers;
	using fileMngr::fmngr;
	using namespace tst;
	const enum acc_type { ADMIN, TEACHER, USER, UNKNOWN };
	const enum status{ LOCK, UNLOCK };

	class account{
	protected:
		acc_type type;
		status _status = UNLOCK;
		string login;
		string password;
	public:
		account(){}
		account(const acc_type& t,const string& l,const string& p):type(t),login(l),password(p){}
		void change_status(){ ( _status == UNLOCK )?_status=LOCK:_status=UNLOCK; }
		status get_status(){ return _status; }
	};

	class user:public account{
	protected:
		string fname;
		string sname;
		fstream stream;
		vector<answers> passedTests; //���������� �����
		test* pTest = NULL;
	public:
		user(){}
		user(const acc_type& t,const string& l,const string& p,const string& f,const string& s):account(t,l,p),fname(f),sname(s){}
		virtual void menu(){
			const enum MENU{ RUN, SHOW_STAT, EXIT };
			const vector<string> menu = { "��������� ����", "�������� ����������", "�����" };

			MENU select;
			do{
				select = (MENU)_menu(menu, "����", ARROW);
				switch(select){
					case RUN:{ run_test(); break; }
					case SHOW_STAT:{
						if(passedTests.size()) for(auto i : passedTests) i.show();
						system("pause");
						break;
					}
				}
			} while(select!=EXIT);
		}
		void save_tests(){
			string path = fileMngr::PASSED_TESTS + login;
			stream.open(path, ios::out | ios::binary);
			if(stream){
				unsigned cntPassedTests = passedTests.size();
				stream.write((char*)&cntPassedTests, sizeof(unsigned)); //���������� ���-�� ���������� ������
				for(auto i : passedTests){ i.save(stream); } //���������� �����

				stream.close();
			}
			else throw "���������� ������� ���� ��� ������";
		}
		void save(){
			string path = fileMngr::ACCOUNTS + login;
			stream.open(path,ios::out | ios::binary);
			if(stream){
				stream.write((char*)&type,sizeof(unsigned)); //���������� ��� ��������
				stream.write((char*)&_status, sizeof(unsigned)); //���������� ������ ��������
				fmngr::string_save(stream,login); //���������� �����
				fmngr::string_save(stream,password); //���������� ������
				fmngr::string_save(stream,fname); //���������� ���
				fmngr::string_save(stream,sname); //���������� �������

				stream.close();
			}
			else throw "���������� ������� ���� ��� ������";
		}
		bool load_tests(){
			string path = fileMngr::PASSED_TESTS + login;
			if(fmngr::find(path)){
				stream.open(path, ios::in | ios::binary);
				if(stream){
					unsigned cntPassesTests;
					stream.read((char*)&cntPassesTests, sizeof(unsigned));
					for(size_t i = 0; i < cntPassesTests; i++){
						answers _answers;
						_answers.load(stream);
						passedTests.push_back(_answers);
					}

					stream.close();
					return 1;
				}
				else throw "���������� ������� ���� ��� ������";
			}
			return 0;
		}
		bool load(const string& account){
			string path = fileMngr::ACCOUNTS + account;
			if(fmngr::find(path)){
				stream.open(path,ios::in | ios::binary);
				if(stream){
					stream.read((char*)&type,sizeof(unsigned));
					stream.read((char*)&_status, sizeof(unsigned));
					login = fmngr::string_load(stream);
					password = fmngr::string_load(stream);
					fname = fmngr::string_load(stream);
					sname = fmngr::string_load(stream);

					stream.close();
					load_tests();
					return 1;
				}
				else throw "���������� ������� ���� ��� ������";
			}
			return 0;
		}
		void add_answers(const answers& a){
			passedTests.push_back(a);
		}
		void show(){
			//cout<<"������: "; ( _status==LOCK ) ? cout<<"������������\n" : cout<<"��������\n";
			cout << "���: ";
			if(type == ADMIN) cout << "�������������\n";
			else if(type == TEACHER) cout << "�������\n";
			else if(type == USER) cout << "������������\n";
			cout << endl;
			cout << "�����: " << login << endl;
			cout << "������ " << password << endl;
			cout << "���: " << fname << endl;
			cout << "�������: " << sname << endl << endl;
		}
		bool check_password(const string& password) const{
			return password==this->password;
		}
		acc_type get_acc_type() const{ return type; }
		bool log_in(const string& login,const string& password){
			if(load(login) && check_password(password)) return 1;
			return 0;
		}
		static acc_type load_type(const string& login){
			string path = fileMngr::ACCOUNTS+login;
			if(fmngr::find(path)){
				fstream stream(path, ios::in|ios::binary);
				if(stream){
					acc_type temp;
					stream.read((char*)&temp, sizeof(unsigned));
					return temp;
				}
			}
			return UNKNOWN;
		}
		string navigate(string& mask,const string& title){
			mask += "\\*";
			vector<string> menu;
			_finddata_t* data_found = new _finddata_t;
			long num_find = _findfirst(mask.c_str(), data_found);

			string search;
			if(num_find != -1){
				while(_findnext(num_find, data_found) == 0){
					search = data_found->name;
					if(search == ".." || search == ".") continue;
					menu.push_back(search);
				}

				_findclose(num_find);
			}
			delete data_found;

			unsigned select = _menu(menu, title, ARROW);
			mask.resize(mask.size() - 1);

			return menu[select];
		}
		test* test_navigate(){
			pTest = new test;
			string path = fileMngr::TESTS;

			string title = "�������� ���������:\n";
			path += navigate(path, title);

			title = "�������� ����:\n";
			path += navigate(path, title);
			pTest->load(path);

			return pTest;
		}
		void run_test(){
			pTest = test_navigate();
			//��������� ���������� ���� ���� �����
			unsigned attempts = 0;
			for(auto it=passedTests.begin(); it<passedTests.end(); it++){
				if(it->get_name() == pTest->get_name()){
					attempts = it->get_attempts();
					passedTests.erase(it);
					break;
				}
			}
			if(attempts<amAttempts){
				answers* pAnswers = pTest->run();
				pAnswers->change_attempts(pAnswers->get_attempts()+attempts);
				passedTests.push_back(*(pAnswers));
				save_tests();
				delete pAnswers;
			}
			else cerr << "�� ������������ ��� " << amAttempts << " �������(��).\n";

			delete pTest;
		}
		~user(){
			if(stream) stream.close();
			delete pTest;
		}
	};

	class teacher:public user{
	public:
		void menu(){
			const enum MENU { ADD, EDIT, REMOVE, CHECK, EXIT };
			const vector<string> menu = { "�������� ����", "�������� ����", "������� ����", "��������� ����", "�����" };

			MENU select;
			do{
				select = (MENU)_menu(menu, "����", ARROW);
				switch(select){
					case ADD:{ add_test(); break; }
					case EDIT:{ edit_test(); break; }
					case REMOVE:{ remove_test(); break; }
					case CHECK:{ break; }
				}
			} while(select!=EXIT);
		}
		void edit_test(){
			pTest = test_navigate();
			pTest->edit();

			delete pTest;
		}
		void add_test(){
			//pTest->create();
			test::create();

			delete pTest;
		}
		void remove_test(){
			auto_ptr<test> pTest(new test);
			string path = fileMngr::TESTS;

			string title = "�������� ���������:\n";
			path += navigate(path, title);

			title = "�������� ����:\n";
			path += navigate(path, title);
			fmngr::delFile(path);
		}
	};
	class admin:public teacher{
	public:
		status lock(const string& login){
			if(login != this->login){
				auto_ptr<user> pUser(new user);
				if(pUser->load(login)){
					pUser->change_status();
					pUser->save();

					return pUser->get_status();
				}
			}
			else cerr << "���������� ������������ ������ ����.\n";
		}
		void menu(){
			const enum MENU { ADD, EDIT, REMOVE, BLOCK_UNBLOCK, EXIT };
			const vector<string> menu = { "�������� ����", "�������� ����", "������� ����", "�������������/�������������� ������������", "�����" };

			MENU select;
			do{
				select = (MENU)_menu(menu, "����", ARROW);
				switch(select){
					case ADD:{ add_test(); break; }
					case EDIT:{ edit_test(); break; }
					case REMOVE:{ remove_test(); break; }
					case BLOCK_UNBLOCK:{
						string path = fileMngr::ACCOUNTS;
						(lock(navigate(path, "�������� ����� ������������:")) == LOCK)?cout << "������������.\n":cout<<"�������������.\n";
						system("pause");

						break;
					}
				}
			} while(select!=EXIT);
		}
	};
}
