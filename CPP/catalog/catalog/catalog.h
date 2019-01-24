#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string.h>
#define FILE_NAME_SIZE 256
#define NAME_SIZE 16
#define DEFAULT_FILE_NAME "catalog.txt"

class catalog {
	char** name;
	long long* tel_num;
	int cntEntry;
	public:
	catalog();
	bool add(const char*,const long long&);
	void edit(const unsigned&,const char*);
	void edit(const unsigned&,const long long&);
	void del(const unsigned&);
	short search(const char*,catalog* =NULL);
	short search(const long long&,catalog* =NULL);
	bool search(const long long&,const long long&,catalog* =NULL);
	bool search(const char*,const char*,catalog* =NULL);
	void sort();
	bool show();
	bool show(const short&);
	unsigned getCntEntry();
	bool save(const char*);
	bool import(const char*);
	~catalog();
};
