#include "HeapSort.h"

HeapSort::HeapSort(int* Array, int Capacity)
{
	arr = Array;
	arrMax = Capacity;
}

HeapSort::~HeapSort()
{
}

void HeapSort::Sort(int* a, int f, int l)
{
	BuildHeap(a, f, l);

	for (int i = l; i > f; i--)
	{
		Swap(&a[f], &a[i]);
		Heapify(a, f, i - 1, f);
	}
}

void HeapSort::Sort()
{
	Sort(arr, 0, arrMax - 1);
}

void HeapSort::BuildHeap(int* a, int f, int l)
{
	int n = l - f + 1;
	for (int i = f + (n - 2) / 2; i >= f; i--)
	{
		Heapify(a, f, l, i);
	}
}

void HeapSort::Heapify(int* a, int f, int l, int root)
{
	int max{};
	int left = f + (root - f) * 2 + 1;
	int right = left + 1;
	if (left <= l && a[left] > a[root])
	{
		max = left;
	}
	else
	{
		max = root;
	}
	if (right <= l && a[right] > a[max])
	{
		max = right;
	}

	if (max != root)
	{
		Swap(&a[root], &a[max]);
		Heapify(a, f, l, max);
	}

}

void HeapSort::Swap(int* a, int* b)
{
	int t =a[0];
	a[0] = b[0];
	b[0] = t;
}

int* HeapSort::GetArray() {
	return arr;
}



