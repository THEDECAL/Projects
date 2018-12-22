////
//Aborigen - file manager v1.0
////
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string>
#include <string.h>
#include <Windows.h>
#include "aborigen.h"

aborigen *aborigen::pAborigen=new aborigen; //Выделяем память для объекта

void main(unsigned lenStr,char *_text[]){
	////using namespace std;
	using std::string;
	using std::cout;

	//Локализация
	setlocale(LC_ALL,"rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	aborigen*_pAborigen = aborigen::getAborigen(); //Получаем адрес на объект

	char *cLine=NULL;
	string sLine;

	if(lenStr>1){ //Для режима в коммандной строке
		for(size_t i = 1; i < lenStr;i++){
			sLine +=_text[i];
			sLine += ' ';
		}
		cLine = new char[sLine.size()+1];
		strcpy(cLine,sLine.c_str());
		cLine[strlen(cLine)] = '\0';
		notify(_pAborigen->inputFilter(cLine));

		delete cLine;
	}
	else{ //Для интеракивного режима
		while(TRUE){
			cout<<_getcwd(NULL,NULL)<<'>';
			//Динамическое выделение памяти для введённой строки
			cLine = _pAborigen->DynamicStr();
			if(!strcmp(cLine,"exit")) break;
			notify(_pAborigen->inputFilter(cLine)); //Корректируем текст и получаем сообщения
			//Запись введённой строки в журнал истории комманд
			//_aborigen->inputHistory(line);

			free(cLine);
		}
	}
	/*system("pause");*/
}
