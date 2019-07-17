#pragma once
class CountSort
{
private:
	int* SecArr;
	int MaxVal;
	int Cap;
public:
	int* Arr;
	void Sort();
	CountSort(int* arr, int capacity, int maxval);
	int* GetArray();
};

