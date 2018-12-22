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
	const unsigned textSize = 16;
	enum{ NAME,OWNER,ADDRESS,OCCUPATION,TEL_NUM,SIZE };

	class people{
		char strings[SIZE][textSize];
	public:
		people(){
			for(size_t i = 0; i < SIZE; i++){
				for(size_t j = 0; j < textSize; j++){
					strings[i][j] = 0;
				}
			}
		}
		people(const char* nam,const char* own,const char* add,const char* occ,const char* tel):people(){
			strncpy(strings[NAME],nam,textSize - 1);
			strncpy(strings[OWNER],own,textSize - 1),
			strncpy(strings[ADDRESS],add,textSize - 1);
			strncpy(strings[OCCUPATION],occ,textSize - 1);
			strncpy(strings[TEL_NUM],tel,textSize - 1);
		}
		const char* get_string(const unsigned& index) const { return (index < SIZE)?strings[index]:NULL; }
		friend ostream& operator << (ostream& stream,const people& obj){
			cout<< setw(textSize) << obj.strings[NAME]
				<< setw(textSize) << obj.strings[OWNER]
				<< setw(textSize) << obj.strings[ADDRESS]
				<< setw(textSize) << obj.strings[OCCUPATION]
				<< setw(textSize) << obj.strings[TEL_NUM];

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
				bool isFind = false;
				for(auto it = catalog->begin(); it != catalog->end(); it++){
					if(strcmp(it->get_string(type),text.c_str()) == 0){
						cout << *it << endl;
						isFind = true;
					}
				}
				if(!isFind) cout << "Not found.\n";
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
		//catalog.add_entry("GiperNET","N. Zvegintsev","Mira 21","ISP","099-299-37-34");
		//catalog.add_entry("TakseNET","Y. Prud","Pobedi 12","ISP","063-249-17-35");
		//catalog.add_entry("ATB","P. Doodlja","TV 17","Trewr","073-111-37-00");
		//catalog.add_entry("Delvi","I. Grusha","Gagarina 112","sdw","063-123-17-99");
		//catalog.show();
		//catalog.search(OCCUPATION,"ISP");
		//system("pause");
		
		char select = -1;
		do{
			system("cls");
			cout<< "1. Show catalog\n"
				<< "2. Add entry\n"
				<< "3. Search\n"
				<< "0. Exit\n";

			switch(select){
				case '1':{ catalog.show(); break; }
				case '2':{
					string name,owner,address,occupation,tel_num;
					cout << "Please enter a name organization, owner, address, occupation and telephone number (" << textSize << " max length):\n";
					getline(cin,name);
					getline(cin,owner);
					getline(cin,address);
					getline(cin,occupation);
					getline(cin,tel_num);
					//cin >> name >> owner >> address >> occupation >> tel_num;
					catalog.add_entry(name.c_str(),owner.c_str(),address.c_str(),occupation.c_str(),tel_num.c_str());

					break;
				}
				case '3':{
					do{
						system("cls");
						cout << "0. by name\n"
							<< "1. by owner\n"
							<< "2. by address\n"
							<< "3. by occupation\n"
							<< "4. Back\n";

						select = _getch();

						if(select >= '0' && select <= '3'){
							string text;
							cout << "Please enter text for search: ";
							cin >> text;
							catalog.search(select-48,text);
							system("pause");
						}
					}while(select!='4');

					continue;
				}
			}

			select = _getch();
		}while(select!='0');
	}
	catch(const char* text) { cout << "\tError. " << text << ".\n"; }
	catch(...) { cout << "\tUnexpected Error.\n"; }
}
