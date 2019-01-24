#include "catalog.h"
#include <conio.h>
#include <windows.h>
#define MENU_SIZE 6
#define MENU_SEARCH_SIZE 4
#define MAX_STRING_SIZE 261

void main(){
	catalog _catalog;
	_catalog.selectFile("db.txt");
	//cout<<_catalog.add("ISP BigNET","Zvegintsev N.Y.","+38-099-299-37-34","Karla-Marksa 101","ISP")<<endl;
	//cout << _catalog.add("ATB","Doodlja Z.A.","+38-050-299-33-43","Karla-Marksa 115","Market") << endl;
	//_catalog.show();
	//_catalog.show("ATB");

	string menu[MENU_SIZE] = {
		"1. Select a catalog file\n",
		"2. Show a catalog file\n",
		"3. Show entries\n",
		"4. Add entry\n",
		"5. Search entries\n",
		"0. Exit\n"
	};
	string error[] = {
		"\tERROR. Wrong choice.\n",
		"\tERROR. Wrong path or not enough rights to the operation.\n",
		"\tERROR. Catalog file is empty or not selected.\n",
		"\tERROR. Catalog file not selected or not enough rights to the operation.\n"
	};

	do{
		Sleep(1500);
		system("cls");

		for(size_t i = 0; i < MENU_SIZE; i++)
			cout << menu[i];

		char select=_getch();

		switch(select){
			case '0': return;
			case '1':{
				char path[MAX_STRING_SIZE];
				cout << "Please enter the path to the file: "; gets_s(path);
				if(_catalog.selectFile(path)) cout << error[1];
				break;
			}
			case '2': cout << "Catalog filename: " << _catalog.showFileName(); break;
			case '3': if(_catalog.show()) cout << error[2]; break;
			case '4':{
				char name[MAX_STRING_SIZE];
				char owner[MAX_STRING_SIZE];
				char telNum[MAX_STRING_SIZE];
				char address[MAX_STRING_SIZE];
				char occupation[MAX_STRING_SIZE];

				cout << "Please enter company name: "; gets_s(name);
				cout << "Please enter company owner: "; gets_s(owner);
				cout << "Please enter company telephone number: "; gets_s(telNum);
				cout << "Please enter company address: "; gets_s(address);
				cout << "Please enter company occupation: "; gets_s(occupation);

				if(_catalog.add(name,owner,telNum,address,occupation)) cout << error[3];

				break;
			}
			case '5':{
				char search[MAX_STRING_SIZE];
				cout << "Please enter string to search: "; gets_s(search);

				if(_catalog.show(search)) cout << error[2];

				break;
			}
			default: cout << error[0];
		}
	}while(true);

	system("pause");
}
