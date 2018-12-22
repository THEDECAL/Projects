#pragma once
//#include <iostream>
//#include <iterator>
#include <fstream>
#include <direct.h>
#include <string>
#include <io.h>
using namespace std;
//using std::string;
//using std::iterator;

namespace fileMngr{
	const string TESTS = ".\\tests\\";
	const string ACCOUNTS = ".\\accounts\\";
	const string PASSED_TESTS = ".\\passed_tests\\";

	class fmngr{
	public:
		static void string_save(fstream& stream,const string& text){
			unsigned size = text.size() + 1;
			stream.write((char*)&size,sizeof(size));
			stream.write((char*)text.c_str(),size);
		}		
		static string string_load(fstream& stream){
			unsigned size = 0;
			stream.read((char*)&size,sizeof(size));
			char* buffer=new char[size];
			stream.read((char*)buffer,size);
			string _string = buffer;
			delete[]buffer;

			return _string;
		}
		static bool find(const string& path){
			bool rCode = 0;
			_finddata_t* data_found = new _finddata_t;
			long num_find = _findfirst(path.c_str(),data_found);
			if(num_find != -1){ rCode = 1; }

			_findclose(num_find);
			delete data_found;

			return rCode;
		}
		static bool mkFolder(const string& path){
			if(find(path)) return 0;
			if(_mkdir(path.c_str()) == -1) throw "Невозможно создать папку";
			return 0;
		}
		static bool delFile(const string& path){
			if(remove(path.c_str())) throw "Невозможно удалить файл";
			return 0;
		}
	};
	//class singletonFileManager{
	//	static singletonFileManager* ptr;
	//	std::fstream stream;
	//	singletonFileManager(){ ptr = NULL; }
	//public:
	//	static singletonFileManager* getRef(){ return ptr; }
	//	~singletonFileManager(){
	//		if(stream) stream.close();
	//		delete ptr;
	//	}
	//};
	//singletonFileManager* singletonFileManager::ptr = new singletonFileManager;
	//singletonFileManager* const ref = singletonFileManager::getRef();
	//singletonFileManager& const fmngr = *ref;
}
