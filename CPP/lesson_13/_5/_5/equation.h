#pragma once
#include <iostream>
#include <math.h>
using std::cout;

class equation{
public:
	virtual void roots() = 0;
};

//ax+b=0
class linear_eq: public equation{
	double a,b;
public:
	linear_eq(const double& a,const double& b):a(a),b(b){}
	void roots(){
		cout << a;
		(b >= 0)?cout<<"x+" << b:cout<<"x"<<b; //Вывод на случай отрицательного b
		cout << "=0" << std::endl;
		cout << "Roots: ";

		if(a != 0) cout << -(b / a);
		else if(a == 0 && b != 0) cout << "No roots.";
		else if(a == 0 && b == 0) cout << "Many roots.";
		cout << std::endl;
	}
};

//ax2+bx+c=0
class quadratic_eq: public equation{
	double a,b,c;
public:
	quadratic_eq(const double& a,const double& b,const double& c):a(a),b(b),c(c){}
	void roots(){
		const double discriminant = (b*b) - 4 * (a*c);
		double x1,x2;
		cout << a;
		(b >= 0)?cout << "x2+" << b:cout << "x2" << b; //Вывод на случай отрицательного b
		(c >= 0)?cout << "x+" << c:cout << "x" << c; //Вывод на случай отрицательного c
		cout << "=0" << std::endl;
		cout << "Roots: ";

		if(discriminant > 0){
			cout << "x1=" << -(b) - sqrt(discriminant) / 2 * a << ", ";
			cout << "x2=" << -(b) + sqrt(discriminant) / 2 * a;
		}
		else if(discriminant == 0){
			cout << "x1=x2=" << -(b / 2*a);
		}
		else if(discriminant<0) cout << "No roots.";
		cout << std::endl;
	}
};
