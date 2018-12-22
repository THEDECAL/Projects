#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <ctime>
#include <string.h>
#define TIME_STRING_SIZE 80
#define MAX_NAME_SYMBOLS 6

class statistic{
	char name[MAX_NAME_SYMBOLS];
	char _time[TIME_STRING_SIZE];
	public:
	statistic(){};
	statistic(const char*);
	void current_time();
	char* get_name();
	char* get_time();
};
