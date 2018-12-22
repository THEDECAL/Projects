#include "commander.h"
#define CNT_ARG 5

commander::commander(){
	ptr=NULL;
}
commander* commander::getRef(){
	return ptr;
}
bool commander::input(char* commands) const{
	string arguments[CNT_ARG];
	unsigned cntArg=0;
	
	if(strstr(commands," \"")){ //Проверка есть ли кавычки в комманде (для файлов с пробелами)
		//Подсчёт кол-ва ковычек
		unsigned cntQuotes=0;
		for(int i=0; commands[i]!=NULL; i++)
			if(commands[i]=='\"') cntQuotes++;

		if(cntQuotes==2||cntQuotes==4){
			for(int i=0; commands[i]!=' ';i++)
				arguments[0]+=commands[i];

			cntArg++;

			char* ptrToQuote=strchr(commands,'\"');
			for(int i=0; i<cntQuotes/2; i++){
				for(int j=(ptrToQuote-commands+1); commands[j]!='\"'; j++)
					arguments[i+1]+=commands[j];
				ptrToQuote=strchr(ptrToQuote+1,'\"');
				ptrToQuote=strchr(ptrToQuote+1,'\"');
				cntArg++;
			}
		}
		else{
			cout<<"\tERROR. Wrong number of quotes.\n";
			return 1;
		}
	}
	else{ //Если кавычек нет, делим комманду на лексемы	
		char* ptrArg=strtok(commands," ");
		while(ptrArg!=NULL){
			if(cntArg==CNT_ARG) break;
			arguments[cntArg]=ptrArg;
			ptrArg=strtok(NULL," ");
			cntArg++;
		}
	}

	string command=arguments[0];

	if(command=="help"||command=="?") help();
	else if(command=="clear") clearScreen();
	else if(command=="dir") (arguments[1].size())?dir(arguments[1].c_str()):dir();
	else if(command=="cd"){
		if(arguments[1].size())
			cd(arguments[1].c_str());
		else{
			cout<<"\tERROR. Wrong number of arguments\n";
			return 1;
		}
	}
	else if(command=="move"){
		if(arguments[1].size()&&arguments[2].size())
			move(arguments[1].c_str(),arguments[2].c_str());
		else{
			cout<<"\tERROR. Wrong number of arguments\n";
			return 1;
		}
	}
	else if(command=="mkdir"){
		if(arguments[1].size())
			createFolder(arguments[1].c_str());
		else{
			cout<<"\tERROR. Wrong number of arguments\n";
			return 1;
		}
	}
	else{
		cout<<"\tERROR. There is no such command. Enter \"help\" for help.\n";
		return 1;
	}

	return 0;
}
void commander::dir(const char* path){
	_finddata_t* data_found=new _finddata_t;
	string mask=(path)?path:_getcwd(NULL,NULL);
	mask+="\\*";
	long num_find=_findfirst(mask.c_str(),data_found);

	if(num_find!=-1){
		while(_findnext(num_find,data_found)==0)
			cout<<data_found->name<<'\n';
	}
	else cout<<"\tERROR. Wrong path or not enough rights to the operation.\n";

	_findclose(num_find);
	delete data_found;
}
void commander::help() const{
	cout<<"\thelp - Help to this program\n";
	cout<<"\tdir [path] - Show files in directory\n";
	cout<<"\tclear - Screen cleaning\n";
	cout<<"\tcd <path> - Change working directory\n";
	cout<<"\tmkdir <path> - Create folder\n";
	cout<<"\tmove <source path> <destination path> - Move and\\or rename file or directory\n";
}
void commander::clearScreen(){
	system("cls");
}
void commander::cd(const char* path){
	_finddata_t* data_found=new _finddata_t;
	string mask=path;
	long num_find=_findfirst(mask.c_str(),data_found);

	if(num_find!=-1){
		_chdir(path);
	}
	else cout<<"\tERROR. Wrong path or not enough rights to the operation.\n";

	_findclose(num_find);
	delete data_found;
}
void commander::createFolder(const char* path){
	if(_mkdir(path)==-1)
		cout<<"\tERROR. Wrong path or not enough rights to the operation.\n";
}
void commander::move(const char* srcPath,const char* dstPath){
	_finddata_t* data_found=new _finddata_t;
	string mask=fileName(srcPath);
	long num_find=_findfirst(mask.c_str(),data_found);

	//cout<<mask<<endl;

	bool isAllowReplace=false;
	if(num_find!=-1){
		char answer;
		cout<<"\tA file with this name already exists\n\tPress: y - for replace, any key for cancellation.\n";
		answer=_getch();
		if(answer!='y'||answer!='Y') isAllowReplace=false;
	}

	if(isAllowReplace){
		if(!rename(srcPath,dstPath))
			cout<<"\tERROR. Wrong path or not enough rights to the operation.\n";
	}
	_findclose(num_find);
	delete data_found;
}
char* fileName(const char* path){
	char temp[SIZE_LINE]{};
	strcpy(temp,path);
	char* ptrToSlash=strrchr(temp,'\\');

	return (ptrToSlash)?ptrToSlash+1:temp;
}
commander::~commander(){
	if(ptr) delete ptr;
}
