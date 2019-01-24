#pragma once
#include "tools.cpp"
#include <iostream>
#include <vector>
#include <map>
#include <string>
#include <algorithm>
#include <fstream>
#include <conio.h>
#include "fileMngr.h"
using namespace std;

namespace tst{
	using fileMngr::fmngr;

	//Класс для хранения пройденых тестов
	class answers{
		unsigned attempts; //Кол-во использованных попыток
		string category; //Категория теста
		string name; //Название теста
		map<string,string> questionAndAnswer; //Вопрос и ответ
	public:
		answers(){}
		answers(const string& category,const string& name):category(category),name(name){}
		answers& add(const string& question,const string& answer){
			questionAndAnswer.insert(pair<string,string>(question,answer));
			return *this;
		}
		answers& show(){
			if(questionAndAnswer.size()){
				cout << category << endl << endl;
				cout << "</\\/\\\\/--- " << name << " ---\\//\\/\\>" << endl << endl;
				auto it = questionAndAnswer.end();
				do{
					it--;
					cout << it->first << endl;
					cout << '\t' << it->second << endl;
				}while(it != questionAndAnswer.begin());
				return *this;
			}
			else throw "Ответов нет";
		}
		answers& save(fstream& stream){
			fmngr::string_save(stream,category); //Записываем категорию
			fmngr::string_save(stream,name); //Записываем имя
			stream.write((char*)attempts,sizeof(unsigned)); //Записываем кол-во использованных попыток
			unsigned size = questionAndAnswer.size();
			stream.write((char*)&size,sizeof(size)); //Записываем кол-во вопросов с ответами
			for(auto i : questionAndAnswer){
				fmngr::string_save(stream,i.first); //Записываем вопрос
				fmngr::string_save(stream,i.second); //Записываем ответ
			}
			return *this;
		}
		answers& load(){

			return *this;
		}
	};

	//Класс вопрос
	struct question{
		string _question; //Вопрос
		vector<string> _variants; //Варианты ответов
		void show(){
			cout << _question << endl;
			for(auto i : _variants){
				cout << '\t' << i << endl;
			}
		}
	};

