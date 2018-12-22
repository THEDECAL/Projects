#include <iostream>
#include <string>
using namespace std;

class FileFactory{
public:
	string fileName;
	FileFactory(const string& fileName):fileName(fileName){}
	virtual FileFactory* create() = 0;
	virtual void open() = 0;
	virtual void close() = 0;
	virtual void print() = 0;
	virtual void save() = 0;
	virtual void save_as() = 0;
};
class TextFile:public FileFactory{
public:
	TextFile(const string& fileName):FileFactory(fileName){}
	FileFactory* create(){ cout << "Text file " << fileName << " is created.\n"; return new TextFile(fileName);}
	void open(){ cout << "Text file " << fileName << " is opened.\n"; }
	void close(){ cout << "Text file " << fileName << " is closed.\n"; }
	void print(){ cout << "Text file " << fileName << " is printed.\n";}
	void save(){ cout << "Text file " << fileName << " saved.\n";}
	void save_as(){ cout << "Text file " << fileName << " is printed.\n";}
};
class GraphicFile:public FileFactory{
public:
	GraphicFile(const string& fileName):FileFactory(fileName){}
	FileFactory* create(){ cout << "Graphic file " << fileName << " is created.\n"; return new GraphicFile(fileName); }
	void open(){ cout << "Graphic file " << fileName << " is opened.\n"; }
	void close(){ cout << "Graphic file " << fileName << " is closed.\n";}
	void print(){ cout << "Graphic file " << fileName << " is printed.\n";}
	void save(){ cout << "Graphic file " << fileName << " saved.\n";}
	void save_as(){ cout << "Graphic file " << fileName << " is printed.\n";}
};

class TextEditor{
public:
	FileFactory* create(const string& fileName){
		TextFile temp(fileName);
		return temp.create();
	}
};
class GraphicEditor{
public:
	FileFactory* create(const string& fileName){
		GraphicFile temp(fileName);
		return temp.create();
	}
};

void main(){
	TextEditor _TextEditor;
	GraphicEditor _GraphicEditor;
	const string TextFileName="test.txt";
	const string GraphicFileName = "test.jpg";

	_TextEditor.create(TextFileName);
	_GraphicEditor.create(GraphicFileName);

	system("pause");
}
