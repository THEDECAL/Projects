////
////ABORIGEN this file manager
////
#define _CRT_SECURE_NO_WARNINGS
#define PROGRAMM_NAME "ABORIGEN"
#define VERSION 1.0

#include <iostream>
#include <string>
#include <string.h>
#include <Windows.h>
#include "aborigen.h"

aborigen *aborigen::pAborigen=new aborigen; //Выделяем память для объекта

void main(unsigned length,char *args[]){
	//Локализация
	setlocale(LC_ALL,"rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	aborigen*_pAborigen = aborigen::getAborigen(); //Получаем адрес на объект
	string line;

	if(length>1){ //Для режима в коммандной строке
		for(size_t i = 1; i < length;i++){ //Слияние всех аргументов в одну строку (т.к мы сами её делим) 
			line +=args[i];
			line += ' ';
		}
		_pAborigen->inputFilter(line.c_str()); //Проверяем введённый текст и запускаем соответсвующие функции
	}
	else{ //Для интеракивного режима
		cout<<PROGRAMM_NAME<<' '<<VERSION<<endl;
		while(TRUE){
			cout<<_getcwd(NULL,NULL)<<'>'; //Показываем текущую рабочую папку
			line = _pAborigen->DynamicStr();
			if(line == "exit") return;
			_pAborigen->inputHistory(line.c_str()); //Запись введённой строки в журнал истории комманд
			_pAborigen->inputFilter(line.c_str()); //Проверяем введённый текст и запускаем соответсвующие функции
		}
	}
}
