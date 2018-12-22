#include "tree.h"

tree::tree() {
	root=NULL;
}
bool tree::add(const string& key,const string& violation) {
	node* newNode=search(getRoot(),key);

	if(newNode) {
		if(newNode->cntViolations!=MAX_VIOLATIONS) {
			newNode->violations[newNode->cntViolations]=violation;
			newNode->cntViolations++;
		}
		else return 1;
	}
	else {
		newNode=new node;
		newNode->key=key;
		newNode->violations[newNode->cntViolations]=violation;

		node* temp=root;
		if(root==NULL)
			root=newNode;
		else {
			node* parent=NULL;

			while(temp) {
				parent=temp;
				if(key<temp->key)
					temp=temp->left;
				else
					temp=temp->right;
			}

			if(key<parent->key)
				parent->left=newNode;
			else
				parent->right=newNode;
		}
		newNode->cntViolations++;
	}
	return 0;
}
void tree::show(const node* _node) {
	if(_node->left)
		show(_node->left);

	cout<<_node->key<<'\n';

	for(int i=0; i<_node->cntViolations; i++)
		cout<<'\t'<<i+1<<". "<<_node->violations[i]<<'\n';

	if(_node->right)
		show(_node->right);
}
node* tree::search(node* _node,const string& key) {
	while(_node&&_node->key!=key) {
		if(key<_node->key)
			_node=_node->left;
		else
			_node=_node->right;
	}
	return _node;
}
void tree::search(node* _node,const string& start_key,const string& end_key) {
	if(_node->key>=start_key&&_node->key<=end_key) {
		cout<<_node->key<<'\n';

		for(int i=0; i<_node->cntViolations; i++)
			cout<<'\t'<<i+1<<". "<<_node->violations[i]<<'\n';
	}

	if(_node->left)
		search(_node->left,start_key,end_key);

	if(_node->right)
		search(_node->right,start_key,end_key);
}
node* tree::getRoot() {
	return root;
}
//bool tree::import(const char* fileName) {
//	FILE* pFile=fopen(fileName,"r");
//	if(pFile) {
//		while(!feof(pFile)) {
//			char key[MAX_CHAR_KEY];
//			char violation[MAX_CHAR_VIOLATION];
//
//			fscanf(pFile,"%s %[A-z a-z.]\n",key,violation);
//
//			add((string)key,(string)violation);
//		}
//
//		fclose(pFile);
//
//		return 0;
//	}
//	else return 1;
//}
bool tree::save(const char* fileName) {
	FILE* pFile=fopen(fileName,"w");
	if(pFile) {
		save(getRoot(),pFile);
		fclose(pFile);

		return 0;
	}
	else return 1;
}
void tree::save(const node* _node,FILE* fileDesc) {
	if(_node->left)
		save(_node->left,fileDesc);

	for(int i=0; i<_node->cntViolations; i++) {
		const char *charKey=_node->key.c_str();
		const char *charViolation=_node->violations[i].c_str();
		fprintf(fileDesc,"%s %s\n",charKey,charViolation);
	}

	if(_node->right)
		save(_node->right,fileDesc);
}
// tree:~tree(){

// }
