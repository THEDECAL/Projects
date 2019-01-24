#define _CRT_SECURE_NO_WARNINGS
#define STRING_SIZE 260
#include <iostream>
#include <string>
#include <string.h>
#include <direct.h>
#include <io.h>
#include <conio.h>
using namespace std;

//char* check_path(char* srcPath,const char* dstPath){
//	char dstFileName[STRING_SIZE]{};
//
//	if(strstr(dstPath,"\\")) { //Если во входящем пути абсолютный путь
//		if(dstPath[strlen(dstPath)-1]=='\\') { //Если во входящем пути последний символ '\', то имя файла берём из исходящего пути
//			strcpy(dstFileName,dstPath);
//			char* pSlash=strrchr(srcPath,'\\'); //Ищим последний слэш в исходящем файле и всё, что после него используем, как имя файла
//			if(pSlash) {
//				strcat(dstFileName,pSlash);
//			}
//			else {
//				strcat(dstFileName,srcPath);
//			}
//		}
//		else
//			strcpy(dstFileName,dstPath);
//	}
//	else { //Если во входящем пути относительный путь
//		strcpy(dstFileName,_getcwd(NULL,NULL));
//		strcat(dstFileName,"\\");
//		strcat(dstFileName,dstPath);
//	}
//
//	_finddata_t* find_data=new _finddata_t;
//	long num_find=_findfirst(dstFileName,find_data);
//
//	char answer='y';
//	if(num_find!=-1) {
//		cout<<"A file with this name already exists\n input: y - for replace, any key for cancellation.\n";
//		answer=_getch();
//	}
//
//	_findclose(num_find);
//	delete find_data;
//}

