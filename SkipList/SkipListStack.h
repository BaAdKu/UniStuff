#pragma once
#include <vector>
class SkipListStack
{
public:
	std::vector<SkipListStack*> Elems;
	int Value;
	int Height;//Value from 0 to Max-1
	bool isStart;//this stack is the start stack
	bool isEnd;//this is the end stack

	SkipListStack(int h, int v, bool start, bool end);
	SkipListStack();
	~SkipListStack();

};

