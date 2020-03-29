#include "list.h"

list::list() {
	pHead=pTail=NULL;
	cntNodes=0;
}
list::list(const list& o):list() {
	if(o.pHead) {
		node* ptr=o.pHead;
		while(ptr) {
			addToTail(ptr->value);
			ptr=ptr->next;
		}
	}
}
void list::addToHead(const unsigned& value) {
	node* _node=new node;
	_node->value=value;
	_node->next=pHead;
	if(cntNodes){
		pHead->prev=_node;
		pHead=_node;
	}
	else pHead=pTail=_node;
	cntNodes++;
}
void list::addToTail(const unsigned& value) {
	node* _node=new node;
	_node->value=value;
	_node->prev=pTail;
	if(cntNodes) {
		pTail->next=_node;
		pTail=_node;
	}
	else pHead=pTail=_node;
	cntNodes++;
}
void list::addByIndex(const unsigned& index,const unsigned& value) {
	if(pHead&&index<cntNodes) {
		node* _node=new node;
		_node->value=value;
		node* ptr=pHead;
		for(int i=1; ptr; i++) {
			if(i==index) {
				node* right=ptr->next;
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
	else
		addToTail(value);
}
void list::removeFromHead() {
	if(pHead) {
		node* toDelete=pHead;
		pHead=toDelete->next;
		if(pHead) pHead->prev=NULL;
		delete toDelete;
		cntNodes--;
	}
}
void list::removeFromTail() {
	if(pTail) {
		node* toDelete=pTail;
		pTail=toDelete->prev;
		if(pTail) pTail->next=NULL;
		delete toDelete;
		cntNodes--;
	}
}
void list::removeByIndex(const unsigned& index) {
	if(pHead) {
		if(index==1) removeFromHead();
		else if(index==cntNodes) removeFromTail();
		else if(index<cntNodes) {
			node* ptr=pHead;
			for(int i=1; ptr; i++) {
				if(i==index-1) {
					node* toDelete=ptr->next;
					node* right=ptr->next->next;
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
list& list::operator=(const list& o) {
	if(this==&o) return *this;
	this->~list();
	if(o.pHead) {
		node* ptr=o.pHead;
		while(ptr) {
			addToTail(ptr->value);
			ptr=ptr->next;
		}
	}
	else list();
	return *this;
}
list list::operator+(const list& o) {
	list tmp(*this);
	node* ptr=o.pHead;
	while(ptr) {
		tmp.addToTail(ptr->value);
		ptr=ptr->next;
	}
	return tmp;
}
list list::operator*(const list& o) {
	list tmp;
	node* ptr=pHead;
	node* ptro=o.pHead;
	node* ptrtmp=tmp.pHead;
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
void list::show() {
	if(pHead) {
		node* ptr=pHead;
		std::cout<<"\tAddress a first element: "<<pHead<<"\n\t";
		while(ptr) {
			std::cout<<ptr->value<<" ";
			ptr=ptr->next;
		}
		std::cout<<"\n\t";
		ptr=pTail;
		while(ptr) {
			std::cout<<ptr->value<<" ";
			ptr=ptr->prev;
		}
		std::cout<<'\n';
	}
	else std::cout<<"List is empty.\n";
}
list::~list() {
	while(pHead) removeFromHead();
}