	//Класс тест
	class test{
		string name; //Название теста
		string category; //Категория теста
		vector<question> questions; //Вопросы
		fstream stream; //Поток для чтения\записи
	public:
		test(){}
		test(const string& category,const string& name):category(category),name(name){}
		answers* run(){
			if(questions.size()){
				answers *pAnswers = new answers(category,name);
				int arrow = 0;

				for(size_t i = 0; i < questions.size();){
					if (arrow < 0) arrow=questions[i]._variants.size()-1;
					else if(arrow > questions[i]._variants.size() - 1) arrow = 0;

					system("cls");
					cout << right << category << endl;
					cout << "</\\/\\\\/--- " << name << " ---\\//\\/\\>" << endl << endl;
					cout << i+1 << "\\" << questions.size() << ". " << questions[i]._question << endl;
					unsigned cntVariants = 0;
					char select = -1;
					for(auto variant : questions[i]._variants){
						(arrow == cntVariants)?cout<<"\t-> ":cout<<"\t   ";
						cout << (char)(cntVariants + 97) << "). " << variant << endl;
						cntVariants++;
					}
					cout << endl << endl;
					cout << "Помощь: <Enter> выбрать ответ, <W\\w> вверх, <S\\s> вниз\n";

					select = _getch();
					switch(select){
						case W:case w:{ arrow--; break; }
						case S:case s:{ arrow++; break; }
						case ENTER:{
							pAnswers->add(questions[i]._question,questions[i]._variants[arrow]);
							arrow = 0;
							i++;
							break;
						}
					}
				}
				cout << "Поздравляем вы завершили тест.\n";
				system("pause");
				return pAnswers;
			}
			else throw "Тест пустой";
		}
		static void create(){
			auto_ptr<test> pTest(new test);
			const string pleaseEnter = "Пожалуйста введите ";
			string text,path = fileMngr::TESTS;

			cout << pleaseEnter << "категорию теста: "; getline(cin,text);
			pTest->category = text;
			path += text;
			fmngr::mkFolder(path);
			cout << pleaseEnter << "название теста: "; getline(cin,text);
			pTest->name = text;

			for(size_t i = 1;;i++){
				question q;
				const string message = " (для завершения ввода введите \"q\")";
				cout << pleaseEnter << "вопрос №" << i << message << ":\n"; getline(cin,text);
				if(text == "q") break;
				q._question=text;
				cout << pleaseEnter << "варианты ответов" << message << ":\n";
				for(;;){
					getline(cin,text);
					if(text == "q") break;
					q._variants.push_back(text);
				}
				pTest->add_question(q);
			}
			pTest->save();
			cout << "Вы завершили создание, тест сохранён на жестком диске.\n";
		}
		test& edit(){
			enum{ CATEGORY, NAME, QUESTION, EXIT};
			enum{ ADD, REMOVE, EDIT};
			vector<string> menu = { "Категория", "Навзание", "Вопрос", "Назад" };
			vector<string> submenu = { "Добавить", "Удалить", "Изменить" };

			const string pleaseEnter = "Пожалуйста введите ";
			string path = fileMngr::TESTS;
			path += category;
			path += "\\"; path += name;
			path += ".dat";

			for(;;){
				string title = "Пожалуйста выберите, что хотите изменить:",text;
				unsigned select = _menu(menu,title),smselect;
				if(select == EXIT) break;

				//Перестаёт работать меню при вводе кириллицы
				switch(select){
					case CATEGORY:{
						cout << pleaseEnter << "новое название категории:\n"; getline(cin,text);
						category = text;
						fmngr::delFile(path);
						break;
					}
					case NAME:{
						cout << pleaseEnter << "новое название теста:\n"; getline(cin,text);
						name = text;
						fmngr::delFile(path);

						break;
					}
					case QUESTION:{
						smselect = _menu(submenu);
						if(smselect == ADD){
							for(size_t i = 1;; i++){
								question q;
								const string message = " (для завершения ввода введите \"q\")";
								cout << pleaseEnter << "вопрос" << message << ":\n"; getline(cin,text);
								if(text == "q") break;
								q._question = text;
								cout << pleaseEnter << "варианты ответов" << message << ":\n";
								for(;;){
									getline(cin,text);
									if(text == "q") break;
									q._variants.push_back(text);
								}
								add_question(q);
							}
						}
						else if(smselect == REMOVE){
							show(true); //Показать список вопросов
							unsigned num = 0;
							cout << "Введите номер вопроса для удаления: "; cin >> num;
							if(num-1>0 && num-1<questions.size()) questions.erase(questions.begin() + (num-1));
							else{
								cout << "Этого номера вопроса нет.\n";
								system("pause");
							}
						}
						else if(smselect == EDIT){
							show(true); //Показать список вопросов
							cout << "Введите номер вопроса для изменения: "; getline(cin,text);
							unsigned num = atoi(text.c_str());

							cout << "Введите новый вопрос: "; getline(cin,text);
							if(num-1 > 0 && num-1 < questions.size()) questions[num - 1]._question = text;
							else{
								cout << "Этого номера вопроса нет.\n";
								system("pause");
							}
						}

						break;
					}
				}
			}
			save();

			return *this;
		}
		test& add_question(const question& _question){
			questions.push_back(_question);
			return *this;
		}
		test& show(const bool& only_questions =false){
			if(questions.size()){
				if(!only_questions){
					cout << category << endl << endl;
					cout << "</\\/\\\\/--- " << name << " ---\\//\\/\\>" << endl << endl;
					for(auto i : questions){ i.show(); }
				}
				else{
					unsigned cntQuestions = 1;
					for(auto i : questions){
						cout << cntQuestions << ". ";
						for(size_t j = 0; j < i._question.size(); j++){ cout << i._question[j]; }
						cout << endl;
						cntQuestions++;
					}
				}
				return *this;
			}
			else throw "Вопросов нет";
		}
		test& save(){
			string path = fileMngr::TESTS;
			path += category;
			if(fmngr::mkFolder(path)) throw "Невозможно создать папку для категории";
			path += "\\"; path += name;
			path += ".dat";
			stream.open(path,ios::out | ios::binary);
			if(stream){
				unsigned size = category.size() + 1;
				stream.write((char*)&size,sizeof(size)); //записываем размер категории теста
				stream.write((char*)category.c_str(),size); //записываем категорию теста
				size = name.size() + 1;
				stream.write((char*)&size,sizeof(size)); //записываем размер названия теста
				stream.write((char*)name.c_str(),size); //записываем название теста
				size = questions.size();
				stream.write((char*)&size,sizeof(size)); //записываем кол-во вопросов
				for(auto i : questions){
					size = i._question.size() + 1;
					stream.write((char*)&size,sizeof(size)); //записываем размер вопроса
					stream.write((char*)i._question.c_str(),size); //записываем текст вопроса
					size = i._variants.size();
					stream.write((char*)&size,sizeof(size)); //записываем кол-во вариантов ответов
					for(auto j : i._variants){
						size = j.size() + 1;
						stream.write((char*)&size,sizeof(size)); //записываем размер варианта ответа
						stream.write((char*)j.c_str(),size); //записываем вариант ответа
					}
				}
				stream.close();
				return *this;
			}
			else throw "Невозможно открыть файл для записи";
		}
		test& load(const string& path){
			stream.open(path,ios::in | ios::binary);
			if(stream){
				unsigned size;
				stream.read((char*)&size,sizeof(size)); //Считываем размер категории теста
				char *buffer = new char[size];
				stream.read(buffer,size); //Считываем категорию теста
				this->category = buffer; //Записываем в класс категорию теста
				delete[]buffer;

				stream.read((char*)&size,sizeof(size)); //Считываем размер названия теста
				buffer = new char[size];
				stream.read(buffer,size); //Считываем название теста
				this->name = buffer; //Записываем в класс название теста
				delete[]buffer;

				unsigned amQuestions = 0;
				stream.read((char*)&amQuestions,sizeof(amQuestions));
				for(size_t i = 0; i < amQuestions; i++){
					question q;
					stream.read((char*)&size,sizeof(size)); //Считываем размер вопроса
					buffer = new char[size];
					stream.read(buffer,size); //Считываем вопрос
					q._question = buffer; //Записываем вопрос
					delete[]buffer;

					unsigned amVariants = 0;
					stream.read((char*)&amVariants,sizeof(amVariants)); //Считываем кол-во вариантов ответов
					for(size_t i = 0; i < amVariants; i++){
						stream.read((char*)&size,sizeof(size)); //Считываем размер варианта ответа
						buffer = new char[size];
						stream.read(buffer,size);  //Считываем вариант ответа
						q._variants.push_back(buffer); //Записываем вариант ответа
						delete[]buffer;
					}
					add_question(q); //Записываем в класс вопрос
				}
				stream.close();
				return *this;
			}
			else throw "Невозможно открыть файл для чтения";
		}
		~test(){
			if(stream) stream.close();
		}
	};
}
