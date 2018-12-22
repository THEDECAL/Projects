#pragma once
#include <iostream>


//Абстрактный класс списка
class list{
public:
	struct node{
		unsigned value;
		node* next = NULL;
		node* prev = NULL;
	};
	node* pHead = NULL;
	node* pTail = NULL;
	unsigned size;
	list(){
		size = 0;
		pHead = pTail = NULL;
	}
	void push(const unsigned& value) {
		node* _node = new node;
		_node->value = value;
		_node->prev = pTail;
		if(pHead) {
			pTail->next = _node;
			pTail = _node;
		}
		else pHead = pTail = _node;
		size++;
	}
	void removeFromTail(){
		if(pTail){
			node* toDelete = pTail;
			pTail = toDelete->prev;
			if(pTail) pTail->next = NULL;
			delete toDelete;
			size--;
		}
	}
	void removeFromHead(){
		if(pHead){
			node* toDelete = pHead;
			pHead = toDelete->next;
			if(pHead) pHead->prev = NULL;
			delete toDelete;
			size--;
		}
	}
	void show() {
		if(size){
			node* ptr = pHead;
			while(ptr) {
				std::cout << ptr->value << ' ';
				ptr = ptr->next;
			}
			std::cout << '\n';
		}
		else std::cout << "List is empty.\n";
	}
	virtual unsigned pop() = 0;
	virtual ~list(){
		while(size) removeFromHead();
	}
};

class stack: public list{
public:
	unsigned pop(){
		unsigned temp = pTail->value;
		removeFromTail();

		return temp;
	}
};

class queue: public list{
public:
	unsigned pop(){
		unsigned temp = pHead->value;
		removeFromHead();

		return temp;
	}
};
