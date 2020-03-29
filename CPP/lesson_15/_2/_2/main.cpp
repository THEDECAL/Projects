#include <iostream>
#include <vector>
#include <string>
using namespace std;

void main(){
	const int size = 9;
	vector<string> multiple_table[size];

	for(size_t i = 2; i <= size; i++){
		for(size_t j = 2; j <= size; j++){
			string text = to_string(i);
			text += '*';
			text += to_string(j);
			text += '=';
			text += to_string(i * j);
			multiple_table[i - 2].push_back(text);
			cout<<multiple_table[i - 2][j - 2] << endl;
		}
		cout << '\n';
	}

	system("pause");
}
