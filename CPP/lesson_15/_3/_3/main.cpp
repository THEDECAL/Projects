#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <ctime>
using namespace std;

class student{
	string fname;
	string sname;
	string group;
public:
	student(){ init(); }
	student(const string& fname,const string& sname,const string& group):fname(fname),sname(sname),group(group){}
	friend ostream& operator<<(ostream& os,const student& obj){ cout << obj.sname << ' ' << obj.fname << ' ' << obj.group << '\n'; return os; }
	void init(){ //Генерация данных
		const unsigned fnameSize = 5;
		const unsigned snameSize = 7;
		const unsigned groupSize = 5;
		const char ASCIIabcStart = 97;

		fname += (ASCIIabcStart + rand() % 26) - 32; //Первая буква большая
		for(size_t i = 1; i < fnameSize; i++){
			fname += ASCIIabcStart + rand() % 26;
		}

		sname += (ASCIIabcStart + rand() % 26) - 32; //Первая буква большая
		for(size_t i = 1; i < snameSize; i++){
			sname += ASCIIabcStart + rand() % 26;
		}

		group += "IS-0";
		group += to_string(1 + rand() % 5);
	}
	static bool compare_by_fname(const student& f,const student& s){ return (f.fname < s.fname); }
	static bool compare_by_sname(const student& f,const student& s){ return (f.sname < s.sname); }
	static bool compare_by_group(const student& f,const student& s){ return (f.group < s.group); }
};

void main(){
	srand(time(NULL));

	const unsigned size = 7;
	auto_ptr<vector<student>>students(new vector<student>);

	for(size_t i = 0; i < size; i++){ students->push_back(student()); } //Заполняем вектор студентами

	cout << "-------------------\n";
	cout << "Contents of a vector students:\n";
	cout << "-------------------\n";
	/*vector<student>::iterator it = students->begin();*/
	auto it = students->begin();
	while(it != students->end()){ cout << *it++; }

	cout << "-------------------\n";
	cout << "Sort by first name:\n";
	cout << "-------------------\n";
	sort(students->begin(),students->end(),student::compare_by_fname);
	it = students->begin();
	while(it != students->end()){ cout << *it++; }

	cout << "-------------------\n";
	cout << "Stable sort by surname:\n";
	cout << "-------------------\n";
	stable_sort(students->begin(),students->end(),student::compare_by_sname);
	it = students->begin();
	while(it != students->end()){ cout << *it++; }

	cout << "-------------------\n";
	cout << "Sort by group:\n";
	cout << "-------------------\n";
	sort(students->begin(),students->end(),student::compare_by_group);
	sort(students->begin(),students->begin()+2,student::compare_by_fname);
	it = students->begin();
	while(it != students->end()){ cout << *it++; }

	system("pause");
}