void main(int cntArguments, char* arguments[]){
	if (cntArguments == 1){
		char line[STRING_SIZE]{};

		while(strcmp(line, "exit")){
			char buffer[STRING_SIZE]="\"";
			cout << _getcwd(NULL,NULL) << ">";
			gets_s(line);

			if (strstr(line,"cd ")){
				if (strcmp(line, "cd .")==0){
					_chdir(_getcwd(NULL, NULL));
				}
				else if (strcmp(line, "cd ..") == 0){
					char prevdir[STRING_SIZE]{};
					_getcwd(prevdir, STRING_SIZE);

					//Забивать нолями до первого слэша с конца
					for (int i = STRING_SIZE - 1; i >= 0; i--){
						if (prevdir[i] == '\\')
							break;
						prevdir[i] = 0;
					}

					_chdir(prevdir);
				}
				else if (line[3] != 0){
					char dir[STRING_SIZE]{};
					for (int i = 3; line[i] != NULL; i++)
						dir[i-3]=line[i];
					_chdir(dir);
				}
			}
			else{
				strcat(buffer, arguments[0]);
				strcat(buffer, "\" ");
				strcat(buffer, line);
				system(buffer);
			}
		}
	}
	else{
		const string command = arguments[1];
		const char errors[][256] = {
			"ERROR. There are not enough arguments.\n",
			"ERROR. Invalid path or right to an operation.\n"
		};

		if (command == "?" || command == "help"){
			cout<<"Help:\n";
			cout<<"move <source path> <destination path> - Move files and folders\n";
			cout<<"cd - Change working directory\n";
			cout<<"mkdir - Create folder\n";
			cout<<"rmdir - Delete folder\n";
		}
		else if (command == "dir"){
			_finddata_t* find_data = new _finddata_t;
			char mask[STRING_SIZE]{};
			_getcwd(mask, STRING_SIZE);
			strcat(mask, "\\*");
			long num_find=_findfirst(mask,find_data);

			if(num_find==-1)
				cout << "Nothing found.\n";
			else{
				while (_findnext(num_find,find_data)==0)
					cout << find_data->name << '\n';
			}
			_findclose(num_find);
			delete find_data;
		}
		else if(command=="mkdir"){
			char folderName[STRING_SIZE]{};
			if(strstr(arguments[2],"\\")){ //Если во входящем пути абсолютный путь
				strcpy(folderName,arguments[2]);
			}
			else{ //Если во входящем пути относительный путь
				strcpy(folderName,_getcwd(NULL,NULL));
				strcat(folderName,"\\");
				strcat(folderName,arguments[2]);
			}

			_finddata_t* find_data=new _finddata_t;
			long num_find=_findfirst(folderName,find_data);

			char answer='y';
			if(num_find!=-1){
				cout<<"A file with this name already exists\n input: y - for replace, any key for cancellation.\n";
				answer=_getch();
			}
			
			if(answer=='y'){
				if(_mkdir(folderName)==-1){
					cout<<errors[1];
				}
				else
					cout<<"Create folder successfully complete.\n";
			}

			_findclose(num_find);
			delete find_data;
		}
		else if(command=="rmdir"){
				if(_rmdir(arguments[2])==-1){
					cout<<errors[1];
				}
				else
					cout<<"Delete folder successfully complete.\n";
		}
		//else if(command=="copy"){
		//	if(cntArguments!=4)
		//		cout<<errors[0];
		//	else{
		//		char dstFileName[STRING_SIZE]{};

		//		if(strstr(arguments[3],"\\")) { //Если во входящем пути абсолютный путь
		//			if(arguments[3][strlen(arguments[3])-1]=='\\') { //Если во входящем пути последний символ '\', то имя файла берём из исходящего пути
		//				strcpy(dstFileName,arguments[3]);
		//				char* pSlash=strrchr(arguments[2],'\\'); //Ищим последний слэш в исходящем файле и всё, что после него используем, как имя файла
		//				if(pSlash) {
		//					strcat(dstFileName,pSlash);
		//				}
		//				else {
		//					strcat(dstFileName,arguments[2]);
		//				}
		//			}
		//			else
		//				strcpy(dstFileName,arguments[3]);
		//		}
		//		else { //Если во входящем пути относительный путь
		//			strcpy(dstFileName,_getcwd(NULL,NULL));
		//			strcat(dstFileName,"\\");
		//			strcat(dstFileName,arguments[3]);
		//		}

		//		_finddata_t* find_data=new _finddata_t;
		//		long num_find=_findfirst(dstFileName,find_data);

		//		char answer='y';
		//		if(num_find!=-1) {
		//			cout<<"A file with this name already exists\n input: y - for replace, any key for cancellation.\n";
		//			answer=_getch();
		//		}

		//		if(answer='y'){
		//			FILE *descSrcFile,*descDstFile;
		//			descSrcFile=fopen(arguments[2],"rb");

		//			descDstFile=fopen(arguments[3],"wb");
		//			if(descSrcFile && descDstFile){

		//			}
		//			else
		//				cout<<errors[1];

		//			fclose(descDstFile);
		//			fclose(descSrcFile);
		//		}
		//	}
		//}
		else if(command=="move"){
			if(cntArguments!=4)
				cout << errors[0];
			else{
				char dstFileName[STRING_SIZE]{};

				if(strstr(arguments[3],"\\")){ //Если во входящем пути абсолютный путь
					if(arguments[3][strlen(arguments[3])-1]=='\\'){ //Если во входящем пути последний символ '\', то имя файла берём из исходящего пути
						strcpy(dstFileName,arguments[3]);
						char* pSlash=strrchr(arguments[2],'\\'); //Ищим последний слэш в исходящем файле и всё, что после него используем, как имя файла
						if(pSlash){
							strcat(dstFileName,pSlash);
						}
						else{
							strcat(dstFileName,arguments[2]);
						}
					}
					else
						strcpy(dstFileName,arguments[3]);
				}
				else{ //Если во входящем пути относительный путь
					strcpy(dstFileName,_getcwd(NULL,NULL));
					strcat(dstFileName,"\\");
					strcat(dstFileName,arguments[3]);
				}

				_finddata_t* find_data=new _finddata_t;
				long num_find=_findfirst(dstFileName,find_data);

				char answer='y';
				if(num_find!=-1){
					cout<<"A file with this name already exists\n input: y - for replace, any key for cancellation.\n";
					answer=_getch();
				}

				if(answer=='y'){
					if(rename(arguments[2],dstFileName))
						cout<<errors[1];
					else
						cout << "Move or rename successfully complete.\n";
				}

				_findclose(num_find);
				delete find_data;
			}
		}
	}
}
