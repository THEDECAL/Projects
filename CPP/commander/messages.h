#pragma once

static enum{
	SLCT_ERR=1,
	ARGS_ERR,
	QUOTES_ERR,
	READ_ERR,
	DOUBLE_NAME_ERR,
	READ_SRC_ERR,
	READ_DST_ERR,
	REPLACE_MESS,
	HELP_MESS,
	ENUM_SIZE
};

static unsigned NotifyKey=NULL;

static void notify(const unsigned& key){
	const std::string _text[ENUM_SIZE]={
		"ERROR. There is no such command. Enter \"help\" for help",
		"ERROR. Wrong number of arguments",
		"ERROR. Wrong number of quotes",
		"ERROR. Wrong path or not enough rights to the operation",
		"ERROR. With this name already exists",
		"ERROR. Wrong source path or not enough rights to the operation",
		"ERROR. Wrong destination path or not enough rights to the operation",
		"Replace?",
		"help or ? - Help to this program\n\
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
\tmk <path> - Make new file"
	};
	if(key <= ENUM_SIZE&&key!=0) std::cout<<_text[key-1]<<std::endl;
}
