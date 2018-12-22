#include <iostream>
#include <string>
using namespace std;

class student{
	string name;
	unsigned age;
	bool sex;
	string group;
public:
	student(const string& name,const unsigned& age,const bool& sex,const string& group){
		this->name=name;
		this->age=age;
		this->sex=sex;
		this->group=group;
	}
	virtual void show(){
		cout<<endl;
		cout<<"Name: "<<name<<endl;
		cout<<"Age: "<<age<<endl;
		cout<<"Sex: "; (sex)?cout<<"Male\n":cout<<"Female\n";
		cout<<"Group: "<<group<<endl;
	}
};

class aspirant:public student{
	string work;
public:
	aspirant(const string& name,const unsigned& age,const bool& sex,const string& group,const string& work):student(name,age,sex,group){
		this->work=work;
	}
	void show(){
		student::show();
		cout<<"Work: "<<work<<endl;
	}
};

void main(){
	aspirant obj("Nikita Zvegintsev",28,1,"PP-17o2","Generation of random numbers");
	obj.show();

	system("pause");
}
