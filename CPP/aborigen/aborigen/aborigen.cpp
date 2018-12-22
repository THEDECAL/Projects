#include "aborigen.h"

aborigen::aborigen(){
	pAborigen=NULL;
	prevDir=_getcwd(NULL,NULL);
	HistoryFile="./history.txt";
}
aborigen::~aborigen(){
	delete pAborigen;
}
aborigen *aborigen::getAborigen(){
	return pAborigen;
}
bool aborigen::yesno(){
	char answer;
	while(true){
		cout<<"\tPress: y\\Y - yes, n\\N - no\n";
		answer=_getch();
		if(answer=='y'||answer=='Y') return 1;
		if(answer=='n'||answer=='N') return 0;
	}
}
void aborigen::choice(const string* arguments){
	string line=arguments[0];

	if(line=="");
	else if(line=="help"||line=="?") printf(messages[HELP_MESS]);
	else if(line=="clear") clrScreen();
	else if(line=="dir") (arguments[1].size())?dir(arguments[1].c_str()):dir();
	else if(line=="cd"){
		if(arguments[1].size()) cd(arguments[1].c_str());
		else printf(messages[ARGS_ERR]);
	}
	else if(line=="mv"){
		if(arguments[1].size()&&arguments[2].size()) move(arguments[1].c_str(),arguments[2].c_str());
		else printf(messages[ARGS_ERR]);
	}
	else if(line=="mkdir"){
		if(arguments[1].size()) mkFolder(arguments[1].c_str());
		else printf(messages[ARGS_ERR]);
	}
	else if(line=="rm"){
		if(arguments[1].size()) del(arguments[1].c_str());
		else printf(messages[ARGS_ERR]);
	}
	else if(line=="cp"){
		if(arguments[1].size()&&arguments[2].size()) copy(arguments[1].c_str(),arguments[2].c_str());
		else printf(messages[ARGS_ERR]);
	}
	else if(line=="open"){
		if(arguments[1].size()) opFile(arguments[1].c_str());
		else printf(messages[ARGS_ERR]);
	}
	else if(line=="mk"){
		if(arguments[1].size()) mkFile(arguments[1].c_str());
		else printf(messages[ARGS_ERR]);
	}
	else printf(messages[SLCT_ERR]);
}
void aborigen::inputFilter(const char* line){
	char* copy  = new char[strlen(line) + 1];
	strcpy(copy,line);
	#define CNT_ARG 5
	string arguments[CNT_ARG];
	unsigned amountArg=0;
	unsigned returnCode=0;

	//Проверяем наличие кавычек и подсчитываем их.
	unsigned amountQuotes=0;
	for(size_t i=0; line[i]!=NULL; i++)
		if(line[i]=='\"') amountQuotes++;

	if(amountQuotes % 2){
		printf(messages[QUOTES_ERR]);
		delete copy;
		return;
	}

	//Делим введёную строку на лексемы
	string delimiters=" ";
	//char* ptrArg=strtok(line,delimiters.c_str());
	char* ptrArg = strtok(copy,delimiters.c_str());
	unsigned indexQuotes=NULL;

	delimiters=(amountQuotes)?"\"":" ";
	while(ptrArg){
		if(strcmp(ptrArg," ")==0); //Пустые елементы пропускать
		else arguments[amountArg++]=delSpaces(ptrArg); //Удаление пробелов с начали и конца
		ptrArg=strtok(NULL,delimiters.c_str());
		if(amountArg==CNT_ARG) break;
	}
	delete copy;
	//for(auto i : arguments) std::cout<<i;

	//Выбераем функцию
	choice(arguments);
}
void aborigen::dir(const char* path){
	_finddata_t* data_found=new _finddata_t;
	string mask=(path)?path:_getcwd(NULL,NULL);
	mask+="\\*";
	long num_find=_findfirst(mask.c_str(),data_found);

	if(num_find!=-1){
		while(_findnext(num_find,data_found)==0)
			cout<<data_found->name<<'\n';

		_findclose(num_find);
		delete data_found;
	}
	else printf(messages[READ_ERR]);
}
void aborigen::clrScreen(){
	system("cls");
}
void aborigen::cd(const char* path){
	string currentFolder=_getcwd(NULL,NULL);
	if(strcmp(path,"-")==0){
		_chdir(prevDir.c_str());
		prevDir=currentFolder;
	}
	else{
		if(!_chdir(path)) prevDir=currentFolder;
		else printf(messages[READ_ERR]);
	}
}
void aborigen::mkFolder(const char* path){
	_finddata_t* data_found=new _finddata_t;
	long num_find=_findfirst(path,data_found);

	//Проверка на существование такого же имени.
	bool isAllowReplace=true;
	if(num_find!=-1){
		printf(messages[DIR_REPLACE_MESS],path);
		isAllowReplace=yesno();
		if(isAllowReplace) del(path);
	}

	if(isAllowReplace)
		if(_mkdir(path)==-1) printf(messages[MAKE_DIR_ERR],path);

	_findclose(num_find);
	delete data_found;
}
void aborigen::del(const char* path){
	_finddata_t* data_found=new _finddata_t;
	string mask=path;
	mask+="\\*";
	long num_find=_findfirst(mask.c_str(),data_found);

	//Определяем файл это или папка
	if(num_find!=-1){ //Если это папка и в ней есть файлы удалить их рекурсивно
		while(_findnext(num_find,data_found)==0){
			if(strcmp(data_found->name,"..")==0) continue;
			string newPath=path;
			newPath+="\\";
			newPath+=data_found->name;
			del(newPath.c_str());
		}
		if(_rmdir(path)!=-1);
		else printf(messages[DEL_DIR_ERR],path);
	}
	else{ //Если это не папка или такой папки нет
		if(remove(path)==0);
		else printf(messages[READ_ERR]);
	}

	_findclose(num_find);
	delete data_found;
}
void aborigen::copy(const char* srcPath,const char* dstPath){
	_finddata_t* data_found=new _finddata_t;
	string mask=srcPath;
	mask+="\\*";
	long num_find=_findfirst(mask.c_str(),data_found);

	//Корректировка пути
	string dst_path;
	if(dstPath[strlen(dstPath)-1]=='\\'){
		dst_path=dstPath;
		dst_path+=filename(srcPath);
	}
	else dst_path=dstPath;

	//Определяем файл это или папка
	if(num_find!=-1){ //Если это папка копировать рекурсивно
		mkFolder(dst_path.c_str());
		while(_findnext(num_find,data_found)==0) {
			if(strcmp(data_found->name,"..")==0) continue;
			string newSrcPath=srcPath;
			newSrcPath+="\\";
			newSrcPath+=data_found->name;
			string newDstPath=dst_path;
			newDstPath+="\\";
			newDstPath+=data_found->name;
			copy(newSrcPath.c_str(),newDstPath.c_str());
		}
	}
	else{ //Если это не папка или такой папки нет
		FILE *src,*dst;
		if(src=fopen(srcPath,"rb")){
			//Проверка на существование файла
			bool isAllowReplace=true;
			if(dst=fopen(dst_path.c_str(),"rb")){
				cout<<"\tERROR. A file \""<<dst_path<<"\",\n\twith this name already exists.\n\tReplace?\n";
				isAllowReplace=yesno();
				fclose(dst);
			}
			if(isAllowReplace){//Если можно заменять, заменить.
				if(dst=fopen(dstPath,"wb")){
					const size_t size=65536;
					const long long fileSize=_filelength(_fileno(src));
					char buffer[size];
					long long progress=0;
					while(!feof(src)){
						size_t currentSize=fread(buffer,sizeof(char),size,src);
						fwrite(buffer,sizeof(char),currentSize,dst);
						//Прогресс в процентах
						progress+=currentSize;
						cout<<"Copied: "<<progress/(fileSize/100)<<"%\r";
						//Прогресс в в килобайтах
						//progress += currentSize / 1024;
						//cout << "Copied: " << fileSize / 1024 << '\\' << progress << " Kb\r";
					}
					cout<<endl;
					fclose(dst);
				}
				else cout<<"\tERROR. Wrong destination path \""<<dst_path<<"\"\n\tor not enough rights to the operation.\n";
			}
			fclose(src);
		}
		else cout<<"\tERROR. Wrong source path \""<<srcPath<<"\"\n\tor not enough rights to the operation.\n";
	}

	_findclose(num_find);
	delete data_found;
}
void aborigen::move(const char* srcPath,const char* dstPath){
	_finddata_t* data_found=new _finddata_t;
	string mask;

	//Корректировка пути
	if(dstPath[strlen(dstPath)-1]=='\\'){
		mask=dstPath;
		mask+=filename(srcPath);
	}
	else mask=dstPath;

	long num_find=_findfirst(mask.c_str(),data_found);

	//Проверка на существование такого же имени.
	bool isAllowReplace=true;
	if(num_find!=-1){
		printf(messages[REPLACE_MESS],mask);
		isAllowReplace=yesno();
		if(isAllowReplace) del(mask.c_str());
	}

	//Если можно заменить, заменять.
	if(isAllowReplace)
		if(rename(srcPath,mask.c_str())) printf(messages[READ_ERR]);

	_findclose(num_find);
	delete data_found;
}
void aborigen::opFile(const char* path){
	FILE *fileDesc=fopen(path,"r");
	if(fileDesc){
		const size_t size=81;
		char buffer[size];
		while(!feof(fileDesc)){
			fgets(buffer,size,fileDesc);
			cout<<buffer<<endl;
		}
		fclose(fileDesc);
	}
	else printf(messages[READ_ERR]);
}
void aborigen::mkFile(const char* path){
	_finddata_t* data_found=new _finddata_t;
	long num_find=_findfirst(path,data_found);

	bool isAllowReplace=true;
	if(num_find!=-1){
		printf(messages[REPLACE_MESS],path);
		isAllowReplace=yesno();
		if(isAllowReplace) del(path);
	}

	if(isAllowReplace){
		FILE *fileDesc=fopen(path,"w");
		if(!fileDesc) printf(messages[MAKE_FILE_ERR],path);
		else fclose(fileDesc);
	}

	_findclose(num_find);
	delete data_found;
}
string aborigen::filename(const char* path){
	//Извлекаем имя файла (Всё, что за последним слэшом. Если нет слэша ни чиво не меняем).
	#define SIZE_LINE 260
	char temp[SIZE_LINE]{};
	strcpy(temp,path);
	delLastSlash(temp);
	char* ptrToSlash=strrchr(temp,'\\');

	return (ptrToSlash)?ptrToSlash+1:path;
}
void aborigen::delLastSlash(char* path){
	unsigned lastSymbolIndex=strlen(path)-1;
	if(path[lastSymbolIndex]=='\\')
		path[lastSymbolIndex]='\0';
}
char* aborigen::delSpaces(char* line){
	//Удаляем пробелы с начала
	for(size_t i=0; line[i]; i++){
		if(line[0]==' '){
			for(size_t j=0; line[j]; j++)
				line[j]=line[j+1];
		}
		else break;
	}

	//Удаляем пробелы с конца
	for(size_t i=strlen(line)-1; i>=0; i--){
		if(line[i]==' ') line[i]='\0';
		else break;
	}

	return line;
}
string aborigen::SpcToUnln(string &text,const unsigned &size){
	for(size_t i=0; i < size; i++)
		if(text[i]==' ') text[i]='_';
	return text;
}
void aborigen::inputHistory(const char* line){
	ofstream addToHis(HistoryFile.c_str(),ios::out|ios::app);
	const time_t seconds=time(NULL);
	string _time=ctime(&seconds);
	_time = SpcToUnln(_time,_time.size());
	_time[_time.size() - 1] = ' ';
	string text = _time;
	text += "\"";
	text += line;
	text += "\"\n";
	addToHis<<text;

	if(addToHis) addToHis.close();
}
//char* aborigen::DynamicStr(){
//	long long size = 1;
//	char* text=(char*)calloc(size,sizeof(char));
//	while(true){
//		char ch;
//		cin.get(ch);
//		if(ch == '\n') return text; //Если введена клавиша ENTER вернуть строку
//		text=(char*)realloc(text,++size*sizeof(char)); //Перевыделение памяти
//		text[size-1]='\0'; //Последний символ, конец строки
//		text[size-2]=ch; //Предпоследний символ, введённый символ
//	}
//}
string aborigen::DynamicStr(){
	long long size = 1;
	string text;
	while(true){
		char ch;
		cin.get(ch);
		if(ch == '\n') return text; //Если введена клавиша ENTER вернуть строку
		text += ch;
	}
}