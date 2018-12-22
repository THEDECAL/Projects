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
	enum acc_type { ADMIN, TEACHER, USER };

	class account{
	protected:
		string login;
		string password;
		acc_type type;
	public:
		account(){}
		account(const acc_type& t,const string& l,const string& p):type(t),login(l),password(p){}
	};

	class user:public account{
		string fname;
		string sname;
		fstream stream;
		vector<answers> _answers; //Кол-во использованных попыток и ответы на пройденные тесты
	public:
		user(){}
		user(const acc_type& t,const string& l,const string& p,const string& f,const string& s):account(t,l,p),fname(f),sname(s){}
		user& save(){
			string path = fileMngr::ACCOUNTS + login + ".dat";
			stream.open(path,ios::out | ios::binary);
			if(stream){
				//Записываем тип аккаунта
				stream.write((char*)&type,sizeof(unsigned));
				//Записываем логин
				fmngr::string_save(stream,login);
				//Записываем пароль
				fmngr::string_save(stream,password);
				//Записываем имя
				fmngr::string_save(stream,fname);
				//Записываем фамилию
				fmngr::string_save(stream,sname);
				unsigned size = _answers.size();
				stream.write((char*)&size,sizeof(unsigned));
				if(size) for(auto i : _answers){ i.save(stream); } //Записываем ответы на пройденные тесты

				stream.close();
				return *this;
			}
			else throw "Невозможно открыть файл для записи";
		}
		user& load(const string& account){
			string path = fileMngr::ACCOUNTS + account + ".dat";
			if(fmngr::find(path)){
				stream.open(path,ios::in | ios::binary);
				if(stream){
					stream.read((char*)&type,sizeof(unsigned));
					login = fmngr::string_load(stream);
					password = fmngr::string_load(stream);
					fname = fmngr::string_load(stream);
					sname = fmngr::string_load(stream);
					unsigned size;
					stream.read((char*)&size,sizeof(unsigned));
					if(size){
						answers _answers;
						_answers.load();
						this->_answers.push_back(_answers);
					}

					stream.close();
					return *this;
				}
				else throw "Невозможно открыть файл для чтения";
			}
			else throw "Не верно введён логин или пароль";
		}
		user& add_answers(const answers& a){
			_answers.push_back(a);
			return *this;
		}
		user& show(){
			cout << "Тип: ";
			if(type == ADMIN) cout << "Администратор";
			else if(type == TEACHER) cout << "Учитель";
			else if(type == USER) cout << "Пользователь";
			cout << endl;
			cout << "Логин: " << login << endl;
			cout << "Пароль " << password << endl;
			cout << "Имя: " << fname << endl;
			cout << "Фамилия: " << sname << endl << endl;

			return *this;
		}
		~user(){
			if(stream) stream.close();
		}
	};
}
