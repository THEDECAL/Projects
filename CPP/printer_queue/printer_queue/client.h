#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string.h>
#define MAX_NAME_SYMBOLS 6

class client{
	char name[MAX_NAME_SYMBOLS];
	unsigned prio;
	public:
	client();
	void operator=(const client&);
	char* get_name();
	unsigned get_prio();
};
