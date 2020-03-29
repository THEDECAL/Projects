#include "list.h"

list::list() {
	pHead=pTail=NULL;
	cntNodes=0;
}
list::list(const list& o):list(){
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
	if(pHead) pHead=_node;
	else pHead=pTail=_node;
	cntNodes++;
}
void list::addToTail(const unsigned& value) {
	node* _node=new node;
	_node->value=value;
	if(pHead) {
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
				_node->next=ptr->next;
				ptr->next=_node;
				cntNodes++;
				break;
			}
			ptr=ptr->next;
		}
	}
	else addToTail(value);
}
void list::removeFromHead() {
	if(pHead) {
		node* toDelete=pHead;
		pHead=pHead->next;
		delete toDelete;
		cntNodes--;
	}
}
void list::removeFromTail() {
	if(pTail) {
		node* toDelete=pTail;
		node* ptr=pHead;
		while(ptr->next->next) ptr=ptr->next;
		ptr->next=NULL;
		pTail=ptr;
		delete toDelete;
		cntNodes--;
	}
}
void list::removeByIndex(const unsigned& index) {
	if(pHead) {
		if(index==1) removeFromHead();
		else if(index<=cntNodes) {
			node* ptr=pHead;
			for(int i=1; ptr; i++) {
				if(i==index-1) {
					node* toDelete=ptr->next;
					ptr->next=ptr->next->next;
					delete toDelete;
					cntNodes--;
					break;
				}
				ptr=ptr->next;
			}
		}
	}
}
void list::show() {
	if(pHead) {
		node* _node=pHead;
		std::cout<<"\tAddress a first element: "<<pHead<<"\n\t";
		while(_node) {
			std::cout<<_node->value<<" ";
			_node=_node->next;
		}
		std::cout<<'\n';
	}
	else std::cout<<"List is empty.\n";

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
list::~list() {
	while(pHead) removeFromHead();
}