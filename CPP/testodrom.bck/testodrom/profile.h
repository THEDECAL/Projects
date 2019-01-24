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
		vector<answers> _answers; //���-�� �������������� ������� � ������ �� ���������� �����
	public:
		user(){}
		user(const acc_type& t,const string& l,const string& p,const string& f,const string& s):account(t,l,p),fname(f),sname(s){}
		user& save(){
			string path = fileMngr::ACCOUNTS + login + ".dat";
			stream.open(path,ios::out | ios::binary);
			if(stream){
				//���������� ��� ��������
				stream.write((char*)&type,sizeof(unsigned));
				//���������� �����
				fmngr::string_save(stream,login);
				//���������� ������
				fmngr::string_save(stream,password);
				//���������� ���
				fmngr::string_save(stream,fname);
				//���������� �������
				fmngr::string_save(stream,sname);
				unsigned size = _answers.size();
				stream.write((char*)&size,sizeof(unsigned));
				if(size) for(auto i : _answers){ i.save(stream); } //���������� ������ �� ���������� �����

				stream.close();
				return *this;
			}
			else throw "���������� ������� ���� ��� ������";
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
				else throw "���������� ������� ���� ��� ������";
			}
			else throw "�� ����� ����� ����� ��� ������";
		}
		user& add_answers(const answers& a){
			_answers.push_back(a);
			return *this;
		}
		user& show(){
			cout << "���: ";
			if(type == ADMIN) cout << "�������������";
			else if(type == TEACHER) cout << "�������";
			else if(type == USER) cout << "������������";
			cout << endl;
			cout << "�����: " << login << endl;
			cout << "������ " << password << endl;
			cout << "���: " << fname << endl;
			cout << "�������: " << sname << endl << endl;

			return *this;
		}
		~user(){
			if(stream) stream.close();
		}
	};
}
