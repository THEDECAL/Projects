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

aborigen *aborigen::pAborigen=new aborigen; //�������� ������ ��� �������

void main(unsigned length,char *args[]){
	//�����������
	setlocale(LC_ALL,"rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	aborigen*_pAborigen = aborigen::getAborigen(); //�������� ����� �� ������
	string line;

	if(length>1){ //��� ������ � ���������� ������
		for(size_t i = 1; i < length;i++){ //������� ���� ���������� � ���� ������ (�.� �� ���� � �����) 
			line +=args[i];
			line += ' ';
		}
		_pAborigen->inputFilter(line.c_str()); //��������� �������� ����� � ��������� �������������� �������
	}
	else{ //��� ������������� ������
		cout<<PROGRAMM_NAME<<' '<<VERSION<<endl;
		while(TRUE){
			cout<<_getcwd(NULL,NULL)<<'>'; //���������� ������� ������� �����
			line = _pAborigen->DynamicStr();
			if(line == "exit") return;
			_pAborigen->inputHistory(line.c_str()); //������ �������� ������ � ������ ������� �������
			_pAborigen->inputFilter(line.c_str()); //��������� �������� ����� � ��������� �������������� �������
		}
	}
}
