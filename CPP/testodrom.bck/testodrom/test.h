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

	//����� ��� �������� ��������� ������
	class answers{
		unsigned attempts; //���-�� �������������� �������
		string category; //��������� �����
		string name; //�������� �����
		map<string,string> questionAndAnswer; //������ � �����
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
			else throw "������� ���";
		}
		answers& save(fstream& stream){
			fmngr::string_save(stream,category); //���������� ���������
			fmngr::string_save(stream,name); //���������� ���
			stream.write((char*)attempts,sizeof(unsigned)); //���������� ���-�� �������������� �������
			unsigned size = questionAndAnswer.size();
			stream.write((char*)&size,sizeof(size)); //���������� ���-�� �������� � ��������
			for(auto i : questionAndAnswer){
				fmngr::string_save(stream,i.first); //���������� ������
				fmngr::string_save(stream,i.second); //���������� �����
			}
			return *this;
		}
		answers& load(){

			return *this;
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
					cout << "������: <Enter> ������� �����, <W\\w> �����, <S\\s> ����\n";

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
				cout << "����������� �� ��������� ����.\n";
				system("pause");
				return pAnswers;
			}
			else throw "���� ������";
		}
		static void create(){
			auto_ptr<test> pTest(new test);
			const string pleaseEnter = "���������� ������� ";
			string text,path = fileMngr::TESTS;

			cout << pleaseEnter << "��������� �����: "; getline(cin,text);
			pTest->category = text;
			path += text;
			fmngr::mkFolder(path);
			cout << pleaseEnter << "�������� �����: "; getline(cin,text);
			pTest->name = text;

			for(size_t i = 1;;i++){
				question q;
				const string message = " (��� ���������� ����� ������� \"q\")";
				cout << pleaseEnter << "������ �" << i << message << ":\n"; getline(cin,text);
				if(text == "q") break;
				q._question=text;
				cout << pleaseEnter << "�������� �������" << message << ":\n";
				for(;;){
					getline(cin,text);
					if(text == "q") break;
					q._variants.push_back(text);
				}
				pTest->add_question(q);
			}
			pTest->save();
			cout << "�� ��������� ��������, ���� ������� �� ������� �����.\n";
		}
		test& edit(){
			enum{ CATEGORY, NAME, QUESTION, EXIT};
			enum{ ADD, REMOVE, EDIT};
			vector<string> menu = { "���������", "��������", "������", "�����" };
			vector<string> submenu = { "��������", "�������", "��������" };

			const string pleaseEnter = "���������� ������� ";
			string path = fileMngr::TESTS;
			path += category;
			path += "\\"; path += name;
			path += ".dat";

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
			else throw "�������� ���";
		}
		test& save(){
			string path = fileMngr::TESTS;
			path += category;
			if(fmngr::mkFolder(path)) throw "���������� ������� ����� ��� ���������";
			path += "\\"; path += name;
			path += ".dat";
			stream.open(path,ios::out | ios::binary);
			if(stream){
				unsigned size = category.size() + 1;
				stream.write((char*)&size,sizeof(size)); //���������� ������ ��������� �����
				stream.write((char*)category.c_str(),size); //���������� ��������� �����
				size = name.size() + 1;
				stream.write((char*)&size,sizeof(size)); //���������� ������ �������� �����
				stream.write((char*)name.c_str(),size); //���������� �������� �����
				size = questions.size();
				stream.write((char*)&size,sizeof(size)); //���������� ���-�� ��������
				for(auto i : questions){
					size = i._question.size() + 1;
					stream.write((char*)&size,sizeof(size)); //���������� ������ �������
					stream.write((char*)i._question.c_str(),size); //���������� ����� �������
					size = i._variants.size();
					stream.write((char*)&size,sizeof(size)); //���������� ���-�� ��������� �������
					for(auto j : i._variants){
						size = j.size() + 1;
						stream.write((char*)&size,sizeof(size)); //���������� ������ �������� ������
						stream.write((char*)j.c_str(),size); //���������� ������� ������
					}
				}
				stream.close();
				return *this;
			}
			else throw "���������� ������� ���� ��� ������";
		}
		test& load(const string& path){
			stream.open(path,ios::in | ios::binary);
			if(stream){
				unsigned size;
				stream.read((char*)&size,sizeof(size)); //��������� ������ ��������� �����
				char *buffer = new char[size];
				stream.read(buffer,size); //��������� ��������� �����
				this->category = buffer; //���������� � ����� ��������� �����
				delete[]buffer;

				stream.read((char*)&size,sizeof(size)); //��������� ������ �������� �����
				buffer = new char[size];
				stream.read(buffer,size); //��������� �������� �����
				this->name = buffer; //���������� � ����� �������� �����
				delete[]buffer;

				unsigned amQuestions = 0;
				stream.read((char*)&amQuestions,sizeof(amQuestions));
				for(size_t i = 0; i < amQuestions; i++){
					question q;
					stream.read((char*)&size,sizeof(size)); //��������� ������ �������
					buffer = new char[size];
					stream.read(buffer,size); //��������� ������
					q._question = buffer; //���������� ������
					delete[]buffer;

					unsigned amVariants = 0;
					stream.read((char*)&amVariants,sizeof(amVariants)); //��������� ���-�� ��������� �������
					for(size_t i = 0; i < amVariants; i++){
						stream.read((char*)&size,sizeof(size)); //��������� ������ �������� ������
						buffer = new char[size];
						stream.read(buffer,size);  //��������� ������� ������
						q._variants.push_back(buffer); //���������� ������� ������
						delete[]buffer;
					}
					add_question(q); //���������� � ����� ������
				}
				stream.close();
				return *this;
			}
			else throw "���������� ������� ���� ��� ������";
		}
		~test(){
			if(stream) stream.close();
		}
	};
}
