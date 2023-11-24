using System;

class Program
{

    // Celkově musím říci, že bez používání internetu a různých fórumu bych se určite neobešel. Open AI mi také pomohlo, ale jenom tam kde jsem to zmínil.
    static void Main()
    {
        Console.WriteLine("Vitejte v programu pro maticove operace!");

        int[,] matrixA, matrixB;
        int rowsA, colsA, rowsB, colsB;

        // Zadání velikosti první matice
        Console.Write("Zadejte pocet radku prvni matice: ");
        rowsA = int.Parse(Console.ReadLine());
        Console.Write("Zadejte pocet sloupcu prvni matice: ");
        colsA = int.Parse(Console.ReadLine());

        // Vytvoření a naplnění první matice
        matrixA = CreateMatrix(rowsA, colsA);
        FillMatrixRandomly(matrixA);

        // Zadání velikosti druhé matice
        Console.Write("Zadejte pocet radku druhe matice: ");
        rowsB = int.Parse(Console.ReadLine());
        Console.Write("Zadejte pocet sloupcu druhe matice: ");
        colsB = int.Parse(Console.ReadLine());

        // Vytvoření a naplnění druhé matice
        matrixB = CreateMatrix(rowsB, colsB);
        FillMatrixRandomly(matrixB);
        PrintMatrix(matrixA);
        Console.WriteLine('\n');
        PrintMatrix(matrixB);
        // Menu pro maticové operace
        while (true)
        {
            Console.WriteLine("\nVyberte operaci:");
            Console.WriteLine("1. Vynasobit matice");
            Console.WriteLine("2. Prohazovat prvky, radky nebo sloupce");
            Console.WriteLine("3. Otacet poradi prvku na diagonalach");
            Console.WriteLine("4. Vynasobit matici cislem");
            Console.WriteLine("5. Scitat nebo odcitat dve matice");
            Console.WriteLine("6. Transpozice matice");
            Console.WriteLine("7. Konec programu");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    MultiplyMatrices(matrixA, matrixB);
                    break;
                case 2:
                    SwapRowsColsElements(matrixA);
                    break;
                case 3:
                    RotateDiagonals(matrixA);
                    break;
                case 4:
                    MultiplyMatrixByScalar(matrixA);
                    break;
                case 5:
                    AddOrSubtractMatrices(matrixA, matrixB);
                    break;
                case 6:
                    TransposeMatrix(matrixA);
                    break;
                case 7:
                    Console.WriteLine("Program ukoncen.");
                    return;
                default:
                    Console.WriteLine("Neplatna volba, zvolte znovu.");
                    break;
            }
        }
    }

    // Funkce pro vytvoření matice
    static int[,] CreateMatrix(int rows, int cols)
    {
        return new int[rows, cols];
    }

    // Funkce pro naplnění matice náhodnými čísly
    static void FillMatrixRandomly(int[,] matrix)
    {
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(1, 10);
            }
        }
    }
    // funkce pro výpis matice
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    // Funkce pro sčítání nebo odčítání dvou matic
    static void AddOrSubtractMatrices(int[,] matrixA, int[,] matrixB)
    {
        Console.WriteLine("Vyberte operaci:");
        Console.WriteLine("1. Scitat matice");
        Console.WriteLine("2. Odcitat matice");

        int choice = int.Parse(Console.ReadLine());

        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);

        int[,] resultMatrix = new int[rows, cols];

        switch (choice)
        {
            case 1:
                // Sčítání matic
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                }
                Console.WriteLine("Vysledek scitani matic:");
                PrintMatrix(resultMatrix);
                break;
            case 2:
                // Odčítání matic
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        resultMatrix[i, j] = matrixA[i, j] - matrixB[i, j];
                    }
                }
                Console.WriteLine("Vysledek odcitani matic:");
                PrintMatrix(resultMatrix);
                break;
            default:
                Console.WriteLine("Neplatna volba.");
                break;
        }
    }
    
    // Funkce pro prohazování prvků, řádků nebo sloupců
    // Tady to dělám pouze u té první matice, matrixA
    static void SwapRowsColsElements(int[,] matrix)
    {
        Console.WriteLine("Vyberte operaci:");
        Console.WriteLine("1. Prohazovat prvky");
        Console.WriteLine("2. Prohazovat radky");
        Console.WriteLine("3. Prohazovat sloupce");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                // Prohazování prvků
                Console.Write("Zadejte prvni index radku: ");
                int row1 = int.Parse(Console.ReadLine());
                Console.Write("Zadejte prvni index sloupce: ");
                int col1 = int.Parse(Console.ReadLine());
                Console.Write("Zadejte druhy index radku: ");
                int row2 = int.Parse(Console.ReadLine());
                Console.Write("Zadejte druhy index sloupce: ");
                int col2 = int.Parse(Console.ReadLine());

                SwapElements(matrix, row1, col1, row2, col2);
                Console.WriteLine("Matice po prohazování prvků:");
                PrintMatrix(matrix);
                break;
            case 2:
                // Prohazování řádků
                Console.Write("Zadejte prvni index radku: ");
                int rowA = int.Parse(Console.ReadLine());
                Console.Write("Zadejte druhy index radku: ");
                int rowB = int.Parse(Console.ReadLine());

                SwapRows(matrix, rowA, rowB);
                Console.WriteLine("Matice po prohazovani radku:");
                PrintMatrix(matrix);
                break;
            case 3:
                // Prohazování sloupců
                Console.Write("Zadejte prvni index sloupce: ");
                int colX = int.Parse(Console.ReadLine());
                Console.Write("Zadejte druhy index sloupce: ");
                int colY = int.Parse(Console.ReadLine());

                SwapColumns(matrix, colX, colY);
                Console.WriteLine("Matice po prohazovani sloupcu:");
                PrintMatrix(matrix);
                break;
            default:
                Console.WriteLine("Neplatna volba.");
                break;
        }
    }

    // Funkce pro otáčení prvků na diagonálách
    // Pouze na matrixA
    static void RotateDiagonals(int[,] matrix)
    {
        Console.WriteLine("Zadejte cislo diagonaly (1 pro hlavni diagonalu, 2 pro vedlejsi diagonalu): ");
        int diagonal = int.Parse(Console.ReadLine());

        RotateDiagonalElements(matrix, diagonal);

        Console.WriteLine("Matice po otacení diagonaly:");
        PrintMatrix(matrix);
    }

    // Funkce pro prohazování prvků
    // Pouze na matrixA
    static void SwapElements(int[,] matrix, int row1, int col1, int row2, int col2)
    {
        int temp = matrix[row1, col1];
        matrix[row1, col1] = matrix[row2, col2];
        matrix[row2, col2] = temp;
    }

    // Funkce pro prohazování řádků
    // Pouze na matrixA
    static void SwapRows(int[,] matrix, int rowA, int rowB)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            SwapElements(matrix, rowA, i, rowB, i);
        }
    }

    // Funkce pro prohazování sloupců
    // Pouze na matrixA
    static void SwapColumns(int[,] matrix, int colX, int colY)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SwapElements(matrix, i, colX, i, colY);
        }
    }

    // Funkce pro otáčení prvků na diagonálách
    // Pouze na matrixA
    // Tady jsem se radil s Open AI o tom co se týče tý vedlejší diagonály, protože ono mi to prohazuje nějak divně dvě diagonály najednou a nechápu proč, nebo nad tím sedím už dlouho a nemyslí mi to(
    static void RotateDiagonalElements(int[,] matrix, int diagonal)
    {
        int size = matrix.GetLength(0);

        if (diagonal == 1)
        {
            for (int i = 0; i < size / 2; i++)
            {
                for (int j = i; j < size - 1 - i; j++)
                {
                    SwapElements(matrix, i, j, size - 1 - j, size - 1 - i);
                    SwapElements(matrix, i, j, j, i);
                }
            }
        }
        else if (diagonal == 2)
        {
            for (int i = 0; i < size / 2; i++)
            {
                for (int j = 0; j < size / 2; j++)
                {
                    if (i + j < size / 2)
                    {
                        SwapElements(matrix, i, j, size - 1 - j, i);
                        SwapElements(matrix, size - 1 - i, size - 1 - j, j, size - 1 - i);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Neplatne cislo diagonaly.");
        }
    }

    // Funkce pro transpozici matice
    // Tady také, pouze pro matrixA, jen pro tu 1.
    static void TransposeMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] transposedMatrix = new int[cols, rows];

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                transposedMatrix[i, j] = matrix[j, i];
            }
        }

        Console.WriteLine("Transponovana matice:");
        PrintMatrix(transposedMatrix);
    }
    static void MultiplyMatricesOrScalar(int[,] matrixA, int[,] matrixB)
    {
        Console.WriteLine("Vyberte operaci:");
        Console.WriteLine("1. Nasobit dve matice");
        Console.WriteLine("2. Nasobit matici cislem");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                // Násobení dvou matic
                MultiplyMatrices(matrixA, matrixB);
                break;
            case 2:
                // Násobení matice číslem
                MultiplyMatrixByScalar(matrixA);
                break;
            default:
                Console.WriteLine("Neplatna volba.");
                break;
        }
    }

    // Funkce pro násobení matice číslem
    // Pouze pro matrixA
    static void MultiplyMatrixByScalar(int[,] matrix)
    {
        Console.Write("Zadejte cislo, kterym chcete vynasobit matici: ");
        int scalar = int.Parse(Console.ReadLine());

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] resultMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultMatrix[i, j] = matrix[i, j] * scalar;
            }
        }

        Console.WriteLine("Matice po vynasobení cislem:");
        PrintMatrix(resultMatrix);
    }

    // Funkce pro násobení dvou matic
    // Tady mi pomohl Izibalo(YouTube) vysvětlit jak se to násobí, a pak jsem se zeptal OpenAI na nějaký přiklad jak by to mohlo vypadat a podle toho jsem se zařídil
    static void MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);

        // Kontrola matic pro násobení
        if (colsA != rowsB)
        {
            Console.WriteLine("Nelze provest nasobeni matic, protoze pocet sloupcu prvni matice neni roven poctu radku druhe matice.");
            return;
        }

        int[,] resultMatrix = new int[rowsA, colsB];

        // Násobení matic
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        Console.WriteLine("Vysledek nasobeni matic:");
        PrintMatrix(resultMatrix);
    }

}

