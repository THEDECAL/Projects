#pragma once
#include <math.h>

class figure{
public:
	virtual double area() = 0;
	virtual void show(){ std::cout<<area()<<std::endl; }
};

class circle: public figure{
	const double pi = 3.1415;
	double radius;
public:
	circle(const double& radius):radius(radius){}
	double area(){ return pi*(radius*radius); }
	void show(){
		std::cout << "Circle:\n";
		figure::show();
	}
};

class rectangle: public figure{
	double a,b;
public:
	rectangle(const double& a,const double& b):a(a),b(b){}
	double area(){ return a*b; }
	void show(){
		std::cout << "Rectangle:\n";
		figure::show();
	}
};

class triangle: public figure{
	double a,b,c;
public:
	triangle(const double& a,const double& b,const double& c):a(a),b(b),c(c){}
	double area(){
		const double p = (a + b + c) / 2;
		return sqrt(p*(p - a)*(p - b)*(p - c));
	}
	void show(){
		std::cout << "Triangle:\n";
		figure::show();
	}
};

class trapeze: public figure{
	double a,b,height;
public:
	trapeze(const double& a,const double& b,const double& height):a(a),b(b),height(height){}
	double area(){ return (a + b)*height / 2; }
	void show(){
		std::cout << "Trapeze:\n"; 
		figure::show();
	}
};
