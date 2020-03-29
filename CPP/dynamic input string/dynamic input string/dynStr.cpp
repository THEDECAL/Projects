#include <iostream>

//Динамическое выделние памяти для ввода символов

static char* cDynamicStr(){ //Возврат типа char
	long long size = 1;
	char* text=(char*)calloc(size,sizeof(char));
	while(true){
		char ch;
		std::cin.get(ch);
		if(ch == '\n') return text; //Если введена клавиша ENTER вернуть строку
		text=(char*)realloc(text,++size*sizeof(char)); //Перевыделение памяти
		text[size-1]='\0'; //Последний символ, конец строки
		text[size-2]=ch; //Предпоследний символ, введённый символ
	}
}
static std::string sDynamicStr(){ //Возврат типа string
	long long size = 1;
	std::string text;
	while(true){
		char ch;
		std::cin.get(ch);
		if(ch == '\n') return text; //Если введена клавиша ENTER вернуть строку
		text += ch;
	}
}
