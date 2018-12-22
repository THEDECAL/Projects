////Задание №2. Создать класс для работы с матрицами.
////Предусмотреть, как минимум, функции для сложения матриц, умножения матриц,
////транспонирования матриц, присваивания матриц друг другу,
////установка и получение произвольного элемента матрицы.
////Необходимо перегрузить соответствующие операторы. 
////
#include <iostream>
#include "matrix.h"
#include <time.h>
int main(){
	srand(time(NULL));

	matrix first(2,3);
	std::cout<<"matrix first:\n";
	first.get();
	std::cout<<"\n";

	matrix second(2,3);
	std::cout<<"matrix second:\n";
	second.get();
	std::cout<<"\n";

	first=second;
	std::cout<<"first=second:\n";
	first.get();
	std::cout<<"\n";

	matrix third;
	std::cout<<"first+second=\n";
	third=first+second;
	third.get();
	std::cout<<"\n";

	std::system("pause");
	return 0;
}
