#pragma once

const enum keys{
	SLCT_ERR,
	ARGS_ERR,
	QUOTES_ERR,
	READ_ERR,
	READ_SRC_ERR,
	READ_DST_ERR,
	DOUBLE_NAME_ERR,
	MAKE_DIR_ERR,
	DEL_DIR_ERR,
	MAKE_FILE_ERR,
	DIR_REPLACE_MESS,
	REPLACE_MESS,
	HELP_MESS,
	ENUM_SIZE
};

const char messages[ENUM_SIZE][512] = {
			"\tERROR. There is no such command. Enter \"help\" for help\n",
			"\tERROR. Wrong number of arguments\n",
			"\tERROR. Wrong number of quotes\n",
			"\tERROR. Wrong path or not enough rights to the operation\n",
			"\tERROR. Wrong source path or not enough rights to the operation\n",
			"\tERROR. Wrong destination path or not enough rights to the operation\n",
			"\tERROR. With this name already exists\n",
			"\tERROR. Can not create folder \"%s\"\n\tWrong path or not enough rights to the operation.\n",
			"\tERROR. Can not delete folder \"%s\"\n\tWrong path or not enough rights to the operation.\n",
			"\tERROR. Can not create file \"%s\"\n\tWrong path or not enough rights to the operation.\n",
			"\tA folder \"%s\",\n\twith this name already exists.\n\tReplace?\n",
			"\tA file or a folder: \"%s\",\n\twith this name already exists.\n\tReplace?\n",
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
\tmk <path> - Make new file\n"
};
