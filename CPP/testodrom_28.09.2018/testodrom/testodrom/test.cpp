#pragma once
#include "tools.cpp"
#include <iostream>
#include <vector>
#include <map>
#include <string>
#include <algorithm>
#include <fstream>
#include <conio.h>
#include <ctime>
#include "fileMngr.cpp"
using namespace std;

namespace tst{
	using fileMngr::fmngr;
	const unsigned amAttempts = 3;

	//Класс для хранения пройденых тестов
	class answers{
		unsigned attempts = 0; //Кол-во использованных попыток
		unsigned assessment = 0; //Оценка за тест
		string category; //Категория теста
		string name; //Название теста
		time_t date; //Дата последней сдачи
		vector<string> _questions; //Вопрос
		vector<string> _answers; //Ответ
	public:
		answers(){ time(&date); }
		answers(const string& category,const string& name):category(category),name(name){ time(&date); }
		unsigned get_attempts(){
			return attempts;
		}
		string get_name(){
			return name;
		}
		void set_attempts(const unsigned& a){
			attempts=a;
		}
		void add(const string& question,const string& answer){
			_questions.push_back(question);
			_answers.push_back(answer);
		}
		void show(){
			if(_questions.size()){
				tm time;
				localtime_s(&time,&date);
				char _date[100] = {0};
				strftime(_date,100,"%d %b %Yг. %H:%M",&time);

				cout << "--------------------" << endl;
				cout << "Дата последней сдачи: " << _date << endl;
				cout << "Категория: " << category << endl << endl;
				cout << "Название: " << name << endl;
				cout << "Оценка: "; ( assessment )?cout << assessment << endl:cout << "Нет\n";
				cout << "Количество использованных попыток: " << attempts << endl << endl;
				cout << "--------------------" << endl;
				for(size_t i = 0; i < _questions.size(); i++){
					cout << _questions[i] << endl;
					cout << '\t' << _answers[i] << endl;
				}
				cout << "--------------------" << endl;
			}
			else throw "Ответов нет";
		}
		void save(fstream& stream){
			fmngr::string_save(stream,category); //Записываем категорию
			fmngr::string_save(stream,name); //Записываем название
			stream.write((char*)&attempts,sizeof(unsigned)); //Записываем кол-во использованных попыток
			stream.write((char*)&assessment, sizeof(unsigned)); //Записываем оценку
			stream.write((char*)&date,sizeof(time_t)); //Записываем дату
			unsigned size = _questions.size();
			stream.write((char*)&size,sizeof(size)); //Записываем кол-во вопросов с ответами
			for(size_t i=0;i<_questions.size();i++){
				fmngr::string_save(stream, _questions[i]); //Записываем вопрос
				fmngr::string_save(stream, _answers[i]); //Записываем ответ
			}
		}
		void load(fstream& stream){
			category = fmngr::string_load(stream); //Загружаем категорию
			name = fmngr::string_load(stream); //Загружаем название
			stream.read((char*)&attempts, sizeof(unsigned)); //Загружаем кол-во использованных попыток
			stream.read((char*)&assessment, sizeof(unsigned)); //Загружаем оценку
			stream.read((char*)&date, sizeof(time_t)); //Загружаем дату
			unsigned amQuestions;
			stream.read((char*)&amQuestions, sizeof(unsigned)); //Загружаем кол-во вопросов с ответами
			for(size_t i = 0; i < amQuestions; i++){
				_questions.push_back(fmngr::string_load(stream));
				_answers.push_back(fmngr::string_load(stream));
			}
		}
		void set_assessment(const unsigned& a){
			assessment = a;
		}
		void set_date(const time_t& date ){
			this->date = date;
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
				answers* pAnswers = new answers(category, name);
				unsigned cntQuestions = 1;
				for(auto i : questions){
					system("cls");
					cout << category << endl << endl;
					cout << "</\\/\\\\/--- " << name << " ---\\//\\/\\>" << endl << endl;

					string question = to_string(cntQuestions) + "/" + to_string(questions.size())+" ";
					question+=i._question;
					unsigned answer = _menu(i._variants,question,ARROW);
					pAnswers->add(i._question, i._variants[answer]);

					cntQuestions++;
				}
				cout << "Поздравляем вы завершили тест.\n";
				system("pause");
				
				return pAnswers;
			}
			else throw "Тест пустой";
		}
		static void create(){
			auto_ptr<test> pTest(new test);
			string path = fileMngr::TESTS;

			pTest->category = enter_text("Введите категорию теста: ");
			path += pTest->category;
			fmngr::mkFolder(path);
			pTest->name = enter_text("Введите название теста: ");

			for(size_t i = 1;;i++){
				string text,title;
				question q;
				const string message = " (для завершения ввода введите \"q\")";
				title = "Введите вопрос №" + to_string(i) + message;text = enter_text(title);
				if(text == "q"){
					if(!pTest->questions.size()){
						cerr << "Нет ни одного вопроса.\n";
						system("pause");
						continue;
					}
					break;
				}
				q._question=text;
				cout << "Введите варианты ответов" << message << ":\n";
				for(;;){
					text = enter_text();
					if(text == "q"){
						if(!q._variants.size()){
							cerr << "Нет ни одного варианта ответа.\n";
							system("pause");
							continue;
						}
						break;
					}
					q._variants.push_back(text);
				}
				pTest->add_question(q);
			}
			pTest->save();
			cout << "Вы создали тест.\n";
			system("pause");
		}
		void edit(){
			enum{ CATEGORY, NAME, QUESTION, EXIT};
			enum{ ADD, REMOVE, EDIT};
			vector<string> menu = { "Категория", "Навзание", "Вопрос", "Назад" };
			vector<string> submenu = { "Добавить", "Удалить", "Изменить" };

			const string pleaseEnter = "Пожалуйста введите ";
			string path = fileMngr::TESTS;
			path += category;
			path += "\\"; path += name;

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
		}
		void add_question(const question& _question){
			questions.push_back(_question);
		}
		void show(const bool& only_questions =false){
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
			}
			else throw "Вопросов нет";
		}
		void save(){
			string path = fileMngr::TESTS+category;
			if(fmngr::mkFolder(path)) throw "Невозможно создать папку для категории";
			path += "\\"+name;
			stream.open(path,ios::out | ios::binary);
			if(stream){
				fmngr::string_save(stream,category); //записываем категорию теста
				fmngr::string_save(stream,name); //записываем название теста
				//unsigned size = category.size() + 1;
				//stream.write((char*)&size,sizeof(size)); //записываем размер категории теста
				//stream.write((char*)category.c_str(),size); //записываем категорию теста
				//size = name.size() + 1;
				//stream.write((char*)&size,sizeof(size)); //записываем размер названия теста
				//stream.write((char*)name.c_str(),size); //записываем название теста
				unsigned size = questions.size();
				stream.write((char*)&size,sizeof(size)); //записываем кол-во вопросов
				for(auto i : questions){
					fmngr::string_save(stream,i._question);
					//size = i._question.size() + 1;
					//stream.write((char*)&size,sizeof(size)); //записываем размер вопроса
					//stream.write((char*)i._question.c_str(),size); //записываем текст вопроса
					size = i._variants.size();
					stream.write((char*)&size,sizeof(size)); //записываем кол-во вариантов ответов
					for(auto j : i._variants){
						fmngr::string_save(stream,j);
						//size = j.size() + 1;
						//stream.write((char*)&size,sizeof(size)); //записываем размер варианта ответа
						//stream.write((char*)j.c_str(),size); //записываем вариант ответа
					}
				}
				stream.close();
			}
			else throw "Невозможно открыть файл для записи";
		}
		void load(const string& path){
			stream.open(path,ios::in | ios::binary);
			if(stream){
				category = fmngr::string_load(stream); //Записываем категорию
				name = fmngr::string_load(stream); //Записываем название

				unsigned amQuestions = 0;
				stream.read((char*)&amQuestions,sizeof(amQuestions)); //Считываем кол-во вопросов
				for(size_t i = 0; i < amQuestions; i++){
					question q;
					q._question = fmngr::string_load(stream); //Записываем вопрос

					unsigned amVariants = 0;
					stream.read((char*)&amVariants,sizeof(amVariants)); //Считываем кол-во вариантов ответов
					for(size_t i = 0; i < amVariants; i++){
						q._variants.push_back(fmngr::string_load(stream)); //Записываем вариант ответа
					}
					add_question(q); //Записываем вопрос и варианты ответов
				}
				stream.close();
			}
			else throw "Невозможно открыть файл для чтения";
		}
		void remove(){
			string path = fileMngr::TESTS+category+"\\"+name;
			fmngr::delFile(path);
		}
		string get_name(){
			return name;
		}
		~test(){
			if(stream) stream.close();
		}
	};
}
