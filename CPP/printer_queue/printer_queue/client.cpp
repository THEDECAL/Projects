#include "client.h"

client::client(){
	prio=rand()%10+1;
	for(int i=0; i<MAX_NAME_SYMBOLS-1; i++)
		name[i]=rand()%26+97;
	name[MAX_NAME_SYMBOLS-1]='\0';
}
void client::operator=(const client& o){
	strcpy(this->name,o.name);
	this->prio=o.prio;
}
char* client::get_name(){
	return name;
}
unsigned client::get_prio() {
	return prio;
}
