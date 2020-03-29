#include <iostream>
#include <time.h>
#include "list.h"

void main(){
	srand(time(NULL));

	const unsigned amNumbers = 10;

	stack _stack;
	for(size_t i = 0; i < amNumbers; i++) _stack.push(rand() % 10);
	_stack.show();
	for(size_t i = 0; i < amNumbers; i++) std::cout<<_stack.pop()<<' ';
	std::cout << std::endl;

	queue _queue;
	for(size_t i = 0; i < amNumbers; i++) _queue.push(rand() % 10);
	_queue.show();
	for(size_t i = 0; i < amNumbers; i++) std::cout << _queue.pop() << ' ';
	std::cout << std::endl;

	system("pause");
}
