#include <iostream>
#include <string>
#include "vehicle.h"
using namespace std;

class car:public vehicle{
public:
	car(const string& name,const string& color,const double& velocity,const unsigned& capacity,const unsigned& carrying,const double& fuelConsumption):vehicle(name,color,velocity,capacity,carrying,fuelConsumption){}
};

class bike:public vehicle{
public:
	bike(const string& name,const string& color,const double& velocity,const unsigned& capacity,const unsigned& carrying,const double& fuelConsumption):vehicle(name,color,velocity,capacity,carrying,fuelConsumption){}
};

class cart:public vehicle{
public:
	cart(const string& name,const string& color,const double& velocity,const unsigned& capacity,const unsigned& carrying,const double& fuelConsumption):vehicle(name,color,velocity,capacity,carrying,fuelConsumption){}
};

void main(){
	car _car("Alfa Romeo","red",180.4,5,300,14.4);
	bike _bike("Subrosa","black",18.0,2,50,1.5);
	cart _cart("METRO","yellow",8.0,2,100,1.0);

	_car.show();
	_bike.show();
	_cart.show();

	double price;
	cout<<"Please enter price per liter of fuel: ";
	cin>>price;

	double distance;
	cout<<"Please enter a distance (km): "; 
	cin>>distance;

	cout<<"Transportation price:\n";
	cout<<"Car ("<<_car.getName()<<"): "<<distance*(_car.getfuelConsumption()/100)*price<<'$'<<endl;
	cout<<"Bike ("<<_bike.getName()<<"): "<<distance*(_bike.getfuelConsumption()/100)*price<<'$'<<endl;
	cout<<"Cart ("<<_cart.getName()<<"): "<<distance*(_cart.getfuelConsumption()/100)*price<<'$'<<endl;

	system("pause");
}
