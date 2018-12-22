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
	//�����������
	setlocale(LC_ALL,"rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	if(lengthString>1){ //��� ������ � ���������� ������
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
	else{ //��� ������������� ������
		char *line=NULL;
		while(TRUE){
			printf("%s%c",_getcwd(NULL,NULL),'>');
			//������������ ��������� ������ ��� �������� ������
			line = _commander->DynamicStr();
			if(!strcmp(line,"exit")) break;
			//��������� �����
			_commander->inputFilter(line);
			//������ �������� ������ � ������ ������� �������
			_commander->inputHistory(line);
		}
		free(line);
	}
}
