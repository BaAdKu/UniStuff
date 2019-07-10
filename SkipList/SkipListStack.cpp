#include "SkipListStack.h"

SkipListStack::SkipListStack(int h, int v, bool start, bool end)
{
	if (!start && !end)
	{
		Value = v;

	}
	else
	{
		Value = INT16_MIN;
	}
	isStart = start;
	isEnd = end;
	Height = h;
	Elems = std::vector<SkipListStack*>(h, nullptr);
}

SkipListStack::SkipListStack()
{
	SkipListStack(0, 0, false, false);
}

SkipListStack::~SkipListStack()
{
	Elems.~vector();

}


