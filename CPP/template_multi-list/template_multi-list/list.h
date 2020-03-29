#pragma once
#include <iostream>

template <typename TYPE>
struct node {
	TYPE value=0;
	node* next=NULL;
	node* prev=NULL;
};
template <class TYPE>
class list {
	node<TYPE>* pHead;
	node<TYPE>* pTail;
	unsigned cntNodes;
	public:
	list();
	list(const unsigned&);
	list(const list&);
	unsigned getSize();
	void setSize(const unsigned&);
	void addToHead(const TYPE&);
	void addToTail(const TYPE&);
	void setValue(const unsigned&,const TYPE&);
	void removeFromHead();
	void clear();
	void show();
	list& operator=(const list& o);
	TYPE operator[](const unsigned&);
	~list();
};

template <typename TYPE> list<TYPE>::list() {
	pHead=pTail=NULL;
	cntNodes=0;
}
template <typename TYPE> list<TYPE>::list(const unsigned& size):list() {
	setSize(size);
}
template <typename TYPE> list<TYPE>::list(const list& o) {
	if(o.cntNodes) {
		node<TYPE>* ptr=o.pHead;
		while(ptr) {
			addToTail(ptr->value);
			ptr=ptr->next;
		}
	}
	else list();
}
template <typename TYPE> unsigned list<TYPE>::getSize() {
	return cntNodes;
}
template <typename TYPE> void list<TYPE>::setValue(const unsigned& index,const TYPE& value) {
	if(index>0&&index<=cntNodes) {
		node<TYPE>* ptr=pHead;
		for(int i=1; ptr; i++) {
			if(i==index) {
				ptr->value=value;
				break;
			}
			ptr=ptr->next;
		}
	}
}
template <typename TYPE> void list<TYPE>::setSize(const unsigned& size) {
	for(int i=0; i<size; i++) addToHead(rand()%4);
}
template <typename TYPE> void list<TYPE>::addToHead(const TYPE& value) {
	node<TYPE>* _node=new node<TYPE>;
	_node->value=value;
	_node->next=pHead;
	if(cntNodes) {
		pHead->prev=_node;
		pHead=_node;
	}
	else  pHead=pTail=_node;
	cntNodes++;
}
template <typename TYPE> void list<TYPE>::addToTail(const TYPE& value) {
	node<TYPE>* _node=new node<TYPE>;
	_node->value=value;
	_node->prev=pTail;
	if(pHead) {
		pTail->next=_node;
		pTail=_node;
	}
	else pHead=pTail=_node;
	cntNodes++;
}
template <typename TYPE> void list<TYPE>::removeFromHead() {
	if(pHead) {
		node<TYPE>* toDelete=pHead;

		pHead=toDelete->next;
		if(pHead) pHead->prev=NULL;
		delete toDelete;

		cntNodes--;
	}
}
template <typename TYPE> void list<TYPE>::clear(){
	if(pHead){
		node<TYPE>* ptr=pHead;
		while(ptr){
			ptr->value=0;
			ptr=ptr->next;
		}
	}
}
template <typename TYPE> void list<TYPE>::show() {
	if(cntNodes) {
		node<TYPE>* ptr=pHead;
		while(ptr) {
			std::cout<<"  "<<ptr->value;

			ptr=ptr->next;
		}
		std::cout<<'\n';
	}
	else std::cout<<"List is empty.\n";
}
template <typename TYPE> list<TYPE>& list<TYPE>::operator=(const list& o) {
	if(this==&o) return *this;
	this->~list();
	if(o.pHead) {
		node<TYPE>* ptr=o.pHead;
		while(ptr) {
			addToTail(ptr->value);
			ptr=ptr->next;
		}
	}
	else list();
	return *this;
}
template <typename TYPE> TYPE list<TYPE>::operator[](const unsigned& index) {
	if(index>0||index<=cntNodes) {
		node<TYPE>* ptr=pHead;
		for(int i=1; ptr; i++) {
			if(i==index) return ptr->value;
			ptr=ptr->next;
		}
	}
	return NULL;
}
template <typename TYPE> list<TYPE>::~list() {
	while(pHead) removeFromHead();
}
