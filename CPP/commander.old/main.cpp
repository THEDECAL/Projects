#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <conio.h>
#include <io.h>
#include <direct.h>
#include <fstream>
#include <string.h>
#include <Windows.h>
#include "messages.h"
using namespace std;

messages *messages::pMessages = new messages;
commander *commander::pCommander = new commander;

void main(unsigned lengthString,char *string[]){
	const commander *_commander = commander::getRef();
	//Локализация
	setlocale(LC_ALL,"rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	if(lengthString>1){ //Для режима в коммандной строке
		std::string sLine;
		for(size_t i = 1; i < lengthString;i++){
			sLine += string[i];
			sLine += ' ';
		}
		char *cLine = new char[sLine.size()+1];
		strcpy(cLine,sLine.c_str());
		cLine[strlen(cLine)] = '\0';
		//_commander->inputFilter(cLine);
		notify(_commander->inputFilter(cLine));

		delete cLine;
	}
	else{ //Для интеракивного режима
		char *line=NULL;
		while(TRUE){
			printf("%s%c",_getcwd(NULL,NULL),'>');
			//Динамическое выделение памяти для введённой строки
			line = _commander->DynamicStr();
			if(!strcmp(line,"exit")) break;
			//Обработка ввода
			_commander->inputFilter(line);
			//Запись введённой строки в журнал истории комманд
			_commander->inputHistory(line);
		}
		free(line);
	}
}
