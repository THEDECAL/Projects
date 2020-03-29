#include <iostream>

//������������ �������� ������ ��� ����� ��������

static char* cDynamicStr(){ //������� ���� char
	long long size = 1;
	char* text=(char*)calloc(size,sizeof(char));
	while(true){
		char ch;
		std::cin.get(ch);
		if(ch == '\n') return text; //���� ������� ������� ENTER ������� ������
		text=(char*)realloc(text,++size*sizeof(char)); //������������� ������
		text[size-1]='\0'; //��������� ������, ����� ������
		text[size-2]=ch; //������������� ������, �������� ������
	}
}
static std::string sDynamicStr(){ //������� ���� string
	long long size = 1;
	std::string text;
	while(true){
		char ch;
		std::cin.get(ch);
		if(ch == '\n') return text; //���� ������� ������� ENTER ������� ������
		text += ch;
	}
}
