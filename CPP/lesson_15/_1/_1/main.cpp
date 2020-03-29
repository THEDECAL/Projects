#include <iostream>
#include <vector>
using namespace std;

void main(){
	const unsigned size = 10;
	vector<int> _vector(size);

	const int factor = 2;
	for(int i = 0,n = 1; i < size; i++){
		_vector[i]=n*=factor;
		cout << _vector[i] << ' ';
	}

	system("pause");
}
