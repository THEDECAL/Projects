#pragma once
#include <iostream>
#define CNT_FUELS 3
struct fuel {
	char name[10];
	int cnt_liters;
	double price_per_liter;
};

class fuel_station {
	fuel fuels[CNT_FUELS];
	double cash_box;
public:
	fuel_station() {
		cash_box = 1000.0;
	}
	fuel_station(const fuel arr_fuel[]){
		cash_box = 1000.0;
		for (int i = 0; i < CNT_FUELS;i++) {
			this->fuels[i] = arr_fuel[i];
		}
	}
	double cash_out() {
		double tmp = cash_box;
		cash_box = 0;
		return tmp;
	}
	void get(){
		std::cout << "Money: " << cash_box << "\n\n";
		for (int i = 0; i < CNT_FUELS;i++) {
			std::cout << "Name: "<< fuels[i].name << "\n" ;
			std::cout << "Left liters: "<<fuels[i].cnt_liters<<"\n";
			std::cout<<"Price on liter: "<<fuels[i].price_per_liter<<"\n";
		}
		std::cout<<"-----\n";
	}
	void fuel_up(const char name[],const int liters){
		bool flag = 1;
		for (int i = 0; i < CNT_FUELS; i++){
			if(strcmp(fuels[i].name, name)==0){
				fuels[i].cnt_liters+=liters;
				flag = 0;
				break;
			}
		}
		if(flag) std::cout << name << " there is not such fueling.\n";
	}
};