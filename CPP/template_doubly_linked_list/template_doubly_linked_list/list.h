#pragma once
#include <iostream>

template <typename TYPE>
struct node {
	TYPE value=0;
	node* next=NULL;
	node* prev=NULL;
};
template <typename TYPE>
class list {
	node<TYPE>* pHead;
	node<TYPE>* pTail;
	unsigned cntNodes;
	public:
	list();
	list(const list&);
	void addToHead(const TYPE&);
	void addToTail(const TYPE&);
	void addByIndex(const unsigned&,const TYPE&);
	void removeFromHead();
	void removeFromTail();
	void removeByIndex(const unsigned&);
	void removeAll();
	unsigned getSize();
	TYPE getAt(const unsigned&);
	void setAt(const unsigned&,const TYPE&);
	bool isEmpty();
	TYPE operator[](const unsigned&);
	list append(const list&,const list&);
	list& operator=(const list&);
	list operator+(const list&);
	list operator*(const list&);
	void show();
	~list();
};

template <typename TYPE>
list<TYPE>::list() {
	pHead=pTail=NULL;
	cntNodes=0;
}
template <typename TYPE>
list<TYPE>::list(const list& o):list() {
	if(o.pHead) {
		node<TYPE>* ptr=o.pHead;

		while(ptr) {
			addToTail(ptr->value);
			ptr=ptr->next;
		}
	}
}
template <typename TYPE>
void list<TYPE>::addToHead(const TYPE& value) {
	node<TYPE>* _node=new node<TYPE>;
	_node->value=value;
	_node->next=pHead;
	if(cntNodes) {
		pHead->prev=_node;
		pHead=_node;
	}
	else pHead=pTail=_node;
	cntNodes++;
}
template <typename TYPE>
void list<TYPE>::addToTail(const TYPE& value) {
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
template <typename TYPE>
void list<TYPE>::addByIndex(const unsigned& index,const TYPE& value) {
	if(pHead&&index<cntNodes) {
		node<TYPE>* _node=new node<TYPE>;
		_node->value=value;
		node<TYPE>* ptr=pHead;
		for(int i=1; ptr; i++) {
			if(i==index) {
				node<TYPE>* right=ptr->next;
				_node->next=right;
				_node->prev=ptr;
				right->prev=_node;
				ptr->next=_node;
				cntNodes++;
				break;
			}
			ptr=ptr->next;
		}
	}
	else addToTail(value);
}
template <typename TYPE>
void list<TYPE>::removeFromHead() {
	if(pHead) {
		node<TYPE>* toDelete=pHead;
		pHead=toDelete->next;
		if(pHead) pHead->prev=NULL;
		delete toDelete;
		cntNodes--;
	}
}
template <typename TYPE>
void list<TYPE>::removeFromTail() {
	if(pTail) {
		node<TYPE>* toDelete=pTail;
		pTail=toDelete->prev;
		if(pTail) pTail->next=NULL;
		delete toDelete;
		cntNodes--;
	}
}
template <typename TYPE>
void list<TYPE>::removeByIndex(const unsigned& index) {
	if(cntNodes) {
		if(index==1) removeFromHead();
		else if(index==cntNodes) removeFromTail();
		else if(index<cntNodes) {
			node<TYPE>* ptr=pHead;
			for(int i=1; ptr; i++) {
				if(i==index-1) {
					node<TYPE>* toDelete=ptr->next;
					node<TYPE>* right=ptr->next->next;
					ptr->next=right;
					right->prev=ptr;
					delete toDelete;
					cntNodes--;
					break;
				}
				ptr=ptr->next;
			}
		}
	}
}
template <typename TYPE>
void list<TYPE>::removeAll() {
	this->~list();
}
template <typename TYPE>
unsigned list<TYPE>::getSize() {
	return cntNodes;
}
template <typename TYPE>
TYPE list<TYPE>::getAt(const unsigned& index) {
	node<TYPE>* ptr=pHead;
	for(int i=1; pHead; i++) {
		if(i==index)
			return ptr->value;
		ptr=ptr->next;
	}
}
template <typename TYPE>
void list<TYPE>::setAt(const unsigned& index,const TYPE& value) {
	node<TYPE>* ptr=pHead;
	for(int i=1; pHead; i++) {
		if(i==index) {
			ptr->value=value;
			break;
		}
		ptr=ptr->next;
	}
}
template <typename TYPE>
bool list<TYPE>::isEmpty() {
	return !cntNodes;
}
template <typename TYPE>
TYPE list<TYPE>::operator[](const unsigned& index) {
	return getAt(index);
}
template <typename TYPE>
list<TYPE> list<TYPE>::append(const list& o1,const list& o2) {
	return o1+o2;
}
template <typename TYPE>
list<TYPE>& list<TYPE>::operator=(const list& o) {
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
template <typename TYPE>
list<TYPE> list<TYPE>::operator+(const list& o) {
	list tmp(*this);
	node<TYPE>* 	ptr=o.pHead;
	while(ptr) {
		tmp.addToTail(ptr->value);
		ptr=ptr->next;
	}
	return tmp;
}
template <typename TYPE>
list<TYPE> list<TYPE>::operator*(const list& o) {
	list tmp;
	node<TYPE>* ptr=pHead;
	node<TYPE>* ptro=o.pHead;
	node<TYPE>* ptrtmp=tmp.pHead;
	while(ptr) {
		ptro=o.pHead;
		while(ptro) {
			if(ptr->value==ptro->value) {
				bool ifOverlap=false;
				ptrtmp=tmp.pHead;
				while(ptrtmp) {
					if(ptro->value==ptrtmp->value) {
						ifOverlap=true;
						break;
					}
					ptrtmp=ptrtmp->next;
				}
				if(!ifOverlap) tmp.addToTail(ptr->value);
				break;
			}
			ptro=ptro->next;
		}
		ptr=ptr->next;
	}
	return tmp;
}
template <typename TYPE>
void list<TYPE>::show() {
	if(cntNodes) {
		node<TYPE>* ptr=pHead;
		std::cout<<"\tAddress a first element: "<<pHead<<"\n\t";
		while(ptr) {
			std::cout<<ptr->value<<' ';
			ptr=ptr->next;
		}
		std::cout<<'\n';
	}
	else std::cout<<"List is empty.\n";
}
template <typename TYPE>
list<TYPE>::~list() {
	while(pHead) removeFromHead();
}
