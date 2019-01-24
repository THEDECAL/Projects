#include <iostream>
#include <time.h>
#include "list.h"

int main() {
	srand(time(0));

	list<unsigned> first;

	std::cout<<"\t\t<--Doubly linked list-->\n";
	std::cout<<"\nAdd five random elements to head:\n";

	for(int i=0; i<5; i++)
		first.addToHead(rand()%99+1);

	first.show();
	std::cout<<"\nAdd one random element by index \"2\":\n";
	first.addByIndex(2,rand()%99+1);
	first.show();
	std::cout<<"\nAdd one random element to tail:\n";
	first.addToTail(rand()%99+1);
	first.show();
	std::cout<<"\nRemove one element to head:\n";
	first.removeFromHead();
	first.show();
	std::cout<<"\nRemove one element by index \"5\":\n";
	first.removeByIndex(5);
	first.show();
	std::cout<<"\nRemove one element to tail:\n";
	first.removeFromTail();
	first.show();

	list<unsigned> second;
	std::cout<<"\nClone all elements from the objects first to the object second:\n";
	second=first;
	second.show();

	list<unsigned> third;
	std::cout<<"\nThe sum of elements of object first and object second:\n";
	third=second+first+first;
	third.show();

	// list<unsigned> fourth; 
	std::cout<<"\nThe union of common elements of object first and object second:\n";
	third=second*first;
	third.show();

	std::cout<<"\nFunction getSize() for object third:\n";
	std::cout<<third.getSize()<<"\n";

	list<unsigned> fifth;
	std::cout<<"\nFunction isEmpty() for object fifth:\n";
	std::cout<<std::boolalpha<<fifth.isEmpty()<<"\n";

	std::cout<<"\nFunction isEmpty() for object third:\n";
	std::cout<<std::boolalpha<<third.isEmpty()<<"\n";

	std::cout<<"\nFunction removeAll() for object third:\n";
	third.removeAll();
	third.show();

	std::cout<<"\nObject second:\n";
	second.show();
	std::cout<<"\nFunction getAt(4) for object second:\n";
	std::cout<<'\t'<<second[4];

	std::cout<<"\nFunction setAt(3,33) for object second:\n";
	second.setAt(3,33);
	second.show();

	std::system("pause");
	return 0;
}
