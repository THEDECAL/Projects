#include <iostream>
#include <string>
 #include "conio.h"
#include "tree.h"
using namespace std;

void enterAnyKey() {
	char temp;
	cout<<"Please enter any key to continue...\n";
	temp=_getch();
}
bool enterYN() {
	char temp;
	cout<<"Please enter \"Y\" - if yes or \"N\" - if no.\n";
	temp=_getch();
	if(temp=='Y'||temp=='y') return 1;
	if(temp=='N'||temp=='n') return 0;
}

int main() {
	tree* db=new tree;

	 db->add("AI1516","Intersection of a double solid line.");
	 db->add("AE3450","Intersection of a double solid line.");
	 db->add("AE1859","Intersection of a double solid line.");
	 db->add("AE1859","Intersection of a double solid line.");
	 db->add("AE1859","Driving is not sober.");
	 db->add("AE3450","Driving is not sober.");
	 db->add("AE1959","Driving is not sober.");
	 db->add("AE3550","Driving is not sober.");
	 db->add("BH7100","Driving is not sober.");
	 db->add("BH7100","Intersection of a double solid line.");
	 db->add("BX1515","Intersection of a double solid line.");
	//db->import("db.txt")<<'\n';

	char select=-1;
	do {
		system("cls");

		std::cout<<"1. Add entry\n";
		std::cout<<"----------\n";
		std::cout<<"2. Show database\n";
		std::cout<<"3. Search entry by key\n";
		std::cout<<"4. Search entry by range\n";
		//std::cout<<"5. Import database\n";
		std::cout<<"6. Save database\n";
		std::cout<<"0. Exit\n";

		select=_getch();

		switch(select) {
			case '1': {
				string key;
				string violation;

				cout<<"Please enter a key: ";
				cin>>key;

				cout<<"Please enter a violation: ";
				cin>>violation;

				if(db->add(key,violation)==0) {
					cout<<"Entry successfully added.\n";
				}
				else
					cout<<"Error. Key: \""<<key<<"\" has a maximum of violations.\n";

				enterAnyKey();

				break;
			}
			case '2': {
				if(db->getRoot()==0)
					std::cout<<"Database is empty.\n";
				else
					db->show(db->getRoot());

				enterAnyKey();

				break;
			}
			case '3': {
				string key;

				cout<<"Please enter a key to search: ";
				cin>>key;

				node* _node=db->search(db->getRoot(),key);

				if(_node) {
					cout<<_node->key<<'\n';

					for(int i=0; i<_node->cntViolations; i++)
						cout<<'\t'<<i+1<<". "<<_node->violations[i]<<'\n';
				}
				else
					cout<<"Error. Key not found.\n";

				enterAnyKey();

				break;
			}
			case '4': {
				string start_key;
				string end_key;

				cout<<"Please enter a start range key to search: ";
				cin>>start_key;

				cout<<"Please enter an end range key to search: ";
				cin>>end_key;

				db->search(db->getRoot(),start_key,end_key);

				enterAnyKey();

				break;
			}
			//case '5': {
			//	char fileName[FILE_NAME_SIZE];

			//	std::cout<<"Please enter file name: ";
			//	std::cin>>fileName;

			//	if(db->import(fileName)==0)
			//		std::cout<<"Import successfully complete.\n";
			//	else
			//		std::cout<<"Error. Cannot open directory file or file not read.\nAdvice. Change import file.\n";

			//	enterAnyKey();

			//	break;
			//}
			case '6': {
				char fileName[FILE_NAME_SIZE];

				std::cout<<"Please enter file name: ";
				std::cin>>fileName;

				if(db->save(fileName)==0)
					std::cout<<"Save successfully complete.\n";
				else
					std::cout<<"Error. Cannot open directory file or file not read.\nAdvice. Change save file.\n";

				enterAnyKey();

				break;
			}
		}
	} while(select!='0');

	delete db;

	return 0;
}
