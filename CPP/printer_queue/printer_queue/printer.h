#pragma once
#include <iostream>
#include <windows.h>
#include "client.h"
#include "statistic.h"
#define MAX_LENGTH_PRINT 10
#define MAX_LENGTH_STAT 10

class printer{
	client queue_print[MAX_LENGTH_PRINT];
	int cntPrints;
	statistic queue_stat[MAX_LENGTH_STAT];
	int cntStats;
	public:
	printer();
	void get();
	void get_stat();
	void print();
	void add_print();
	void add_stat(const char*);
};
