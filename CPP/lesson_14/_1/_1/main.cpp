#include <iostream>
#include <string>

void stringToInt(const std::string& _string){
	const unsigned size = _string.size() + 1;
	char* text = new char[size];

	//Отсеиваем лишние символы заносим в массив только цифры
	unsigned amNum = 0;
	for(size_t i = 0; i < _string.size(); i++){
		if(_string[i] >= '0' && _string[i] <= '9')
			text[amNum++] = _string[i];
	}

	//Преобразовываем в число
	long long number = 0;
	unsigned fact = 1;
	const unsigned zero = '0';

	for(short i = amNum-1; i>=0; i--){
		number += (text[i]-zero) * fact;
		fact *= 10;
	}
	delete text;


	if(number > INT_MAX) throw "Number is too large.\n";
	else{
		std::cout << "You entered: ";
		if(_string[0] == '-') number-=number*2; //Если число отрицательное
		std::cout << number << std::endl;
	}
}

void main(){
	try{
		std::string text;
		int number = 0;

		std::cout << "Please enter the number: ";
		std::cin >> text;

		stringToInt(text);
	}
	catch(const char* message){ std::cout << "\tERROR. " << message; }
	catch(...){ std::cout << "\tUnexpected Error.\n"; }

	system("pause");
}
