#pragma once
//#include <windows.h>
//#include <conio.h>

class utility{
	utility();
	//~utility();
	public:
	template <typename TYPE>
	static void arrayToArray(TYPE* toArray,const TYPE* ofArray,const int& size){
		for(int i=0; i<size; i++)
			toArray[i]=ofArray[i];
	}
	//static void gotoxy(const short x,const short y) {
	//	COORD c={x, y};
	//	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),c);
	//}
};
