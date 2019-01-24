#define _CRT_SECURE_NO_WARNINGS
#include "office.h"
//#include "fuel_station.h"

int main(){
	/*fuel a92{"A-92",5000,27.15};
	fuel a95{"A-95",3500,29.30};
	fuel a98{"A-98",2400,30.80};
	fuel fuels[]{a92,a95,a98};*/

	/*fuel_station first(fuels);
	fuel_station second(fuels);
	fuel_station third(fuels);*/

	//const int password=12345;
	//office OKKO(password);
	fuel_station first;
	first.add_fuel("A-92",5000,27.15);
	first.get();

	/*OKKO.add_station(first);
	OKKO.add_station(second);
	OKKO.add_station(third);
	OKKO.add_station(third);*/
	//OKKO.get_all_stations(password);

	std::system("pause");
	return 0;
}