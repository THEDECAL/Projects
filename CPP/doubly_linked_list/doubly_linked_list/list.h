#pragma once
#include <iostream>

struct node {
	unsigned value=0;
	node* next=NULL;
	node* prev=NULL;
};
class list {
	node* pHead;
	node* pTail;
	unsigned cntNodes;
	public:
	list();
	list(const list&);
	void addToHead(const unsigned&);
	void addToTail(const unsigned&);
	void addByIndex(const unsigned&,const unsigned&);
	void removeFromHead();
	void removeFromTail();
	void removeByIndex(const unsigned&);
	list& operator=(const list&);
	list operator+(const list&);
	list operator*(const list&);
	void show();
	~list();
};