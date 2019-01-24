#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string>
using namespace std;
#define MAX_VIOLATIONS 5
#define MAX_CHAR_KEY 7
#define MAX_CHAR_VIOLATION 100
#define FILE_NAME_SIZE 256

struct node {
	string key;
	string violations[MAX_VIOLATIONS];
	unsigned cntViolations=0;
	node* left=NULL;
	node* right=NULL;
	node* parent=NULL;
};

class tree {
	node* root;
	public:
	tree();
	bool add(const string&,const string&);
	node* search(node*,const string&);
	void search(node*,const string&,const string&);
	void show(const node*);
	node* getRoot();
	//bool import(const char*);
	bool save(const char*);
	void save(const node*,FILE*);
	// ~tree();
};
