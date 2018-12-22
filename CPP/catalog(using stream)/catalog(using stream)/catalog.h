#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>
#include <string>
#include <string.h>
#define AMOUNTS_FIELDS 5
#define BUFFER_SIZE 261
using namespace std;

class catalog{
	string catalogFileName;
public:
	string showFileName();
	bool selectFile(const string&);
	bool show(const char* =NULL);
	bool add(const string&,const string&,const string&,const string&,const string&);
};
