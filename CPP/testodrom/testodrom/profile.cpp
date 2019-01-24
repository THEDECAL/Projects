#include "profile.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include "test.cpp"
#include "fileMngr.cpp"
using std::string;
using std::vector;

namespace profile{
	status account::get_status(){
		return _status;
	}
	string account::get_login(){
		return login;
	}

	void user::menu(){
		const enum MENU{ RUN, SHOW_STAT, EXIT };
		const vector<string> menu = { "Запустить тест", "Показать статистику", "Выход" };

		MENU select;
		do{
			select = (MENU)_menu(menu, "Меню", ARROW);
			switch(select){
				case RUN:{ run_test(); break; }
				case SHOW_STAT:{ show_stat(); break; }
			}
		} while(select!=EXIT);
	}
	void user::show_stat(){
		if(passedTests.size()){
			vector<string> test_names; //Список названий пройденных тестов

			//Заполняем список названий пройденных тестов
			for(auto i : passedTests) test_names.push_back(i.get_name());
			unsigned select = _menu(test_names,"Выберите тест:",ARROW);
			passedTests[select].show();
		}
		else cerr << "Ни одного теста не было пройдено.\n";

		system("pause");
	}
	void user::save_tests(string path=""){
		if(!path.size()) path = fileMngr::PASSED_TESTS + login;

		stream.open(path, ios::out | ios::binary);
		if(stream){
			unsigned cntPassedTests = passedTests.size();
			stream.write((char*)&cntPassedTests, sizeof(unsigned)); //Записываем кол-во пройденных тестов
			for(auto i : passedTests){ i.save(stream); } //Записываем тесты

			stream.close();
		}
		else throw "Невозможно открыть файл для записи";
	}
	void user::save(){
		string path = fileMngr::ACCOUNTS + login;
		stream.open(path,ios::out | ios::binary);
		if(stream){
			stream.write((char*)&type,sizeof(unsigned)); //Записываем тип аккаунта
			stream.write((char*)&_status, sizeof(unsigned)); //Записываем статус аккаунта
			fmngr::string_save(stream,login); //Записываем логин
			fmngr::string_save(stream,password); //Записываем пароль
			fmngr::string_save(stream,fname); //Записываем имя
			fmngr::string_save(stream,sname); //Записываем фамилию

			stream.close();
		}
		else throw "Невозможно открыть файл для записи";
	}
	bool user::load_tests(string path =""){
		if(!path.size()) path = fileMngr::PASSED_TESTS + login;

		if(fmngr::find(path)){
			stream.open(path, ios::in | ios::binary);
			if(stream){
				unsigned cntPassedTests;
				stream.read((char*)&cntPassedTests, sizeof(unsigned));
				for(size_t i = 0; i < cntPassedTests; i++){
					answers _answers;
					_answers.load(stream);
					passedTests.push_back(_answers);
				}

				stream.close();
				return 1;
			}
			else throw "Невозможно открыть файл для чтения";
		}
		return 0;
	}
	bool user::load(const string& account){
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
			else throw "Невозможно открыть файл для чтения";
		}
		return 0;
	}
	void user::add_answers(const answers& a){
		passedTests.push_back(a);
	}
	bool user::check_password(const string& password) const{
		return password==this->password;
	}
	acc_type user::get_acc_type() const{
		return type;
	}
	bool user::log_in(const string& login,const string& password){
		if(load(login) && check_password(password)) return 1;
		return 0;
	}
	acc_type user::load_type(const string& login){
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
	string user::navigate(string& mask,const string& title){
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
		menu.push_back("< Назад");

		unsigned select = _menu(menu, title, ARROW);
		mask.resize(mask.size() - 1);

		return menu[select];
	}
	test* user::test_navigate(){
		pTest = new test;
		string path = fileMngr::TESTS;

		string select = navigate(path,"Выберите категорию:");
		if(select[0] == '<') return NULL;  //Если выбран пункт меню "< Назад"
		path += select;
			
		select = navigate(path,"Выберите тест:");
		if(select[0] == '<') return NULL;  //Если выбран пункт меню "< Назад"
		path += select;
		pTest->load(path);

		return pTest;
	}
	void user::run_test(){
		if(!(pTest = test_navigate())) return;

		//Проверяем проходился этот тест ранее
		unsigned attempts = 0;
		for(auto it=passedTests.begin(); it<passedTests.end(); it++){
			if(it->get_name() == pTest->get_name()){
				attempts = it->get_attempts();
				passedTests.erase(it);
				break;
			}
		}
		if(attempts<amAttempts){
			answers* pAnswers = pTest->run(); //Запустить тест и получить вернёт ответы
			pAnswers->set_attempts(attempts+1); //Изменяем кол-во использованных попыток
			pAnswers->set_date(time(NULL)); //Изменяем дату сдачи
			passedTests.push_back(*(pAnswers)); //Доабавляем ответы к пользователю
			save_tests();
			delete pAnswers;
		}
		else{
			cerr << "Вы использовали все " << amAttempts << " попытки(ок).\n";
			system("pause");
		}

		delete pTest;
	}
	user::~user(){
		if(stream) stream.close();
		delete pTest;
	}

	void teacher::menu(){
		const enum MENU { ADD,EDIT,REMOVE,CHECK,EXIT };
		const vector<string> menu = {"Добавить тест", "Изменить тест", "Удалить тест", "Проверить тест", "Выход"};

		MENU select;
		do{
			select = (MENU)_menu(menu,"Меню",ARROW);
			switch(select){
			case ADD:{ add_test(); break; }
			case EDIT:{ edit_test(); break; }
			case REMOVE:{ remove_test(); break; }
			case CHECK:{ check_test(); break; }
			}
		} while(select != EXIT);
	}
	void teacher::edit_test(){
		if(!(pTest = test_navigate())) return;
		pTest->edit();

		delete pTest;
	}
	void teacher::add_test(){
		test::create();
	}
	void teacher::remove_test(){
		if(!(pTest = test_navigate())) return;
		pTest->remove();
		delete pTest;
	}
	void teacher::check_test(){
		string path = fileMngr::PASSED_TESTS;
		string login = navigate(path,"Выберите пользователя");
		if(login[0] == '<') return; //Если выбран пункт меню "< Назад"
		vector<string> test_names; //Список названий пройденных тестов

		load_tests(path + login);
		//Заполняем список названий пройденных тестов
		for(auto i : passedTests) test_names.push_back(i.get_name());

		unsigned select = _menu(test_names,"Выберите тест:",ARROW);
		passedTests[select].show();
		unsigned assessment = atoi(enter_text("Введите оценку:").c_str());
		passedTests[select].set_assessment(assessment);
		save_tests(path);
		passedTests.clear();
	}

	void admin::menu(){
		const enum MENU { ADD,EDIT,REMOVE,BLOCK_UNBLOCK,RESET_COUNT,SHOW_USER,EXIT };
		const vector<string> menu = {"Добавить тест",
			"Изменить тест",
			"Удалить тест",
			"Заблокировать/Разблокировать пользователя",
			"Сбросить счётчик попыток пройти тест",
			"Список пользователей",
			"Выход"};

		MENU select;
		do{
			select = (MENU)_menu(menu,"Меню",ARROW);
			switch(select){
			case ADD:{ add_test(); break; }
			case EDIT:{ edit_test(); break; }
			case REMOVE:{ remove_test(); break; }
			case BLOCK_UNBLOCK:{ lock_unlock(); break; }
			case RESET_COUNT:{ reset_count(); break; }
			case SHOW_USER:{ show_user(); break; }
			}
		} while(select != EXIT);
	}
	void admin::change_status(){
		(_status == UNLOCK)?_status = LOCK:_status = UNLOCK;
	}
	void admin::lock_unlock(){
		string path = fileMngr::ACCOUNTS;
		string login = navigate(path,"Выберите аккаунт:");
		if(login[0] == '<') return;  //Если выбран пункт меню "< Назад"
		auto_ptr<admin> pUser(new admin);
		if(login != this->login){
			if(pUser->load(login)){
				pUser->change_status();
				cout << pUser->get_login() << ' ';
				(pUser->get_status() == LOCK)?cout << "заблокирован.\n":cout << "разблокирован.\n";
				pUser->save();
			}
		}
		else cerr << "Невозможно заблокироать самого себя.\n";
		system("pause");
	}
	void admin::reset_count(){
		string path = fileMngr::ACCOUNTS;
		string login = navigate(path,"Выберите аккаунт:");
		if(login[0] == '<') return; //Если выбран пункт меню "< Назад"
		vector<string> test_names; //Список названий пройденных тестов

		load_tests(path + login);
		//Заполняем список названий пройденных тестов
		for(auto i : passedTests) test_names.push_back(i.get_name());

		unsigned select = _menu(test_names,"Выберите тест:",ARROW);
		passedTests[select].set_attempts(0);
		passedTests.clear();
	}
	void admin::show(){
		cout << "--------------------" << endl;
		cout << "Статус: "; (_status == LOCK)?cout << "Заблокирован\n":cout << "Активный\n";
		cout << "Тип: ";
		if(type == ADMIN) cout << "Администратор\n";
		else if(type == TEACHER) cout << "Учитель\n";
		else if(type == USER) cout << "Пользователь\n";
		cout << endl;
		cout << "Логин: " << login << endl;
		cout << "Пароль " << password << endl;
		cout << "Имя: " << fname << endl;
		cout << "Фамилия: " << sname << endl << endl;
		cout << "--------------------" << endl;
	}
	void admin::show_user(){
		string path = fileMngr::ACCOUNTS;
		string login = navigate(path,"Выберите аккаунт:");
		if(login[0] == '<') return; //Если выбран пункт меню "< Назад"
		auto_ptr<admin> pUser(new admin);
		pUser->load(login);
		pUser->show();

		system("pause");
	}
}
