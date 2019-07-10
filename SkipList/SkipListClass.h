#pragma once
#include <vector>
#include "SkipListStack.h"
class SkipListClass
{
public:
	int MaxHeight;
	SkipListStack* startStack;
	SkipListStack* endStack;
	SkipListClass(int max);
	~SkipListClass();
	void Add(int* values, int cap);
	void Add(int val);
	void Delete(int val);
	bool Check(int val);	
	void ClearList();
	void Print();

};

