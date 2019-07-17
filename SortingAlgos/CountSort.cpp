#include "CountSort.h"

void CountSort::Sort()
{
	SecArr= new int[MaxVal];
	int k = 0;
	for (int j = 0; j < MaxVal; j++)
	{
		SecArr[j] = 0;
	}

	for (int i = 0; i < Cap; i++)
	{
		SecArr[Arr[i]]++;
		
	}
	for (int i = 0; i < Cap; )
	{
		if (SecArr[k]>0)
		{
			Arr[i] = k;
			SecArr[k]--;
			i++;
		}
		else 
		{
			k++;
		}
	}

	
}

CountSort::CountSort(int* arr, int capacity, int maxval)
{
	Arr = arr;
	Cap = capacity;
	MaxVal = maxval;
	SecArr = new int[maxval];
	for (int i = 0; i < maxval; i++)
	{
		SecArr = 0;
	}
}
int* CountSort::GetArray() {
	return Arr;
}
