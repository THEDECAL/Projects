// #pragma once
#include "phonebook.h"
#include <iostream>
#include <string.h>
using namespace std;

phonebook::phonebook(){
	records=NULL;
	size=0;
}
void phonebook::add(const char* name,const char* pnum_mob,const char* pnum_home,const char* pnum_work,const char* comments){
	phonenumber *tmp=new phonenumber[size+1];
	if(size){
		for(int i=0; i<size;i++)
			tmp[i]=records[i];
	}
	delete[]records;
	records=NULL;
	tmp[size].add(name,pnum_mob,pnum_home,pnum_work,comments);
	records=tmp;
	size++;
}
void phonebook::show(){
	for(int i=0; i<size; i++){
		cout<<i+1<<". ";
		records[i].show();
	}
	cout<<endl;
}
void phonebook::del(const int& id){
	if(size>1){
		phonenumber *tmp=new phonenumber[size-1];
		for(int i=id-1; i<size-1; i++)
			records[i]=records[i+1];
		for(int i=0; i<size-1; i++)
			tmp[i]=records[i];
		delete[]records;
		records=NULL;
		records=tmp;
		size--;
	}
	else if(size==1){
		delete[]records;
		size--;
	}
	else cout<<"Phonebook is empty\n";
}
void phonebook::search(const char* text){
	for(int i=0; i<size; i++){
		if(records[i].search(text)){
			cout<<i+1<<". ";
			records[i].show();
		}
	}
}
phonebook::~phonebook(){
	if(records) delete[]records;
}