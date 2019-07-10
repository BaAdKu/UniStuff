#include "SkipListClass.h"
#include <time.h>
#include <stdlib.h>
#include <iostream>
#include <thread>

SkipListClass::SkipListClass(int max)
{
	srand(time(NULL));
	MaxHeight = max;

	startStack = &SkipListStack(MaxHeight, 0, true, false);
	endStack = &SkipListStack(MaxHeight, 0, false, true);
	for (int j = 0; j < MaxHeight; j++)
	{
		startStack->Elems.at(j) = endStack;
		endStack->Elems.at(j) = nullptr;
	}
}

SkipListClass::~SkipListClass()
{
	ClearList();
}

void SkipListClass::Add(int* values, int cap)
{
	for (int i = 0; i < cap; i++)
	{
		Add(values[i]);
	}
}

void SkipListClass::Add(int val)
{

	/*int currHeight = (rand() % MaxHeight)+1;
	SkipListStack insertion = SkipListStack(currHeight, val, false);
	if (!Check(val)) {
		if (List.at(1).isStartOrEnd)
		{
			List.insert(List.begin() + 1, insertion);
			for (int i = 0; i < currHeight; i++)
			{
				List.at(0).Elems.at(i) = &List.at(1);
				List.at(1).Elems.at(i) = &List.at(2);
			}
		}
		else
		{
			int CurrStack = 0;
			for (int i = MaxHeight - 1; i >= 0; )
			{

				if (List.at(CurrStack).Elems.at(i)->isStartOrEnd || List.at(CurrStack).Elems.at(i)->Value > val)
				{
					if (i < currHeight)
					{
						insertion.Elems.at(i) = List.at(CurrStack).Elems.at(i);
						List.at(CurrStack).Elems.at(i) = &insertion;
					}
					i--;
				}
				else
				{
					CurrStack = SearchVal(List.at(CurrStack).Elems.at(i)->Value);
					break;
				}
			}
			if (CurrStack == 0)
				CurrStack = 1;
			List.insert(List.begin() + CurrStack, insertion);
		}
	}*/

	SkipListStack* CurrStack = startStack;
	SkipListStack insertion = SkipListStack(rand() % MaxHeight, val, false, false);
	int CurrPointer = MaxHeight - 1;

	while (true)
	{
		if (CurrStack->Elems.at(CurrPointer)->isEnd)
		{
			CurrPointer--;
		}
		else
		{
			if (CurrStack->Elems.at(CurrPointer)->Value < val)
			{
				CurrStack = CurrStack->Elems.at(CurrPointer);
			}
			else if (CurrStack->Elems.at(CurrPointer)->Value > val)
			{
				if (CurrPointer < insertion.Height)
				{
					insertion.Elems.at(CurrPointer) = CurrStack->Elems.at(CurrPointer);
					CurrStack->Elems.at(CurrPointer) = &insertion;
				}
				CurrPointer--;

			}
		}
		if (CurrPointer < 0)
		{
			break;
		}
	}
}

void SkipListClass::Delete(int val)
{
	SkipListStack* temp;
	SkipListStack* CurrStack = startStack;
	int CurrPointer = MaxHeight - 1;

	while (true)
	{
		if (CurrStack->Elems.at(CurrPointer)->isEnd)
		{
			CurrPointer--;
		}
		else
		{
			if (CurrStack->Elems.at(CurrPointer)->Value < val)
			{
				CurrStack = CurrStack->Elems.at(CurrPointer);
			}
			else if (CurrStack->Elems.at(CurrPointer)->Value > val)
			{
				CurrPointer--;
			}
			else if (CurrStack->Elems.at(CurrPointer)->Value == val)
			{
				temp = CurrStack->Elems.at(CurrPointer);
				CurrStack->Elems.at(CurrPointer) = temp->Elems.at(CurrPointer);
				CurrPointer--;
			}
		}
		if (CurrPointer < 0)
		{
			break;
		}
	}
	temp->~SkipListStack();

}

bool SkipListClass::Check(int val)
{
	SkipListStack* CurrStack = startStack;
	int CurrPointer = MaxHeight - 1;

	while (true)
	{
		if (CurrStack->Elems.at(CurrPointer)->isEnd)
		{
			CurrPointer--;
		}
		else
		{
			if (CurrStack->Elems.at(CurrPointer)->Value < val)
			{
				CurrStack = CurrStack->Elems.at(CurrPointer);
			}
			else if (CurrStack->Elems.at(CurrPointer)->Value > val)
			{
				CurrPointer--;
			}
			else if (CurrStack->Elems.at(CurrPointer)->Value == val)
			{
				return true;
			}
		}
		if (CurrPointer < 0)
		{
			break;
		}
	}
	return false;
}

void SkipListClass::ClearList()
{
	SkipListStack* next;
	SkipListStack* curr = startStack;
	while (true)
	{
		if (curr->Elems.at(0) != nullptr)
		{
			next = curr->Elems.at(0);
			curr->~SkipListStack();
			curr = next;
		}
		else
		{
			break;
		}
	}

}

void SkipListClass::Print()
{
	SkipListStack* currStack = startStack->Elems.at(0);
	std::cout << "The Skiplist, rotated by 90 deg" << std::endl;

	while (currStack->isEnd==false) 
	{
		for(int i = 0; i < currStack->Height; i++)
		{
			std::cout << currStack->Value << "\t";
		}
		currStack = currStack->Elems.at(0);
		std::cout << "\n";
	}

}


