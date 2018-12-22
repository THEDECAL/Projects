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

	//����� ��� �������� ��������� ������
	class answers{
		unsigned attempts = 0; //���-�� �������������� �������
		unsigned assessment = 0; //������ �� ����
		string category; //��������� �����
		string name; //�������� �����
		time_t date; //���� ��������� �����
		vector<string> _questions; //������
		vector<string> _answers; //�����
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
				strftime(_date,100,"%d %b %Y�. %H:%M",&time);

				cout << "--------------------" << endl;
				cout << "���� ��������� �����: " << _date << endl;
				cout << "���������: " << category << endl << endl;
				cout << "��������: " << name << endl;
				cout << "������: "; ( assessment )?cout << assessment << endl:cout << "���\n";
				cout << "���������� �������������� �������: " << attempts << endl << endl;
				cout << "--------------------" << endl;
				for(size_t i = 0; i < _questions.size(); i++){
					cout << _questions[i] << endl;
					cout << '\t' << _answers[i] << endl;
				}
				cout << "--------------------" << endl;
			}
			else throw "������� ���";
		}
		void save(fstream& stream){
			fmngr::string_save(stream,category); //���������� ���������
			fmngr::string_save(stream,name); //���������� ��������
			stream.write((char*)&attempts,sizeof(unsigned)); //���������� ���-�� �������������� �������
			stream.write((char*)&assessment, sizeof(unsigned)); //���������� ������
			stream.write((char*)&date,sizeof(time_t)); //���������� ����
			unsigned size = _questions.size();
			stream.write((char*)&size,sizeof(size)); //���������� ���-�� �������� � ��������
			for(size_t i=0;i<_questions.size();i++){
				fmngr::string_save(stream, _questions[i]); //���������� ������
				fmngr::string_save(stream, _answers[i]); //���������� �����
			}
		}
		void load(fstream& stream){
			category = fmngr::string_load(stream); //��������� ���������
			name = fmngr::string_load(stream); //��������� ��������
			stream.read((char*)&attempts, sizeof(unsigned)); //��������� ���-�� �������������� �������
			stream.read((char*)&assessment, sizeof(unsigned)); //��������� ������
			stream.read((char*)&date, sizeof(time_t)); //��������� ����
			unsigned amQuestions;
			stream.read((char*)&amQuestions, sizeof(unsigned)); //��������� ���-�� �������� � ��������
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

	//����� ������
	struct question{
		string _question; //������
		vector<string> _variants; //�������� �������
		void show(){
			cout << _question << endl;
			for(auto i : _variants){
				cout << '\t' << i << endl;
			}
		}
	};

	//����� ����
	class test{
		string name; //�������� �����
		string category; //��������� �����
		vector<question> questions; //�������
		fstream stream; //����� ��� ������\������
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
				cout << "����������� �� ��������� ����.\n";
				system("pause");
				
				return pAnswers;
			}
			else throw "���� ������";
		}
		static void create(){
			auto_ptr<test> pTest(new test);
			string path = fileMngr::TESTS;

			pTest->category = enter_text("������� ��������� �����: ");
			path += pTest->category;
			fmngr::mkFolder(path);
			pTest->name = enter_text("������� �������� �����: ");

			for(size_t i = 1;;i++){
				string text,title;
				question q;
				const string message = " (��� ���������� ����� ������� \"q\")";
				title = "������� ������ �" + to_string(i) + message;text = enter_text(title);
				if(text == "q"){
					if(!pTest->questions.size()){
						cerr << "��� �� ������ �������.\n";
						system("pause");
						continue;
					}
					break;
				}
				q._question=text;
				cout << "������� �������� �������" << message << ":\n";
				for(;;){
					text = enter_text();
					if(text == "q"){
						if(!q._variants.size()){
							cerr << "��� �� ������ �������� ������.\n";
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
			cout << "�� ������� ����.\n";
			system("pause");
		}
		void edit(){
			enum{ CATEGORY, NAME, QUESTION, EXIT};
			enum{ ADD, REMOVE, EDIT};
			vector<string> menu = { "���������", "��������", "������", "�����" };
			vector<string> submenu = { "��������", "�������", "��������" };

			const string pleaseEnter = "���������� ������� ";
			string path = fileMngr::TESTS;
			path += category;
			path += "\\"; path += name;

			for(;;){
				string title = "���������� ��������, ��� ������ ��������:",text;
				unsigned select = _menu(menu,title),smselect;
				if(select == EXIT) break;

				//�������� �������� ���� ��� ����� ���������
				switch(select){
					case CATEGORY:{
						cout << pleaseEnter << "����� �������� ���������:\n"; getline(cin,text);
						category = text;
						fmngr::delFile(path);
						break;
					}
					case NAME:{
						cout << pleaseEnter << "����� �������� �����:\n"; getline(cin,text);
						name = text;
						fmngr::delFile(path);

						break;
					}
					case QUESTION:{
						smselect = _menu(submenu);
						if(smselect == ADD){
							for(size_t i = 1;; i++){
								question q;
								const string message = " (��� ���������� ����� ������� \"q\")";
								cout << pleaseEnter << "������" << message << ":\n"; getline(cin,text);
								if(text == "q") break;
								q._question = text;
								cout << pleaseEnter << "�������� �������" << message << ":\n";
								for(;;){
									getline(cin,text);
									if(text == "q") break;
									q._variants.push_back(text);
								}
								add_question(q);
							}
						}
						else if(smselect == REMOVE){
							show(true); //�������� ������ ��������
							unsigned num = 0;
							cout << "������� ����� ������� ��� ��������: "; cin >> num;
							if(num-1>0 && num-1<questions.size()) questions.erase(questions.begin() + (num-1));
							else{
								cout << "����� ������ ������� ���.\n";
								system("pause");
							}
						}
						else if(smselect == EDIT){
							show(true); //�������� ������ ��������
							cout << "������� ����� ������� ��� ���������: "; getline(cin,text);
							unsigned num = atoi(text.c_str());

							cout << "������� ����� ������: "; getline(cin,text);
							if(num-1 > 0 && num-1 < questions.size()) questions[num - 1]._question = text;
							else{
								cout << "����� ������ ������� ���.\n";
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
			else throw "�������� ���";
		}
		void save(){
			string path = fileMngr::TESTS+category;
			if(fmngr::mkFolder(path)) throw "���������� ������� ����� ��� ���������";
			path += "\\"+name;
			stream.open(path,ios::out | ios::binary);
			if(stream){
				fmngr::string_save(stream,category); //���������� ��������� �����
				fmngr::string_save(stream,name); //���������� �������� �����
				//unsigned size = category.size() + 1;
				//stream.write((char*)&size,sizeof(size)); //���������� ������ ��������� �����
				//stream.write((char*)category.c_str(),size); //���������� ��������� �����
				//size = name.size() + 1;
				//stream.write((char*)&size,sizeof(size)); //���������� ������ �������� �����
				//stream.write((char*)name.c_str(),size); //���������� �������� �����
				unsigned size = questions.size();
				stream.write((char*)&size,sizeof(size)); //���������� ���-�� ��������
				for(auto i : questions){
					fmngr::string_save(stream,i._question);
					//size = i._question.size() + 1;
					//stream.write((char*)&size,sizeof(size)); //���������� ������ �������
					//stream.write((char*)i._question.c_str(),size); //���������� ����� �������
					size = i._variants.size();
					stream.write((char*)&size,sizeof(size)); //���������� ���-�� ��������� �������
					for(auto j : i._variants){
						fmngr::string_save(stream,j);
						//size = j.size() + 1;
						//stream.write((char*)&size,sizeof(size)); //���������� ������ �������� ������
						//stream.write((char*)j.c_str(),size); //���������� ������� ������
					}
				}
				stream.close();
			}
			else throw "���������� ������� ���� ��� ������";
		}
		void load(const string& path){
			stream.open(path,ios::in | ios::binary);
			if(stream){
				category = fmngr::string_load(stream); //���������� ���������
				name = fmngr::string_load(stream); //���������� ��������

				unsigned amQuestions = 0;
				stream.read((char*)&amQuestions,sizeof(amQuestions)); //��������� ���-�� ��������
				for(size_t i = 0; i < amQuestions; i++){
					question q;
					q._question = fmngr::string_load(stream); //���������� ������

					unsigned amVariants = 0;
					stream.read((char*)&amVariants,sizeof(amVariants)); //��������� ���-�� ��������� �������
					for(size_t i = 0; i < amVariants; i++){
						q._variants.push_back(fmngr::string_load(stream)); //���������� ������� ������
					}
					add_question(q); //���������� ������ � �������� �������
				}
				stream.close();
			}
			else throw "���������� ������� ���� ��� ������";
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
