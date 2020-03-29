#pragma once

#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>
#include <direct.h>
#include <io.h>
#include <conio.h>
#include <string>
#include <string.h>
#include <time.h>
#include "messages.cpp"
using namespace std;

class aborigen{
	//Переменные
	static aborigen *pAborigen;
	string prevDir;
	string HistoryFile;
	//Методы
	bool yesno();
	void choice(const string*);
	void dir(const char* =NULL);
	void clrScreen();
	void cd(const char*);
	void move(const char*,const char*);
	void mkFolder(const char*);
	void del(const char*);
	void copy(const char*,const char*);
	void opFile(const char*);
	void mkFile(const char*);
	string filename(const char*);
	void delLastSlash(char *);
	char* delSpaces(char*);
	string SpcToUnln(string&,const unsigned&);
	aborigen();
	public:
	static aborigen *getAborigen();
	void inputFilter(const char*);
	void inputHistory(const char*);
	string DynamicStr();
	~aborigen();
};
