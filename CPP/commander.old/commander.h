#pragma once
#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <direct.h>
#include <conio.h>
#include <io.h>
#include <string>
#include <string.h>
#define SIZE_LINE 260
using namespace std;

class commander{
	static commander* ptr;
	void dir(const char* =NULL);
	void help() const;
	void clearScreen();
	void cd(const char*);
	void move(const char*,const char*);
	void createFolder(const char*);
	char* fileName(const char*);
	commander();
	public:
	static commander* getRef();
	bool input(char*) const;
	~commander();
};
