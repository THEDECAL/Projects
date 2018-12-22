#pragma once
#include <iostream>
#include <string>
using std::string;
using std::cout;
using std::endl;

//Абстрактный класс служащий
class employee{
public:
	string fullName;
	string dateBirth;
	employee(const string fullName,const string dateBirth)
		:fullName(fullName),dateBirth(dateBirth){}
	virtual void print() = 0;
	virtual void show(){
		cout << fullName << endl;
		cout << dateBirth << endl;
	}
};

class president: public employee{
public:
	president(const string fullName,const string dateBirth):employee(fullName,dateBirth){};
	void print(){
		cout << "President: \n";
		show();
	}
};

class manager: public employee{
public:
	manager(const string fullName,const string dateBirth):employee(fullName,dateBirth){};
	void print(){
		cout << "Manager: \n";
		show();
	}
};

class worker: public employee{
public:
	worker(const string fullName,const string dateBirth):employee(fullName,dateBirth){};
	void print(){
		cout << "Worker: \n";
		show();
	}
};
