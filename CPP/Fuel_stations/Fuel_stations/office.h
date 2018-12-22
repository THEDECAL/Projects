#pragma once
#include "fuel_station.h"

class office{
private:
	fuel_station *fuelings;
	int cnt_stations;
	const int password;
	double bank;
public:
	office(const int password):password(password){
		fuelings=0;
		cnt_stations = 0;
		bank = 0.0;
	}
	bool check_password(const int password){
		if(this->password==password) return 1;
		else{
			std::cout<<"Access deny.\n";
			return 0;
		}
	}
	void add_station(const fuel_station &station){
		fuel_station *temp=new fuel_station[cnt_stations+1];
		if(fuelings){
			for(int i=0; i<cnt_stations;i++){
				temp[i]=fuelings[i];
			}
			delete[]fuelings;
		}
		temp[cnt_stations]=station;
		fuelings=new fuel_station[cnt_stations+1];
		fuelings=temp;
		delete[]temp;
		cnt_stations++;
	}
	void get_all_stations(const int password){
		if(check_password(password)){
			if(cnt_stations){
				for(int i=0; i < cnt_stations; i++) {
					std::cout<<"Station #"<<i+1<<"\n";
					this->fuelings[i].get();
					std::cout << "\n";
				}
			}
			else std::cout<<"Array fuel stations is empty.\n";
		}
	}
	void cash_out(const int password){
		if(check_password(password)){
			for(int i=0; i < cnt_stations; i++) {
				bank += fuelings[i].cash_out();
			}
		}
	}
	~office(){
		if(fuelings) delete[]fuelings;
	}
};