#define _CRT_SECURE_NO_WARNINGS
#include <fstream>
#include <ctime>
#include <iostream>

void main(){
	setlocale(LC_ALL,"rus");

	//time_t seconds = 1538053376;
	//time(&seconds);
	time_t seconds;
	std::fstream stream("./date",std::ios::in|std::ios::binary);
	stream.read((char*)&seconds,sizeof(seconds));

	tm* time = localtime(&seconds);
	const unsigned bsize = 100;
	char buffer[bsize];
	strftime(buffer,bsize,"%X %x",time);

	std::cout << buffer << std::endl;

	//std::fstream stream("./date",std::ios::out|std::ios::binary);

	//stream.write((char*)&seconds,sizeof(seconds));

	system("pause");
}
