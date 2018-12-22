#include <iostream>
using namespace std;

void main() {
	char sym;
	int pos, am, cnt;

	while (true) { //Запускаем безконечный цикл
		sym = pos = am = cnt = 0;
		system("cls"); //Чистим экран после кажой итерации цикла

		cout << "Please enter symbols to print: "; cin >> sym;
		cout << "Please enter amount symbols to print "; cin >> am;
		cout << "Please enter position \n\t 0 to horizontally \n\t 1 to vertically\n"; cin >> pos;

		if (pos == 1) { //Если не 0, то горизонтальная позиция
			while (am > cnt) {
				cout << sym;
				cnt++;
			}
		}
		else { //Если 0, то вертикальная позиция
			while (am > cnt) {
				cout << sym << '\n';
				cnt++;
			}
		}
		cout << '\n';
		cout << "Please press Ctrl + C to exit or another key to continue...\n";

		system("pause");
	}
}