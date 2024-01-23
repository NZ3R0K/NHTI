/*
Creating forward slash

X
 X
  X
   X

	 Interactive project created in class with student help
*/

#include <iostream>
using namespace std;

int main()
{
	for (int row = 0; row < 5; row++)
	{
		for (int col = 0; col < 5; col++)
		{
			if (row == col)
			{
				cout << "X";
			}
			else
			{
				cout << " ";
			} //end if
		} //end inner for

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