#pragma once
#include <iostream>
//#include <string.h>
//#define CNT_FUELS_BRAND 3

//struct fuel {
//	char name[10];
//	int cnt_liters;
//	double price_per_liter;
//};

class fuel_station{
private:
	struct fuel{
		char name[10];
		int cnt_liters;
		double price_per_liter;
	};
	//fuel fuels[CNT_FUELS_BRAND];
	fuel *fuels;
	int cnt_fuels;
	double cash_box;
public:
fuel_station() {
		fuels=NULL;
		cnt_fuels=0;
		cash_box = 0;
	}
	//bool check_password(office &o,const int password){
	//	return o.check_password(password);
	//}
	fuel_station& operator =(const fuel_station &o){
		for(int i=0; i<cnt_fuels; i++){
			strcpy(this->fuels[i].name,o.fuels[i].name);
			this->fuels[i].cnt_liters=o.fuels[i].cnt_liters;
			this->fuels[i].price_per_liter=o.fuels[i].price_per_liter;
		}
		this->cash_box=o.cash_box;

		return *this;
	}
	//fuel_station(const fuel arr_fuel[]){
	//	cash_box = 0;
	//	for(int i=0; i < CNT_FUELS_BRAND; i++) {
	//		this->fuels[i] = arr_fuel[i];
	//	}
	//}
	void add_fuel(const char *name,const int cnt_liters,const double price_per_liter){
		fuel *temp=new fuel[cnt_fuels+1];
		if(fuels){
			for(int i=0; i<cnt_fuels; i++){
				temp[i]=this->fuels[i];
				/*strcpy(temp[i].name,this->fuels[i].name);
				temp[i].cnt_liters=this->fuels[i].cnt_liters;
				temp[i].price_per_liter=this->fuels[i].price_per_liter;*/
			}
			delete[]fuels;
		}
		strcpy(temp[cnt_fuels].name,name);
		temp[cnt_fuels].cnt_liters=cnt_liters;
		temp[cnt_fuels].price_per_liter=price_per_liter;
		fuels=new fuel[cnt_fuels+1];
		fuels=temp;
		delete[]temp;
		cnt_fuels++;
	}
	double cash_out() {
		double tmp = cash_box;
		cash_box = 0;
		return tmp;
	}
	void get(){
		std::cout << "Money: " << cash_box << "\n\n";
		for(int i=0; i < cnt_fuels; i++) {
			std::cout << "Name: ";
			std::cout << fuels[i].name << std::endl ;
			std::cout << "Left liters: ";
			std::cout << fuels[i].cnt_liters << std::endl;
			std::cout << "Price on liter: ";
			std::cout << fuels[i].price_per_liter << std::endl;
			std::cout << std::endl;
		}
	}
	void fuel_up(const char name[],const int liters){
		bool flag = 1;
		for(int i=0; i < cnt_fuels; i++){
			if(strcmp(fuels[i].name, name)==0){
				fuels[i].cnt_liters+=liters;
				flag = 0;
				break;
			}
		}
		if(flag) std::cout << name << " there is not such fueling.\n";
	}
	~fuel_station(){
		if(fuels) delete[]fuels;
	}
};