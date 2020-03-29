#pragma once
#include "list.h"

template <typename TYPE>
struct mnode {
	list<TYPE> value;
	mnode* next=NULL;
	mnode* prev=NULL;
};
template <class TYPE>
class matrix {
	mnode<TYPE>* pHead;
	mnode<TYPE>* pTail;
	unsigned lines;
	unsigned columns;
	void setSize(const unsigned&,const unsigned&);
	void addToHead(const unsigned&);
	void addToHead(const list<TYPE>&);
	void removeFromHead();
	public:
	matrix();
	matrix(const unsigned&,const unsigned&);
	matrix(const matrix&);
	matrix& operator=(const matrix&);
	matrix operator+(const matrix&);
	matrix operator-(const matrix&);
	matrix operator*(const matrix&);
	void clear();
	void show();
	~matrix();
};

template <typename TYPE> matrix<TYPE>::matrix() {
	pHead=pTail=NULL;
	lines=0;
}
template <typename TYPE> matrix<TYPE>::matrix(const matrix& o):matrix() {
	if(o.pHead) {
		this->columns=o.columns;
		mnode<TYPE>* ptr=o.pTail;
		while(ptr) {
			addToHead(ptr->value);
			ptr=ptr->prev;
		}
	}
}
template <typename TYPE> matrix<TYPE>::matrix(const unsigned& lines,const unsigned& columns):matrix() {
	this->columns=columns;
	setSize(lines,columns);
}
template <typename TYPE> void matrix<TYPE>::addToHead(const unsigned& columns) {
	mnode<TYPE>* _mnode=new mnode<TYPE>;
	_mnode->value.setSize(columns);
	_mnode->next=pHead;
	if(pHead) {
		pHead->prev=_mnode;
		pHead=_mnode;
	}
	else pHead=pTail=_mnode;
	lines++;
}
template <typename TYPE> void matrix<TYPE>::addToHead(const list<TYPE>& value) {
	mnode<TYPE>* _mnode=new mnode<TYPE>;
	_mnode->value=value;
	_mnode->next=pHead;
	if(pHead) {
		pHead->prev=_mnode;
		pHead=_mnode;
	}
	else pHead=pTail=_mnode;
	lines++;
}
template <typename TYPE> void matrix<TYPE>::removeFromHead() {
	if(pHead) {
		mnode<TYPE>* toDelete=pHead;
		pHead=toDelete->next;
		if(pHead) pHead->prev=NULL;
		delete toDelete;
		lines--;
	}
}
template <typename TYPE> void matrix<TYPE>::setSize(const unsigned& lines,const unsigned& columns) {
	for(int i=0; i<lines; i++) addToHead(columns);
}
template <typename TYPE> void matrix<TYPE>::clear() {
	if(pHead) {
		mnode<TYPE>* ptr=pHead;
		while(ptr) {
			ptr->value.clear();
			ptr=ptr->next;
		}
	}
}
template <typename TYPE> void matrix<TYPE>::show() {
	if(pHead) {
		// 		std::cout<<lines<<':'<<columns<<'\n';
		mnode<TYPE>* ptr=pHead;
		while(ptr) {
			ptr->value.show();
			ptr=ptr->next;
		}
		std::cout<<'\n';
	}
	else std::cout<<"Matrix is empty.\n";
}
template <typename TYPE> matrix<TYPE>& matrix<TYPE>::operator=(const matrix& o) {
	if(this==&o) return *this;
	this->~matrix();
	if(o.pHead) {
		this->columns=o.columns;
		mnode<TYPE>* ptr=o.pTail;
		while(ptr) {
			addToHead(ptr->value);
			ptr=ptr->prev;
		}
	}
	else matrix();
	return *this;
}
template <typename TYPE> matrix<TYPE> matrix<TYPE>::operator+(const matrix& o) {
	if(lines==o.lines&&columns==o.columns) {
		matrix tmp(lines,columns);
		mnode<TYPE>* ptr=pHead;
		mnode<TYPE>* ptro=o.pHead;
		mnode<TYPE>* ptrt=tmp.pHead;
		while(ptr) {
			for(int i=1; i<=columns; i++)
				ptrt->value.setValue(i,ptr->value[i]+ptro->value[i]);
			ptr=ptr->next;
			ptro=ptro->next;
			ptrt=ptrt->next;
		}
		return tmp;
	}
	else std::cout<<"Different size of matrix.\n";
}
template <typename TYPE> matrix<TYPE> matrix<TYPE>::operator-(const matrix& o) {
	if(lines==o.lines&&columns==o.columns) {
		matrix tmp(lines,columns);
		mnode<TYPE>* ptr=pHead;
		mnode<TYPE>* ptro=o.pHead;
		mnode<TYPE>* ptrt=tmp.pHead;
		while(ptr) {
			for(int i=1; i<=columns; i++)
				ptrt->value.setValue(i,ptr->value[i]-ptro->value[i]);
			ptr=ptr->next;
			ptro=ptro->next;
			ptrt=ptrt->next;
		}
		return tmp;
	}
	else std::cout<<"Different size of matrix.\n";
}
template <typename TYPE> matrix<TYPE> matrix<TYPE>::operator*(const matrix& o) {
	if(lines==o.lines&&columns==o.columns) {
		matrix tmp(lines,columns);
		tmp.clear();
		mnode<TYPE>* ptr=pHead;
		mnode<TYPE>* ptrt=tmp.pHead;
		for(int i=1; i<=lines; i++) {
			for(int j=1; j<=columns; j++) {
				mnode<TYPE>* ptro=o.pHead;
				for(int k=1; ptro; k++) {
					ptrt->value.setValue(j,ptrt->value[j]+(ptr->value[k]*ptro->value[j]));
					ptro=ptro->next;
				}
			}
			ptr=ptr->next;
			ptrt=ptrt->next;
		}
		return tmp;
	}
	else std::cout<<"Different size of matrix.\n";
}
template <typename TYPE> matrix<TYPE>::~matrix() {
	while(pHead) removeFromHead();
}
