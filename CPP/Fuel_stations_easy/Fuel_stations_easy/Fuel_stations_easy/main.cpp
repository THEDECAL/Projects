#include <iostream>
#include "fuel_station.h"
#include "office.h"

int main(){
	const int password=12345;
	office OKKO(password);

	fuel a92{"A-92",5000,27.15};
	fuel a95{"A-95",3500,29.30};
	fuel a98{"A-98",2400,30.80};
	fuel fuels[]{a92,a95,a98};

	fuel_station first(fuels);
	first.fuel_up("A-98",1000);
	fuel_station second(fuels);
	second.fuel_up("A-92",2000);
	fuel_station third(fuels);
	third.fuel_up("A-95",1500);

	OKKO.add_station(password,first);
	OKKO.add_station(password,second);
	OKKO.add_station(password,third);
	OKKO.get_all_stations(password);

	OKKO.cash_out(password);
	OKKO.get_bank(password);

	std::system("pause");
	return 0;
}