#pragma once
#include <iostream>
using namespace std;

enum keys{
	SLCT_ERR = 0,
	ARGS_ERR,
	QUOTES_ERR,
	READ_ERR,
	DOUBLE_NAME_ERR,
	READ_SRC_ERR,
	READ_DST_ERR,
	ERR,
	REPLACE_MESS,
	HELP_MESS,
	END,
};

class commander;

class messages{
	//Переменные
	static messages *pMessages;
	static const int TextSize = END + 1;
	string text[TextSize];
	//Методы
	messages(){
		pMessages = NULL;
		text[SLCT_ERR] = "There is no such command. Enter \"help\" for help";
		text[ARGS_ERR] = "Wrong number of arguments";
		text[QUOTES_ERR] = "Wrong number of quotes";
		text[READ_ERR] = "Wrong path or not enough rights to the operation";
		text[DOUBLE_NAME_ERR] = "With this name already exists";
		text[READ_SRC_ERR] = "Wrong source path or not enough rights to the operation";
		text[READ_DST_ERR] = "Wrong destination path or not enough rights to the operation";
		text[ERR] = "ERROR";
		text[REPLACE_MESS] = "Replace?";
		text[HELP_MESS] = "help or ? - Help to this program\n\
							\tdir [path] - Show files in directory\n\
							\tclear - Screen cleaning\n\
							\tcd <path> - Change working directory\n\
							\t\t\"cd -\" - Previous folder\n\
							\t\t\"cd .\" - This folder\n\
							\t\t\"cd ..\" - Parent folder\n\
							\tmkdir <path> - Create folder\n\
							\trm <path> - Delete folders and files\n\
							\tcp <path> - Copy folders and files\n\
							\tmv <source path> <destination path> - Move and\\or rename file or directory\n\
							\topen <path> - Open file in text mode\n\
							\tmk <path> - Make new file";
	}
public:
	~messages(){
		delete pMessages;
	}
	void notify(const unsigned &messCode){
		if(messCode <= TextSize){
			if(messCode <= ERR)	
				cout << "\t" << text[ERR].c_str() << ". " << text[messCode].c_str() << ".\n";
				//printf("\t%s. %s.\n",text[ERR].c_str(),text[messCode].c_str());
			else
				std::cout << "\t" << text[messCode].c_str() << ".\n";
				//printf("\t%s\n",text[messCode].c_str());
		}
	}
	static const messages* getRef(){
		return pMessages;
	}
	friend commander;
};
#include "commander.h"
