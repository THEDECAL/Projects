#pragma once
#define CNT_FUELINGS 3

class office{
	fuel_station stations[CNT_FUELINGS];
	int cnt_stations;
	const int password;
	double bank;
public:
	office(const int password):password(password){
		cnt_stations = 0;
		bank=0.0;
	}
	bool check_password(const int password){
		if(this->password==password) return 1;
		else std::cout<<"Access deny.\n";
		return 0;
	}
	void get_bank(const int password){
		std::cout<<bank<<"\n";
	};
	void get_all_stations(const int password){
		if(check_password(password)){
			for(int i=0; i < CNT_FUELINGS; i++) {
				std::cout<<"Station #"<<i+1<<"\n";
				this->stations[i].get();
				std::cout << "\n";
			}
		}
	}
	void add_station(const int password,const fuel_station& station){
		if(check_password(password)){
			if(cnt_stations<CNT_FUELINGS){
				stations[cnt_stations]=station;
				cnt_stations++;
			}
			else std::cout<<"Array fuel stations is full.\n";
		}
	}
	void cash_out(const int password){
		if(check_password(password)){
			for (int i = 0; i < CNT_FUELINGS; i++) {
				bank += stations[i].cash_out();
			}
		}
	}
};