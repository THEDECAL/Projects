#include <windows.h>
#include "app.cpp"

void main(){
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "rus");

	using namespace app;
	try{
		system("color 9f");
		app::start();
	}
	catch(const char* message){
		cout << "\tОшибка. " << message << ".\n";
		system("pause");
	}
	catch(...){
		cout << "\tНепредвиденная Ошибка.\n";
		system("pause");
	}
}
