#include "printer.h"

printer::printer(){
	queue_print[MAX_LENGTH_PRINT];
	cntPrints=0;
	queue_stat[MAX_LENGTH_STAT];
	cntStats=0;
	add_print();
}
void printer::add_print(){
	cntPrints=MAX_LENGTH_PRINT;
};
void printer::add_stat(const char* name){
	if(cntStats!=MAX_LENGTH_STAT){
		statistic temp(name);
		queue_stat[cntStats++]=temp;
	}
}
void printer::print(){
	if(cntPrints){
		unsigned max_prio=queue_print[0].get_prio();
		unsigned max_prio_index=0;
		for(int i=0; i<cntPrints;i++) {
			if(queue_print[i].get_prio()>max_prio){
				max_prio=queue_print[i].get_prio();
				max_prio_index=i;
			}
		}
		Sleep(500);
		add_stat(queue_print[max_prio_index].get_name());
		for(int i=max_prio_index; i<cntPrints-1; i++)
			queue_print[i]=queue_print[i+1];
		cntPrints--;
	}
	else std::cout<<"Queue for print is empty.\n";
}
void printer::get(){
	if(!cntPrints) std::cout<<"Queue for print is empty.\n";
	for(int i=0; i<cntPrints; i++)
		std::cout<<i+1<<". Name: "<<queue_print[i].get_name()<<", prio: "<<queue_print[i].get_prio()<<"\n";
}
void printer::get_stat(){
	if(cntStats){
		for(int i=0; i<cntStats; i++)
			std::cout<<i+1<<". Name: "<<queue_stat[i].get_name()<<",time: "<<queue_stat[i].get_time()<<"\n";
	}
	else std::cout<<"Queue for stattistic is empty.\n";
}