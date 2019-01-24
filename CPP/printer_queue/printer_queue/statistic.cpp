#include "statistic.h"

statistic::statistic(const char* name){
	strcpy(this->name,name);
	current_time();
}
void statistic::current_time(){
	char curr_time[TIME_STRING_SIZE];
	time_t secs=time(NULL);
	tm* timeinfo=localtime(&secs);
	char* format="%d.%m.%Y %H:%M:%S";
	strftime(curr_time,TIME_STRING_SIZE,format,timeinfo);
	strcpy(this->_time,curr_time);
}
char* statistic::get_name(){
	return name;
}
char* statistic::get_time() {
	return _time;
}