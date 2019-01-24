#include "vehicle.h"

vehicle::vehicle(const string& name,const string& color,const double& velocity,const unsigned& capacity,const unsigned& carrying,const double& fuelConsumption){
	this->name=name;
	this->color=color;
	this->velocity=velocity;
	this->capacity=capacity;
	this->carrying=carrying;
	this->fuelConsumption=fuelConsumption;
}
void vehicle::show(){
	cout<<"---------------"<<endl;
	cout<<"Name: "<<name<<endl;
	cout<<"---------------"<<endl;
	cout<<"Color: "<<color<<endl;
	cout<<"Velocity: "<<velocity<<endl;
	cout<<"Capacity: "<<capacity<<endl;
	cout<<"Carrying: "<<carrying<<endl;
	cout<<"Fuel consumption: "<<fuelConsumption<<endl<<endl;
}
double vehicle::getfuelConsumption(){
	return fuelConsumption;
}
string vehicle::getName(){
	return name;
}