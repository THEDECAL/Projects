#include <windows.h>
#include <iostream>
#include "app.cpp"
using namespace app;

void main(){
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "rus");

	try{
		system("color 9f");
		App.run();
	}
	catch(const char* message){
		std::cout << "\t������. " << message << ".\n";
		system("pause");
	}
	catch(...){
		std::cout << "\t�������������� ������.\n";
		system("pause");
	}
}
