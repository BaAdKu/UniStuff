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
	for (int i = 0; i < Cap; i++)
	{
		if (SecArr[k]>0)
		{
			Arr[i] = k;
			SecArr[k]--;
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
}
