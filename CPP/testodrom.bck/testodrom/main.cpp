#include <windows.h>
#include "app.h"
#include "profile.h"
#include "tools.cpp"
//#include "test.h"

void main(){
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "rus");

	using namespace app;
	using namespace profile;
	//using namespace fileMngr;
	//using namespace tst;
	try{
		//system("color 9f");
		//user u1(ADMIN,"admin","123","������","���������");
		//u1.save();
		//user u2(USER,"user","123","����","������");
		//u2.save();
		//user u3(TEACHER, "teacher", "123", "ϸ��", "������");
		//u3.save();
		//user u;
		//u.load("admin").show();
		//app::check_folders();
		app::start();

		//test t("������ Linux","�������� Linux");
		//question q1;
		//q1._question="����� �������� ������� ������ ������ ������� ����������?";
		//q1._variants.push_back("ls");
		//q1._variants.push_back("dir");
		//q1._variants.push_back("rm");
		//q1._variants.push_back("grep");
		//question q2;
		//q2._question="����� �������� ������� ��������� ������� �����������?";
		//q2._variants.push_back("ifconfig");
		//q2._variants.push_back("ipconfig");
		//q2._variants.push_back("netconfig");
		//t.add_question(q1).add_question(q2);
		//t.show().save();

		//test i;
		//i.load("tests\\������ IT\\���������� ��.dat");
		//i.show();
		//system("pause");
		//i.edit();
		//answers *a = i.run();
		//a->show();
		//delete a;
		//test::create();
	}
	catch(const char* message){
		cout << "\t������. " << message << ".\n";
		system("pause");
	}
	catch(...){
		cout << "\t�������������� ������.\n";
		system("pause");
	}
}
