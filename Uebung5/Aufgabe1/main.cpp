#include <iostream>
#include <vector>

void swap(std::vector<int> &a, int first, int second);
void Heapify(std::vector<int> &a, int f, int l, int root);
void BuildHeap(std::vector<int> &a, int f, int l);
void HeapSort(std::vector<int> &a, int f, int l);
void PrintVector(std::vector<int> a);

int main()
{
    std::vector<int> a{-5, 13, -32, 7, -3, 17, 23, 12, -35, 19};
    HeapSort(a, 0, a.size()-1);
    return 0;
}

void swap(std::vector<int> &a, int first, int second)
{
    int h{a.at(second)};
    a.at(second) = a.at(first);
    a.at(first) = h;
}

void Heapify(std::vector<int> &a, int f, int l, int root)
{
    int largest{}, left{f+(root - f) * 2+1}, right{f+(root-f)*2+2};
    if (left <= l && a.at(left)>a.at(root))
    {
        largest = left;
    }
    else
    {
        largest = root;
    }

    if(right <= l && a.at(right)>a.at(largest))
    {
        largest = right;
    }

    if(largest != root)
    {
        swap(a, root, largest);
        Heapify(a, f, l, largest);
    }
}

    void BuildHeap(std::vector<int> &a, int f, int l)
    {
        int n{l-f+1};
        for (int i = f + (n - 2)/2; i >= f ; i--)
        {
            Heapify(a, f, l, i);
        }
    }

    void HeapSort(std::vector<int> &a, int f, int l)
    {
        BuildHeap(a, f, l);
        PrintVector(a);
        for (int i = l; i > f; i--)
        {
            swap(a, f, i);
            Heapify(a, f, i-1, f);
            PrintVector(a);
        }
    }

void PrintVector(std::vector<int> a)
{
    for (int i = 0; i < a.size(); i++)
    {
        std::cout << a.at(i) << " ";
    }
    std::cout << std::endl;
}