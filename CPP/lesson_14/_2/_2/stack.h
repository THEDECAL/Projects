#pragma once

template<typename TYPE>
class stack{
	TYPE* _stack;
	const unsigned capacity;
	unsigned currSize;
public:
	stack(const unsigned& capacity):capacity(capacity){
		_stack = new TYPE[capacity];
		currSize = 0;
	}
	void push(const TYPE& value){
		if(currSize != capacity) _stack[currSize++] = value;
		else throw "Stack is full.\n";
	}
	TYPE pop(){
		if(currSize) return _stack[currSize-- - 1];
		else throw "Stack is empty.\n";
	}
	TYPE operator [](const unsigned& index){
		if(index < currSize) return _stack[index];
		else throw "Out of range.\n"
	}
	TYPE* erase(const TYPE* address){
		if(address<end() && address>=begin()){
			for(TYPE* i = begin(); i!=end(); i++){
				if(address == i){
					for(TYPE* j = i; j!=end(); j++){
						*(j) = *(j + 1);
					}
				}
			}
			currSize--;
		}
		else throw "Out of range.\n";
	}
	TYPE* begin(){ return _stack; }
	TYPE* end(){ return &_stack[currSize]; }
	unsigned max_size(){ return capacity; }
	unsigned size(){ return currSize; }
	~stack(){ delete _stack; }
};
