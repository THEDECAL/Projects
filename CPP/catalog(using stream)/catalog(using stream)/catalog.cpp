#include "catalog.h"

string catalog::showFileName(){
	return (catalogFileName.empty())?"\tERROR. File not selected.\n":catalogFileName;
}
bool catalog::selectFile(const string& path){
	fstream fileInput(path,ios::in|ios::binary);
	if(fileInput){
		this->catalogFileName = path;

		fileInput.close();
		return 0;
	}

	return 1;
}
bool catalog::add(const string& name,const string& owner,const string& telNum,const string& address,const string& occupation){
	ofstream fileOutput(catalogFileName,ios::out|ios::app);
	if(fileOutput){
		fileOutput << '\"' << name <<'\"';
		fileOutput << '\"' << owner << '\"';
		fileOutput << '\"' << telNum << '\"';
		fileOutput << '\"' << address << '\"';
		fileOutput << '\"' << occupation << '\"';
		fileOutput << endl;

		fileOutput.close();
		return 0;
	}

	return 1;
}
bool catalog::show(const char* search){
	ifstream fileInput(catalogFileName,ios::in);
	if(fileInput){
		char buffer[BUFFER_SIZE];

		cout << "Name    Owner    Telephone Number    Address    Occupation\n";
		while(fileInput.getline(buffer,BUFFER_SIZE,'\n')){ //—читываем построчно
			if(search && !strstr(buffer,search)) continue;
			char delimiters[] = "\"";
			char* ptr = strtok(buffer,delimiters);
			cout << "| ";
			while(ptr){ //ƒелим на лексемы
				cout << ptr << " | ";
				ptr = strtok(NULL,delimiters);
			}
			cout << endl;
		}

		fileInput.close();
		return 0;
	}
	return 1;
}
