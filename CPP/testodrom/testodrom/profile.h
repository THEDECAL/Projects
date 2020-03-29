#pragma once
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include "test.cpp"
#include "fileMngr.cpp"
using std::string;
using std::vector;

//Пространство имён для классов аккаунта и учётных записей
namespace profile{
	using tst::answers;
	using fileMngr::fmngr;
	using namespace tst;
	const enum acc_type { ADMIN,TEACHER,USER,UNKNOWN };
	const enum status{ LOCK,UNLOCK };

	class account{
	protected:
		acc_type type;
		status _status = UNLOCK;
		string login;
		string password;
	public:
		account(){}
		account(const acc_type& t,const string& l,const string& p):type(t),login(l),password(p){}
		status get_status(){ return _status; }
		string get_login(){ return login; }
	};

	class user:public account{
	protected:
		string fname;
		string sname;
		fstream stream;
		vector<answers> passedTests; //Пройденные тесты
		test* pTest = NULL;
	public:
		user(){}
		user(const acc_type& t,const string& l,const string& p,const string& f,const string& s):account(t,l,p),fname(f),sname(s){}
		void menu();
		void show_stat();
		void save_tests(string path ="");
		void save();
		bool load_tests(string path = "");
		bool load(const string& account);
		void add_answers(const answers& a);
		bool check_password(const string& password) const;
		acc_type get_acc_type() const{ return type; }
		bool log_in(const string& login,const string& password);
		static acc_type load_type(const string& login);
		string navigate(string& mask,const string& title);
		test* test_navigate();
		void run_test();
		~user();
	};

	class teacher:public user{
	public:
		void menu();
		void edit_test();
		void add_test();
		void remove_test();
		void check_test();
	};

	class admin:public teacher{
	public:
		void menu();
		void change_status();
		void lock_unlock();
		void reset_count();
		void show();
		void show_user();
	};
}
