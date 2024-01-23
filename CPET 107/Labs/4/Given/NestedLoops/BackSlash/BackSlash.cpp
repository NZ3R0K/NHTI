/*
Creating backslash

   X
  X
 X
X

	 This should follow forward slash example

	 Interactive project created in class with student help

	 Once this is accomplish walk them through the concept of:

	 if it row 0 or row 3 we want all Xs
	 else if it is the row location designated with a print; print an X
	 else print a space
*/

#include <iostream>
using namespace std;

int main()
{
	int row, col;
	int print = 4;

	for (row = 0; row < 5; row++)
	{
		for (col = 0; col < 5; col++)
		{
			if (print == col)
			{
				cout << "X";
			}
			else
			{
				cout << " ";
			} //end if
		} //end inner for

		print--;
		cout << endl;
	} //end outer for

	system("pause");
	return 0;
}

/* proof
   X
  X
 X
X
*/