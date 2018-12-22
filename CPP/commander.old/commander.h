#pragma once
#include <iostream>
using namespace std;

class commander{
	//Переменные
	static commander* pCommander;
	const messages *_messages = messages::getRef();
	string prevDir=_getcwd(NULL, NULL);
	string HistoryFile;
	long HisAmLines;
	//Методы
	bool InterAnswerYN();
	unsigned choice(const string*) const;
	void dir(const char* =NULL) const;
	void clrScreen() const;
	void cd(const char*) const;
	void move(const char*,const char*) const;
	void mkFolder(const char*) const;
	void del(const char*) const;
	void copy(const char*,const char*) const;
	void opFile(const char*) const;
	void mkFile(const char*) const;
	string filename(const char*);
	void delLastSlash(char *);
	char* delSpaces(char*) const;
	string SpcToUnln(string&,const unsigned&) const;
	commander();
	public:
	~commander();
	static const commander* getRef();
	unsigned inputFilter(char*) const;
	void inputHistory(const char*) const;
	//void SlctFileHistory(const char*);
	void initFileHistory() const;
	char* DynamicStr() const;
	friend void messages::notify(const unsigned&);
};

commander::commander(){
	pCommander = NULL;
	HistoryFile = "./history.txt";
	HisAmLines = 0;
}
commander::~commander(){
	delete pCommander;
}
const commander* commander::getRef(){
	return pCommander;
}
bool commander::InterAnswerYN(){
	char answer;
	while(true){
		cout << "\tPress: y\\Y - yes, n\\N - no\n";
		answer = _getch();
		if(answer == 'y' || answer == 'Y') return 1;
		if(answer == 'n' || answer == 'N') return 0;
	}
}
unsigned commander::choice(const string* arguments)const {
	string line = arguments[0];

	if(line == "");
	else if(line == "help" || line == "?") return HELP_MESS;
	else if(line == "clear") clrScreen();
	else if(line == "dir") (arguments[1].size())?dir(arguments[1].c_str()):dir();
	else if(line == "cd"){
		if(arguments[1].size()) cd(arguments[1].c_str());
		return ARGS_ERR;
	}
	else if(line == "mv"){
		if(arguments[1].size() && arguments[2].size()) move(arguments[1].c_str(),arguments[2].c_str());
		return ARGS_ERR;
	}
	else if(line == "mkdir"){
		if(arguments[1].size()) mkFolder(arguments[1].c_str());
		return ARGS_ERR;
	}
	else if(line == "rm"){
		if(arguments[1].size()) del(arguments[1].c_str());
		return ARGS_ERR;
	}
	else if(line == "cp"){
		if(arguments[1].size() && arguments[2].size()) copy(arguments[1].c_str(),arguments[2].c_str());
		return ARGS_ERR;
	}
	else if(line == "open"){
		if(arguments[1].size()) opFile(arguments[1].c_str());
		return ARGS_ERR;
	}
	else if(line == "mk"){
		if(arguments[1].size()) mkFile(arguments[1].c_str());
		return ARGS_ERR;
	}
	else return SLCT_ERR;

	return 0;
}
unsigned commander::inputFilter(char* line) const{
#define CNT_ARG 5
	string arguments[CNT_ARG];
	unsigned amountArg = 0;

	//Проверяем наличие кавычек и подсчитываем их.
	unsigned amountQuotes = 0;
	for(size_t i = 0; line[i] != NULL; i++)
		if(line[i] == '\"') amountQuotes++;

	if(amountQuotes % 2)
		return QUOTES_ERR;

	//Делим введёную строку на лексемы
	string delimiters = " ";
	char* ptrArg = strtok(line,delimiters.c_str());
	unsigned indexQuotes = NULL;

	delimiters = (amountQuotes)?"\"":" ";
	while(ptrArg){
		if(strcmp(ptrArg," ") == 0); //Пустые елементы пропускать
		else arguments[amountArg++] = delSpaces(ptrArg); //Удаление пробелов с начали и конца
		ptrArg = strtok(NULL,delimiters.c_str());
		if(amountArg == CNT_ARG) break;
	}
	//for(auto i : arguments) std::cout<<i;

	//Выбераем функцию
	return choice(arguments);
}
void commander::dir(const char* path) const{
	_finddata_t* data_found = new _finddata_t;
	string mask = (path)?path:_getcwd(NULL,NULL);
	mask += "\\*";
	long num_find = _findfirst(mask.c_str(),data_found);

	if(num_find != -1){
		while(_findnext(num_find,data_found) == 0)
			cout << data_found->name << '\n';
	}
	else cout << "\tERROR. Wrong path or not enough rights to the operation.\n";

	_findclose(num_find);
	delete data_found;
}
void commander::clrScreen() const{
	system("cls");
}
void commander::cd(const char* path) const{
	string currentFolder = _getcwd(NULL,NULL);
	if(strcmp(path,"-") == 0){
		_chdir(prevDir.c_str());
		prevDir = currentFolder;
	}
	else{
		if(!_chdir(path)) prevDir = currentFolder;
		else cout << "\tERROR. Wrong path or not enough rights to the operation.\n";
	}
}
void commander::mkFolder(const char* path) const {
	_finddata_t* data_found = new _finddata_t;
	long num_find = _findfirst(path,data_found);

	//Проверка на существование такого же имени.
	bool isAllowReplace = true;
	if(num_find != -1){
		cout << "\tERROR. A folder: \"" << path << "\",\n\twith this name already exists.\n\tReplace?\n";
		isAllowReplace = InterAnswerYN();
		if(isAllowReplace) del(path);
	}

	if(isAllowReplace)
		if(_mkdir(path) == -1) cout << "\tERROR. Can not create folder:" << path << "\n\tWrong path or not enough rights to the operation.\n";

	_findclose(num_find);
	delete data_found;
}
void commander::del(const char* path) const{
	_finddata_t* data_found = new _finddata_t;
	string mask = path;
	mask += "\\*";
	long num_find = _findfirst(mask.c_str(),data_found);

	//Определяем файл это или папка
	if(num_find != -1){ //Если это папка и в ней есть файлы удалить их рекурсивно
		while(_findnext(num_find,data_found) == 0){
			if(strcmp(data_found->name,"..") == 0) continue;
			string newPath = path;
			newPath += "\\";
			newPath += data_found->name;
			del(newPath.c_str());
		}
		if(_rmdir(path) != -1);
		else cout << "\tERROR. Can not delete folder:" << path << "\n\tWrong path or not enough rights to the operation.\n";
	}
	else{ //Если это не папка или такой папки нет
		if(std::del(path) == 0);
		else cout << "\tERROR. Wrong path or not enough rights to the operation.\n";
	}

	_findclose(num_find);
	delete data_found;
}
void commander::copy(const char* srcPath,const char* dstPath) const{
	_finddata_t* data_found = new _finddata_t;
	string mask = srcPath;
	mask += "\\*";
	long num_find = _findfirst(mask.c_str(),data_found);

	//Корректировка пути
	string dst_path;
	if(dstPath[strlen(dstPath) - 1] == '\\'){
		dst_path = dstPath;
		dst_path += filename(srcPath);
	}
	else dst_path = dstPath;

	//Определяем файл это или папка
	if(num_find != -1){ //Если это папка копировать рекурсивно
		mkFolder(dst_path.c_str());
		while(_findnext(num_find,data_found) == 0) {
			if(strcmp(data_found->name,"..") == 0) continue;
			string newSrcPath = srcPath;
			newSrcPath += "\\";
			newSrcPath += data_found->name;
			string newDstPath = dst_path;
			newDstPath += "\\";
			newDstPath += data_found->name;
			copy(newSrcPath.c_str(),newDstPath.c_str());
		}
	}
	else{ //Если это не папка или такой папки нет
		FILE *src,*dst;
		if(src = fopen(srcPath,"rb")){
			//Проверка на существование файла
			bool isAllowReplace = true;
			if(dst = fopen(dst_path.c_str(),"rb")){
				cout << "\tERROR. A file \"" << dst_path << "\",\n\twith this name already exists.\n\tReplace?\n";
				isAllowReplace = InterAnswerYN();
				fclose(dst);
			}
			if(isAllowReplace){//Если можно заменять, заменить.
				if(dst = fopen(dstPath,"wb")){
					const size_t size = 65536;
					const long long fileSize = _filelength(_fileno(src));
					char buffer[size];
					long long progress = 0;
					while(!feof(src)){
						size_t currentSize = fread(buffer,sizeof(char),size,src);
						fwrite(buffer,sizeof(char),currentSize,dst);
						//Прогресс в процентах
						progress += currentSize;
						cout << "Copied: " << progress / (fileSize / 100) << "%\r";
						//Прогресс в в килобайтах
						//progress += currentSize / 1024;
						//cout << "Copied: " << fileSize / 1024 << '\\' << progress << " Kb\r";
					}
					cout << endl;
					fclose(dst);
				}
				else cout << "\tERROR. Wrong destination path \"" << dst_path << "\"\n\tor not enough rights to the operation.\n";
			}
			fclose(src);
		}
		else cout << "\tERROR. Wrong source path \"" << srcPath << "\"\n\tor not enough rights to the operation.\n";
	}

	_findclose(num_find);
	delete data_found;
}
void commander::move(const char* srcPath,const char* dstPath) const{
	_finddata_t* data_found = new _finddata_t;
	string mask;

	//Корректировка пути
	if(dstPath[strlen(dstPath) - 1] == '\\'){
		mask = dstPath;
		mask += filename(srcPath);
	}
	else mask = dstPath;

	long num_find = _findfirst(mask.c_str(),data_found);

	//Проверка на существование такого же имени.
	bool isAllowReplace = true;
	if(num_find != -1){
		cout << "\tERROR. A file or a folder: \"" << mask << "\",\n\twith this name already exists.\n\tReplace?\n";
		isAllowReplace = InterAnswerYN();
		if(isAllowReplace) del(mask.c_str());
	}

	//Если можно заменить, заменять.
	if(isAllowReplace)
		if(rename(srcPath,mask.c_str())) cout << "\tERROR. Wrong path or not enough rights to the operation.\n";

	_findclose(num_find);
	delete data_found;
}
void commander::opFile(const char* path) const{
	FILE *fileDesc = fopen(path,"r");
	if(fileDesc){
		const size_t size = 81;
		char buffer[size];
		while(!feof(fileDesc)){
			fgets(buffer,size,fileDesc);
			cout << buffer << endl;
		}
		fclose(fileDesc);
	}
	else cout << "ERROR. Wrong path \"" << path << "\"\n\tor not enough rights to the operation.\n";
}
void commander::mkFile(const char* path) const{
	_finddata_t* data_found = new _finddata_t;
	long num_find = _findfirst(path,data_found);

	bool isAllowReplace = true;
	if(num_find != -1){
		cout << "\tERROR. A folder or file: \"" << path << "\",\n\twith this name already exists.\n\tReplace?\n";
		isAllowReplace = InterAnswerYN();
		if(isAllowReplace) del(path);
	}

	if(isAllowReplace){
		FILE *fileDesc = fopen(path,"w");
		if(!fileDesc) cout << "\tERROR. Can not create file:" << path << "\n\tWrong path or not enough rights to the operation.\n";
		fclose(fileDesc);
	}

	_findclose(num_find);
	delete data_found;
}
string commander::filename(const char* path){
	//Извлекаем имя файла (Всё, что за последним слэшом. Если нет слэша ни чиво не меняем).
#define SIZE_LINE 260
	char temp[SIZE_LINE]{};
	strcpy(temp,path);
	delLastSlash(temp);
	char* ptrToSlash = strrchr(temp,'\\');

	return (ptrToSlash)?ptrToSlash + 1:path;
}
void commander::delLastSlash(char* path){
	unsigned lastSymbolIndex = strlen(path) - 1;
	if(path[lastSymbolIndex] == '\\')
		path[lastSymbolIndex] = '\0';
}
char* commander::delSpaces(char* line) const{
	//Удаляем пробелы с начала
	for(size_t i = 0; line[i]; i++){
		if(line[0] == ' '){
			for(size_t j = 0; line[j]; j++)
				line[j] = line[j + 1];
		}
		else break;
	}

	//Удаляем пробелы с конца
	for(size_t i = strlen(line) - 1; i >= 0; i--){
		if(line[i] == ' ') line[i] = '\0';
		else break;
	}

	return line;
}
string commander::SpcToUnln(string &text,const unsigned &size) const{
	for(size_t i = 0; i < size; i++)
		if(text[i] == ' ') text[i] = '_';
	return string();
}
void commander::inputHistory(const char* line) const{
	ofstream addToHis(HistoryFile.c_str(),ios::out | ios::app);
	if(!addToHis) printf("ERROR. Dont open history file %s \"",HistoryFile,"\"\n");
	const time_t seconds = time(NULL);
	string _time = ctime(&seconds);
	addToHis << HisAmLines + 1 << '. ' << SpcToUnln(_time,_time.size() + 1) << "\t\"" << line << "\"\n";

	if(addToHis) addToHis.close();
}
void commander::initFileHistory() const{
	ofstream readHis(HistoryFile,ios::in);
	if(!readHis) printf("ERROR. Dont open history file %s \"",HistoryFile,"\"\n");

	if(readHis) readHis.close();
}
char* commander::DynamicStr() const{
#define ENTER_KEY 13
	long long size = 1;
	char* text = (char*)calloc(size,sizeof(char));
	for(char temp = 0;;){
		temp = _getch();
		if(temp == ENTER_KEY){
			printf("%c",'\n');
			return text;
		}
		for(size_t i = 0; i < size - 1; i++) printf("%c",'\b');
		text = (char*)realloc(text,++size * sizeof(char));
		text[size - 1] = '\0';
		text[size - 2] = temp;
		printf("%s",text);
	}
}

