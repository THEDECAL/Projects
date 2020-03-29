#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>
#include <string>
#include <string.h>
#include <vector>
#include <algorithm>
#include <iomanip>
#include <conio.h>
using namespace std;

namespace ctlg{
	const size_t textSize = 16;
	enum{ NAME,OWNER,ADDRESS,OCCUPATION,TEL_NUM,SIZE };

	class people{
		char name[textSize] = {0};
		char owner[textSize] = {0};
		char address[textSize] = {0};
		char occupation[textSize] = {0};
		char tel_num[textSize] = {0};
		char* pointers[SIZE] = { name,owner,address,occupation,tel_num };
	public:
		people(){}
		people(const char* nam,const char* own,const char* add,const char* occ,const char* tel){
			strncpy(name,nam,textSize - 1);
			strncpy(owner,own,textSize - 1),
			strncpy(address,add,textSize - 1);
			strncpy(occupation,occ,textSize - 1);
			strncpy(tel_num,tel,textSize - 1);
		}
		const char* get_ptr(const unsigned& index) const{ return (index<SIZE)?pointers[index]:NULL; }
		friend ostream& operator << (ostream& stream,const people& obj){
			cout<< setw(textSize) << obj.name
				<< setw(textSize) << obj.owner
				<< setw(textSize) << obj.address
				<< setw(textSize) << obj.occupation
				<< setw(textSize) << obj.tel_num;

			return stream;
		}
	};

	class catalogSingleton{
		static catalogSingleton* ptr;
		vector<people>* catalog;
		string fileName;
		ofstream _write;
		ifstream _read;
		catalogSingleton(){
			ptr = NULL;
			catalog = new vector<people>;
			fileName = "catalog.dat";
			_write.open(fileName,ios::out | ios::app | ios::binary);
			_read.open(fileName,ios::in | ios::binary);
			import();
		}
	public:
		static catalogSingleton* get_catalog(){
			return ptr;
		}
		void show(){
			if(catalog->size()){
				cout << setw(textSize) << "Name"
					<< setw(textSize) << "Owner"
					<< setw(textSize) << "Address"
					<< setw(textSize) << "Occupation"
					<< setw(textSize) << "Telephone\n\n";

				for(auto it = catalog->begin(); it != catalog->end(); it++){
					cout << *it;
				}
			}
			else throw "Catalog is empty";
		}
		void search(const unsigned& type,const string& text){
			if(catalog->size()){
				for(auto it = catalog->begin(); it != catalog->end(); it++){
					if(strcmp(it->get_ptr(type),text.c_str()) == 0){
						cout << *it << endl;
					}
				}
			}
			else throw "Catalog is empty";
		}
		void add_entry(const char* name,const char* owner,const char* address,const char* occupation,const char* tel_num){
			people temp(name,owner,address,occupation,tel_num);
			catalog->push_back(temp);
			if(_write) _write.write((char*)&temp,sizeof(temp));
			else throw "Write";
		}
		void import(){
			if(_read){
				while(!_read.eof()){
					people temp;
					_read.read((char*)&temp,sizeof(temp));
					catalog->push_back(temp);
				}
			}
			else throw "Read";
		}
		~catalogSingleton(){
			_write.close();
			_read.close();
			delete catalog;
		}
	};

	catalogSingleton* catalogSingleton::ptr = new catalogSingleton;
	catalogSingleton* const ref = catalogSingleton::get_catalog();
	catalogSingleton& const catalog = *ref;
}

void main(){
	try{
		using namespace ctlg;
		//catalog.show();
		catalog.search(OCCUPATION,"ISP");

		/*
		char select = -1;
		do{
			cout<< "1. Show catalog\n"
				<< "2. Add entry\n"
				<< "3. Search"
				<< "0. Exit\n";
			select = _getch();

			switch(select){
				case '1':{ catalog.show(); break; }
				case '2':{
					string name,owner,address,occupation,tel_num;
					cout << "Please enter a name organization, owner, address, occupation and telephone number (" << textSize << " max length):\n";
					cin >> name >> owner >> address >> occupation >> tel_num;
					catalog.add_entry(name.c_str(),owner.c_str(),address.c_str(),occupation.c_str(),tel_num.c_str());
					break;
				}
				case '3':{
					do{
						cout<< "0. by name\n"
							<< "1. by owner\n"
							<< "2. by address\n"
							<< "3. by occupation\n"
							<< "4. Back\n";
						select = _getch();

						string text;
						cout << "Please enter text for search: ";
						cin >> text;
						catalog.search(select,text);
						break;
					} while(select!='4');
					break;
				}
			}
		}while(select!='0');
		*/

		system("pause");
	}
	catch(const char* text) { cout << "\tError. " << text << ".\n"; }
	catch(...) { cout << "\tUnexpected Error.\n"; }
}
