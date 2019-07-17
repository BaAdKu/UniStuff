#pragma once
class HeapSort
{
private:
	int arrMax;
	void BuildHeap(int* a, int f, int l);
	
	void Heapify(int *a, int f, int l, int i);
	void Swap(int* a, int* b);
	void Sort(int *a, int f, int l);

public:
	int* GetArray();
	int* arr;
	HeapSort(int *Array, int Capacity);
	~HeapSort();
	void Sort();
};

