#include "catalog.h"

catalog::catalog() {
	name=NULL;
	tel_num=NULL;
	cntEntry=0;
}
bool catalog::add(const char* name,const long long& tel_num) {
	if(search(name)>=0||search(tel_num)>=0)
		return 1;

	cntEntry++;
	this->tel_num=(long long*)realloc(this->tel_num,cntEntry*sizeof(long long));
	this->tel_num[cntEntry-1]=tel_num;

	this->name=(char**)realloc(this->name,cntEntry*sizeof(char*));
	this->name[cntEntry-1]=(char*)malloc(NAME_SIZE*sizeof(char));
	strncpy(this->name[cntEntry-1],name,NAME_SIZE-1);

	return 0;
}
unsigned catalog::getCntEntry() {
	return cntEntry;
}
void catalog::edit(const unsigned& index,const char* name) {
	if(index<=cntEntry)
		strcpy(this->name[index],name);
}
void catalog::edit(const unsigned& index,const long long& tel_num) {
	if(index<=cntEntry)
		this->tel_num[index]=tel_num;
}
void catalog::del(const unsigned& index) {
	for(int i=index; i<cntEntry-1; i++) {
		strcpy(this->name[i],this->name[i+1]);
		this->tel_num[i]=this->tel_num[i+1];
	}

	cntEntry--;
	free(name[cntEntry]);
	this->name=(char**)realloc(this->name,cntEntry*sizeof(char*));
	this->tel_num=(long long*)realloc(this->tel_num,cntEntry*sizeof(long long));
}
short catalog::search(const char* name,catalog* o) {
	for(int i=0; i<cntEntry; i++)
		if(strcmp(this->name[i],name)==0) {
			if(o!=NULL) o->add(this->name[i],tel_num[i]);
			return i;
		}

	return -1;
}
short catalog::search(const long long& tel_num,catalog* o) {
	for(int i=0; i<cntEntry; i++)
		if(this->tel_num[i]==tel_num) {
			if(o!=NULL) o->add(name[i],this->tel_num[i]);
			return i;
		}

	return -1;
}
bool catalog::search(const long long& start_tel_num,const long long& end_tel_num,catalog* o) {
	bool isFound=false;

	for(int i=0; i<cntEntry; i++) {
		if(tel_num[i]>=start_tel_num&&tel_num[i]<=end_tel_num) {
			if(o!=NULL) o->add(name[i],tel_num[i]);
			show(i);
			isFound=true;
		}
	}

	return isFound;
}
bool catalog::search(const char* start_name,const char* end_name,catalog* o) {
	bool isFound=false;

	for(int i=0; i<cntEntry; i++) {
		if(strncmp(name[i],start_name,strlen(start_name))==0&&strcmp(name[i],end_name)<=0) {
			if(o!=NULL) o->add(name[i],tel_num[i]);
			show(i);
			isFound=true;
		}
	}

	return isFound;
}
void catalog::sort() {
	if(cntEntry>1) {
		for(short i=1; i<cntEntry; i++) {
			for(short j=cntEntry-1; j>=i; j--) {
				if(strcmp(name[j],name[j-1])<0) {
					char tmpName[NAME_SIZE];
					long long tmpTelNum;

					strcpy(tmpName,name[j-1]);
					strcpy(name[j-1],name[j]);
					strcpy(name[j],tmpName);

					tmpTelNum=tel_num[j-1];
					tel_num[j-1]=tel_num[j];
					tel_num[j]=tmpTelNum;
				}
			}
		}
	}
}
bool catalog::show() {
	if(cntEntry) {
		for(int i=0; i<cntEntry; i++)
			std::cout<<i+1<<". "<<name[i]<<' '<<tel_num[i]<<'\n';
		return 0;
	}
	else return 1;
}
bool catalog::show(const short& index) {
	if(index<=cntEntry&&index>=0) {
		std::cout<<index+1<<". "<<name[index]<<' '<<tel_num[index]<<'\n';
		return 0;
	}
	else return 1;
}
bool catalog::save(const char* fileName) {
	FILE *pFile=fopen(fileName,"w");

	if(pFile) {
		for(int i=0; i<cntEntry; i++)
			fprintf(pFile,"%s %llu\n",name[i],tel_num[i]);

		fclose(pFile);

		return 0;
	}
	else return 1;
}
bool catalog::import(const char* fileName) {
	FILE *pFile=fopen(fileName,"r");

	if(pFile) {
		char buffer[256]{};
		char name[NAME_SIZE];
		long long tel_num;

		while(!feof(pFile)) {
			fscanf(pFile,"%s%llu\n",&name,&tel_num);
			add(name,tel_num);
		}
		fclose(pFile);

		return 0;
	}
	else return 1;
}
catalog::~catalog() {
	for(short i=0; i<cntEntry; i++) {
		free(name[i]);
	}
	free(name);
	free(tel_num);
}
