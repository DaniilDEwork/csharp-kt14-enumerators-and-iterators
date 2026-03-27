using System;
using System.Collections;
using System.Collections.Generic;

class Fibonacci : IEnumerable<int>
{
    private int count;

    public Fibonacci(int count)
    {
        this.count = count;
    }

    public IEnumerator<int> GetEnumerator()
    {
        int a = 0;
        int b = 1;

        for (int i = 0; i < count; i++)
        {
            yield return a;

            int temp = a + b;
            a = b;
            b = temp;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Matrix
{
    private double[,] data;

    public Matrix(double[,] data)
    {
        this.data = data;
    }

    public IEnumerable<double> GetRow(int index)
    {
        for (int i = 0; i < data.GetLength(1); i++)
        {
            yield return data[index, i];
        }
    }

    public IEnumerable<double> GetColumn(int index)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            yield return data[i, index];
        }
    }
}

class PrimeNumbers : IEnumerator<int>
{
    private int current;

    public PrimeNumbers()
    {
        current = 1;
    }

    public int Current
    {
        get { return current; }
    }

    object IEnumerator.Current
    {
        get { return Current; }
    }

    public bool MoveNext()
    {
        int number = current + 1;

        while (true)
        {
            if (IsPrime(number))
            {
                current = number;
                return true;
            }

            number++;
        }
    }

    public void Reset()
    {
        current = 1;
    }

    public void Dispose()
    {
    }

    private bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Fibonacci");
        Fibonacci fib = new Fibonacci(10);

        foreach (int item in fib)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("2. Matrix");
        double[,] arr =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Matrix matrix = new Matrix(arr);

        Console.WriteLine("Строки:");
        for (int i = 0; i < 3; i++)
        {
            foreach (double item in matrix.GetRow(i))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Столбцы:");
        for (int i = 0; i < 3; i++)
        {
            foreach (double item in matrix.GetColumn(i))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("3. PrimeNumbers");

        PrimeNumbers primes = new PrimeNumbers();
        int count = 0;

        while (count < 10 && primes.MoveNext())
        {
            Console.Write(primes.Current + " ");
            count++;
        }

        Console.ReadLine();
    }
}