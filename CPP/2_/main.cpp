#include <iostream>
#include <string>
#define CNT_VISAS 10
using namespace std;

class passport{
	string serialNumber;
	string name;
	string city;
	string address;
public:
	passport(const string& serialNumber,const string& name,const string& city,const string& address){
		this->serialNumber=serialNumber;
		this->name=name;
		this->city=city;
		this->address=address;
	}
	virtual void show(){
		cout<<endl;
		cout<<"Sereial number: "<<serialNumber<<endl;
		cout<<"Name: "<<name<<endl;
		cout<<"City: "<<city<<endl;
		cout<<"Adress: "<<address<<endl;
	}
};

class inter_passport:public passport{
	string serialNumber;
	string visas[CNT_VISAS];
	unsigned cntVisas;
public:
	inter_passport(const string& serialNumber,const string& interSerialNumber,const string& name,const string& city,const string& address):passport(serialNumber,name,city,address){
		this->serialNumber=interSerialNumber;
		cntVisas=0;
	}
	void setVisa(const string& counrty){
		if(cntVisas<CNT_VISAS){
			visas[cntVisas]=counrty;
			cntVisas++;
		}
	}
	void show(){
		passport::show();
		cout<<"International serial number: "<<serialNumber<<endl;
		if(cntVisas){
			cout<<"Visited countries:\n";
			for(int i=0; i<cntVisas; i++)
				cout<<'\t'<<i+1<<". "<<visas[i]<<endl;
		}
	}
};

void main(){
	inter_passport obj("ZZ902111","AEE09123","Bob Larson","Hollywood","st.Woody-Wood 37");
	obj.setVisa("China");
	obj.setVisa("Ukraine");
	obj.setVisa("Russia");
	obj.show();

	system("pause");
}
