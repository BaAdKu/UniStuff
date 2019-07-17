// SortingAlgos.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include <iostream>
#include "HeapSort.h"
#include "CountSort.h"


using namespace std;
int main()
{
	int ch;
	int Arr[200];
	int max = 200;
	int maxVal = 100;
	srand(time_t(NULL));


	for (int i = 0; i < max; i++)
	{
		Arr[i] = rand() % maxVal;
	}

	cout << "He-lo Wurrrrld!\n";
	cout << "Please Choose a sorting Algo: 1 for HeapSort, 2 for CountSort, 3 for Exit\n";
	cin >> ch;

	switch (ch)
	{
	case 1:
	{
		HeapSort heap = HeapSort(Arr, max);
		heap.Sort();
		for (int i = 0; i < max; i++)
		{
			cout << heap.arr[i] << "\t";
			if (i % 10 == 0 && i != 0)
			{
				cout << "\n";
			}

		}
		break;
	}
	case 2: {
		CountSort count = CountSort(Arr, max, maxVal);
		count.Sort();
		for (int i = 0; i < max; i++)
		{
			cout << count.Arr[i] << "\t";
			if (i % 10 == 0 && i != 0)
			{
				cout << "\n";
			}

		}
		break;
	}
	case 3:
		break;
	default:
		break;
	}
	cout << "KTHXBYE\n";
	system("Pause");
}

// Programm ausführen: STRG+F5 oder "Debuggen" > Menü "Ohne Debuggen starten"
// Programm debuggen: F5 oder "Debuggen" > Menü "Debuggen starten"

// Tipps für den Einstieg: 
//   1. Verwenden Sie das Projektmappen-Explorer-Fenster zum Hinzufügen/Verwalten von Dateien.
//   2. Verwenden Sie das Team Explorer-Fenster zum Herstellen einer Verbindung mit der Quellcodeverwaltung.
//   3. Verwenden Sie das Ausgabefenster, um die Buildausgabe und andere Nachrichten anzuzeigen.
//   4. Verwenden Sie das Fenster "Fehlerliste", um Fehler anzuzeigen.
//   5. Wechseln Sie zu "Projekt" > "Neues Element hinzufügen", um neue Codedateien zu erstellen, bzw. zu "Projekt" > "Vorhandenes Element hinzufügen", um dem Projekt vorhandene Codedateien hinzuzufügen.
//   6. Um dieses Projekt später erneut zu öffnen, wechseln Sie zu "Datei" > "Öffnen" > "Projekt", und wählen Sie die SLN-Datei aus.
