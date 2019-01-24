////
////ABORIGEN this file manager
////
#define _CRT_SECURE_NO_WARNINGS
#define PROGRAMM_NAME "ABORIGEN"
#define VERSION 1.0
#define MAX_LNG_STR 261

#include <iostream>
#include <string>
#include <string.h>
#include <Windows.h>
#include "aborigen.h"

aborigen *aborigen::pAborigen=new aborigen; //Выделяем память для объекта

void main(unsigned lenStr,char *_text[]){
	//Локализация
	setlocale(LC_ALL,"rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	aborigen*_pAborigen = aborigen::getAborigen(); //Получаем адрес на объект

	if(lenStr>1){ //Для режима в коммандной строке
		char *cLine = NULL;
		string sLine;

		for(size_t i = 1; i < lenStr;i++){
			sLine +=_text[i];
			sLine += ' ';
		}
		cLine = new char[sLine.size()+1];
		strcpy(cLine,sLine.c_str());
		cLine[strlen(cLine)] = '\0';
		_pAborigen->inputFilter(cLine);
		delete cLine;
	}
	else{ //Для интеракивного режима
		cout<<PROGRAMM_NAME<<' '<<VERSION<<endl;
		while(TRUE){
			char line[MAX_LNG_STR];
			cout<<_getcwd(NULL,NULL)<<'>';
			//Динамическое выделение памяти для введённой строки
			gets_s(line);
			//cLine = _pAborigen->DynamicStr();
			if(!strcmp(line,"exit")) break;
			_pAborigen->inputFilter(line); //Корректируем текст и получаем сообщения
			//Запись введённой строки в журнал истории комманд
			//_aborigen->inputHistory(line);
		}
	}
	//system("pause");
}
