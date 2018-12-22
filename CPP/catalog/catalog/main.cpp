#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <conio.h>
#include <string.h>
#include "catalog.h"

void enterAnyKey() {
	char temp;
	std::cout<<"Please enter any key to continue...\n";
	temp=_getch();
}
bool enterYN() {
	char temp;
	std::cout<<"Please enter \"Y\" - if yes or \"N\" - if no.\n";
	temp=_getch();
	if(temp=='Y'||temp=='y') return 1;
	if(temp=='N'||temp=='n') return 0;
}

int main() {
	catalog* db=new catalog;

	db->import("db.txt");
	db->sort();

	char select=-1;
	do {
		system("clear");

		std::cout<<"1. Command line\n";
		std::cout<<"----------\n";
		std::cout<<"2. Add new entry\n";
		std::cout<<"3. Edit entry\n";
		std::cout<<"4. Remove entry\n";
		std::cout<<"5. Search entries\n";
		std::cout<<"----------\n";
		std::cout<<"6. Show database\n";
		std::cout<<"7. Import database\n";
		std::cout<<"8. Save database\n";
		std::cout<<"----------\n";
		std::cout<<"0. Exit\n";

		select=_getch();

		switch(select) {
			case '1': {
				char temp[256]{};

				while(strcmp(temp,"exit")) {
					std::cout<<"> ";
					std::cin.clear();
					gets_s(temp);
					system(temp);
				}

				break;
			}
			case '2': {
				char name[NAME_SIZE];

				std::cout<<"Please enter a name: ";
				std::cin>>name;

				long long tel_num;

				std::cout<<"Please enter a telephone number (only numbers): ";
				std::cin>>tel_num;

				if(db->add(name,tel_num)==0) {
					db->sort();
					std::cout<<"Entry added.\n";
				}
				else
					std::cout<<"Error. Name or telephone number is already in the catalog.\n";

				enterAnyKey();

				break;
			}
			case '3': {
				do {
					system("clear");

					std::cout<<"1. Edit by name\n";
					std::cout<<"2. Edit by telehone number\n";
					std::cout<<"0. Back\n";

					select=_getch();

					switch(select) {
						case '1': {
							char name[NAME_SIZE];

							std::cout<<"Please enter name to edit: ";
							std::cin>>name;

							if(db->search(name)!=-1) {
								char tmp[NAME_SIZE];
								std::cout<<"Please enter new name: ";
								std::cin>>tmp;
								db->edit(db->search(name),tmp);
								std::cout<<"Edit successfully complete.\n";
							}
							else {
								std::cout<<"Error. Entered name not found.\n";
							}

							enterAnyKey();

							break;
						}
						case '2': {
							long long tel_num;

							std::cout<<"Please enter telehone number to edit: ";
							std::cin>>tel_num;

							if(db->search(tel_num)!=-1) {
								long long tmp;
								std::cout<<"Please enter new telehone number: ";
								std::cin>>tmp;
								db->edit(db->search(tel_num),tmp);
								std::cout<<"Edit successfully complete.\n";
							}
							else {
								std::cout<<"Error. Entered telephone number not found.\n";
							}

							enterAnyKey();

							break;
						}
					}
				} while(select!='0');

				select=-1;

				break;
			}
			case '4': {
				char name[NAME_SIZE];

				std::cout<<"Please enter a name: ";
				std::cin>>name;

				if(db->search(name)!=-1) {
					db->del(db->search(name));
					std::cout<<"Remove successfully complete.\n";
				}
				else
					std::cout<<"Error. Name not found.\n";

				enterAnyKey();

				break;
			}
			case '5': {
				catalog* search_db=new catalog; //For data found

				do {

					system("clear");

					std::cout<<"1. Search by range\n";
					std::cout<<"2. Search by name\n";
					std::cout<<"3. Search by telehone number\n";
					std::cout<<"4. Export found in file\n";
					std::cout<<"0. Back\n";

					select=_getch();

					switch(select) {
						case '1': {
							do {
								system("clear");

								std::cout<<"1. Search by name\n";
								std::cout<<"2. Search by telehone number\n";
								std::cout<<"0. Back\n";

								select=_getch();

								switch(select) {
									case '1': {
										char start_name[NAME_SIZE];
										char end_name[NAME_SIZE];

										std::cout<<"Please enter name start of range: ";
										std::cin>>start_name;
										std::cout<<"Please enter name end of range: ";
										std::cin>>end_name;

										if(db->search(start_name,end_name,search_db)) {}
										else
											std::cout<<"Error. Names not found.\n";

										enterAnyKey();

										break;
									}
									case '2': {
										long long start_tel_num;
										long long end_tel_num;

										std::cout<<"Please enter telehone number start of range: ";
										std::cin>>start_tel_num;
										std::cout<<"Please enter telehone number end of range: ";
										std::cin>>end_tel_num;

										if(db->search(start_tel_num,end_tel_num,search_db)) {}
										else
											std::cout<<"Error. Telephone numbers not found.\n";

										enterAnyKey();

										break;
									}
								}
							} while(select!='0');

							select=-1;

							break;
						}
						case '2': {
							char name[NAME_SIZE];

							std::cout<<"Please enter name to search: ";
							std::cin>>name;

							if(db->search(name)!=-1)
								db->show(db->search(name,search_db));
							else
								std::cout<<"Error. Name not found.\n";

							enterAnyKey();

							break;
						}
						case '3': {
							long long tel_num;

							std::cout<<"Please enter telehone number to search: ";
							std::cin>>tel_num;

							if(db->search(tel_num)!=-1)
								db->show(db->search(tel_num,search_db));
							else
								std::cout<<"Error. Telephone number not found.\n";

							enterAnyKey();

							break;
						}
						case '4': {
							char fileName[NAME_SIZE];

							std::cout<<"Please enter file name to export: ";
							std::cin>>fileName;

							if(search_db->save(fileName)==false)
								std::cout<<"Save successfully complete.\n";
							else
								std::cout<<"Error. Cannot open directory file or file not read.\nAdvice. Change the database file.\n";

							enterAnyKey();

							break;
						}
					}
				} while(select!='0');

				delete search_db;

				select=-1;

				break;
			}
			case '6': {
				if(db->show()==1)
					std::cout<<"Database is empty.\n";

				enterAnyKey();

				break;
			}
			case '7': {
				char fileName[FILE_NAME_SIZE];

				std::cout<<"Use default file name to import (\""<<DEFAULT_FILE_NAME<<"\")?\n";
				if(enterYN()==0) {
					std::cout<<"Please enter file name: ";
					std::cin>>fileName;
				}
				else strcpy(fileName,DEFAULT_FILE_NAME);

				if(db->import(fileName)==0) {
					db->sort();
					std::cout<<"Import successfully complete.\n";
				}
				else
					std::cout<<"Error. Cannot open directory file or file not read.\nAdvice. Change import file.\n";

				enterAnyKey();

				break;
			}
			case '8': {
				char fileName[FILE_NAME_SIZE];

				std::cout<<"Use default file name to save (\""<<DEFAULT_FILE_NAME<<"\")?\n";
				if(enterYN()==0) {
					std::cout<<"Please enter file name: ";
					std::cin>>fileName;
				}
				else strcpy(fileName,DEFAULT_FILE_NAME);

				if(db->save(fileName)==false)
					std::cout<<"Save successfully complete.\n";
				else
					std::cout<<"Error. Cannot open directory file or file not read.\nAdvice. Change the database file.\n";

				enterAnyKey();

				break;
			}
		}
	} while(select!='0');

	delete db;

	return 0;
}
