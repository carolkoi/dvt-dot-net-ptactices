// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//LinqTestOne();
using System.Text;

//LinqTest2();
//PasswordCreation();
//CommonString();
//StringFrom2Arrays();
//ReverseString();
//ArrayElemsRation();
//MinMaxArrayValue();
//TwelveHrTo24HrConvert();
//FindMedian();
//LonelyInteger();
//MultidimensioanlArray();
//SpiralMatrix();
//EvenOddNumberArrangement();
SpiralListArrangement();

static void LinqTestOne()
{
    int[] scores = { 60, 35, 57, 90, 100 };

    IEnumerable<int> scoreQuery = from score in scores
                                  where score > 50
                                  orderby score descending
                                  select score;

    int count = (from score in scores
                where score > 50
                
                select score).Count();

    foreach (int score in scoreQuery)
    {
        Console.Write(score + "\t");
    }
    Console.WriteLine($"The number of scores greater than 50 is {count}");
}

static void LinqTest2()
{
    List<Category> categories = new List<Category>()
{
    new Category() { Name= "Beverages", ID= "001"},
    new Category() { Name= "Condiments", ID= "002" },
    new Category() { Name= "Vegetables", ID= "003" },
    new Category() { Name= "Grains", ID= "004" },
    new Category() { Name= "Fruit", ID= "005" },
    };

    List<Product> products = new List<Product>()
{
    new Product () {Name = "Cola", CategoryID = "001" },
    new Product(){Name="Tea", CategoryID="001"},
    new Product(){Name="Mustard", CategoryID="002"},
    new Product(){Name="Pickles", CategoryID="002"},
    new Product(){Name="Carrots", CategoryID="003"},
    new Product(){Name="Bok Choy", CategoryID="003"},
    new Product(){Name="Peaches", CategoryID="005"},
    new Product(){Name="Melons", CategoryID="005"},
};

    var groupJoinQuery2 =
        from category in categories
        join prod in products on category.ID equals prod.CategoryID into prodGroup
        orderby category.Name
        select new
        {
            Category = category.Name,
            Products =
                from prod2 in prodGroup
                orderby prod2.Name
                select prod2
        };

    foreach (var productGroup in groupJoinQuery2)
    {
        Console.WriteLine(productGroup.Category);
        foreach (var prodItem in productGroup.Products)
        {
            Console.WriteLine($"  {prodItem.Name,-10} {prodItem.CategoryID}");
        }
    }

    /* Output:
        Beverages
          Cola       1
          Tea        1
        Condiments
          Mustard    2
          Pickles    2
        Fruit
          Melons     5
          Peaches    5
        Grains
        Vegetables
          Bok Choy   3
          Carrots    3
     */
}

static void PasswordCreation()
{
    string a = "Wangui";
    string b = "Carol";

    //declare a string builder
    StringBuilder sb = new StringBuilder();

    if(a.Length < b.Length)
    {
        for(int i= 0; i < a.Length; i++)
        {
            sb.Append(a[i]);
            sb.Append(b[i]);

        }
        //get remaining characters
        var result = b.Substring(b.Length - (b.Length - a.Length));
        sb.Append(result);

    }else if(a.Length == b.Length)
    {
        for (int i = 0; i < a.Length; i++)
        {
            sb.Append(a[i]);
            sb.Append(b[i]);

        }
    }else if (b.Length < a.Length)
    {
        for (int i = 0; i < b.Length; i++)
        {
            sb.Append(a[i]);
            sb.Append(b[i]);

        }
        //get remaining characters
        var result = a.Substring(a.Length - (a.Length - b.Length));
        sb.Append(result);
    }
    



    Console.WriteLine(a.Length+ " " + b.Length + " " + sb.ToString());
        


}

static void CommonString()
{
    List<string> a = new List<string>() {"ab","eb","wu" };
    List<string> b = new List<string>() {"af", "gt", "wu" };
    //iterate the two lists with same index
    for(int i = 0; i < a.Count; i++)
    {
        string s1 = a[i];
        //split first string
        for(int j = 0; j < s1.Length; j++)
        {
            string s2 = b[i];
            if (s2.Contains(s1[j]))
            {
                Console.WriteLine("YES");
            }
            else
                Console.WriteLine("NO");
        }



    }


}

static void StringFrom2Arrays(){
    string[] a = new string[] { "abc", "def" };
    string[] b = new string[] { "ghi", "jkl" };

    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < a.Length; i++)
    {
        string c = a[i];
        string d = b[i];
        for(int j = 0; j < c.Length; j++)
        {
            sb.Append(c[j]);
            sb.Append(d[j]);
        }
    }
    Console.WriteLine(sb.ToString());

}

static void ReverseString()
{
    string a = "Carol";
    //convert to CharArray
    char[] b = a.ToCharArray();
    Array.Reverse(b);
    Console.WriteLine(b);

}

static void ArrayElemsRation()
{
    int[] ints = new int[] {1, 1, 0, -1, -1};
    int pos = 0;
    int neg = 0;
    int zero = 0;
   for(int i = 0; i < ints.Length; i++)
    {
        if(ints[i] > 0)
        {
            pos++;
        }else if(ints[i] < 0)
        {
            neg++;
        }else if (ints[i] == 0)
        {
            zero++;
        }
    }
    Console.Write(pos + "\t" + neg + "\t" + zero);
    Console.WriteLine();

    //positive ratio
    string positive = ((decimal)pos / (decimal)ints.Length).ToString("N6");
   

    string negative = ((decimal)neg / (decimal)ints.Length).ToString("N6");
    string zeroi = ((decimal) zero/ (decimal)ints.Length).ToString("N6");
    Console.Write(positive + "\n" + negative + "\n" + zeroi);
    



}
static void MinMaxArrayValue()
{
    List<int> result = new List<int>() { 256741038, 623958417, 467905213, 714532089, 938071625 };
    //convert the list to array

    //int[] nums = a.ToArray();

    ////sort array to asc
    //Array.Sort(nums);
    //List<int> result = nums.ToList();
    //sort list

    result.Sort();
    //Console.WriteLine("My sorted list : " + result);

    //get the first 4 elements of the list and sum them
    int sum = 0;
    for(int i = 0; i < result.Count - 1 ; i++)
    {
        sum +=result[i];
    }
    Console.WriteLine("Min value is : " + sum);

    //get the last 4 elements and sum the m

    long max = 0;
    for(int j = 1; j < result.Count; j++)
    {
        max += result[j];
    }

    Console.WriteLine("Max value is : " + max);
    Console.Write(sum + "\t" + max);




}

static void TwelveHrTo24HrConvert()
{
    string SampleTime = "08:05:45 PM";
    bool res = DateTime.TryParse(SampleTime, out DateTime dt);
    if (res)
    {
        string myTime = dt.ToString("HH:mm:ss");
        Console.WriteLine(myTime);
    }

}

static void FindMedian()
{
    int? median = null;
    List<int> arr = new List<int>() { 2, 5, 4, 0, 1, 6, 3};
     arr.Sort();
    int len = arr.Count;

    for(int i = 0, j = len - 1; i < len ; i++, j--)
    {
        if (i == j)
        {
            median = arr[i];

        }

    }
    Console.WriteLine(median);

}

static int LonelyInteger()
{
    List<int> arr = new List<int>() { 1, 2, 3, 4, 3, 2, 1};
    int count = 0;
    int? LonelyInt = null;
    //use two loops, in and out loop
    //outer loop picks each element
    //int j = 0;
    for (int j = 0; j < arr.Count; j++)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[j].Equals(arr[i]))
            {
                count++;
                //LonelyInt = arr[j];
            }



        }
        if (count == 1)
        {
            //Console.WriteLine("Element : " + LonelyInt + " has appearred " + count + " times");
            //return (int)LonelyInt;
            LonelyInt = arr[j];
            break;

        }
        else
        {
            //reset the count to 0 for the next iteration
            count = 0;
            

        }
    }
    Console.WriteLine("Element : " + LonelyInt + " has appearred " + count + " times");


    return (int)LonelyInt;

}

static void MultidimensioanlArray()
{
    int[,] numbers = { 
        { 2, 3, 9 }, 
        { 4, 5, 9 },
        { 10,11,12 }
    };
    int rank = numbers.Rank;
    int i = numbers.GetLength(0);
    int j = numbers.GetLength(1);

    Console.WriteLine( rank + " " +i + " " + j);

    for (int x = 0; x < i; x++)
    {
        Console.Write("Row " + x + ": ");
        for (int y = 0; y < j; y++)
        {
            Console.Write(numbers[x, y] + " ");
        }
        Console.WriteLine();
    }
    //left->right diagonal
    //column index
    int b = 0;
    //diagonal sum
    int sum1 = 0;

    //int[] nums = new int[i];
    Console.WriteLine("left->right diagonal");
    for (int a = 0; a < i; a++)
    {
        Console.Write( numbers[a,b] + " ");
        sum1+=numbers[a,b];
        b++;
        //Console.Write();
        
    }
    Console.WriteLine("left->right diagonal summation: " + sum1);

    //Console.WriteLine();


    //right->left diagonal
    //column index
    int c = j-1;
    //diagonal sum
    int sum2 = 0;
    //int[] nums = new int[i];
    Console.WriteLine("right->left diagonal");
    for (int a = 0; a < i; a++)
    {
        Console.Write(numbers[a, c] + " ");
        sum2+=numbers[a,c];
        c--;
        //Console.Write();

    }
    Console.WriteLine("right->left diagonal summation: " + sum2);
    int absDiff = Math.Abs(sum1 - sum2);
    Console.WriteLine("Absolute Difference: " + absDiff);




}

static void JaggedArray()
{
    int[][] jaggedArray = 
        {
    new int[ ] {11, 2, 4},
    new int[ ] {4, 5, 6},
    new int[ ] { 10, 8, - 12 }
        };

    //first diagonal
    //first column index
    int x = 0;
    //sum
    int sum = 0;
    for(int i =0; i<jaggedArray.Length; i++)
    {
        Console.Write(jaggedArray[i][x] + " ");
        sum+=jaggedArray[i][x];
        x++;
    }
    Console.WriteLine();
    Console.Write(sum);

    Console.WriteLine();


    //second diagonal
    //coulumn index
    int y = jaggedArray[0].Length - 1;
    //sum
    int sum1 = 0;

    for (int i = 0; i < jaggedArray.Length; i++)
    {
        Console.Write(jaggedArray[i][y] + " ");
        sum1+= jaggedArray[i][y];
        y--;

    }
    Console.WriteLine();
    Console.Write(sum1);
    Console.WriteLine();



    //Absolue difference 
    int absDiff = Math.Abs(sum - sum1);
    Console.WriteLine("Absoulute Diffrerence : " + absDiff);
}

static void SpiralMatrix()
{
    //print the elements in a spiral 
    int[][] jaggedArray =
        {
    new int[ ] { 1, 2, 3, 4, 5},
    new int[ ] {16, 17, 18, 19, 6},
    new int[ ] {15, 24, 25, 20, 7},
    new int[ ] {14, 23, 22, 21, 8},
    new int[ ] {13, 12, 11, 10, 9}
        };
    //11,2,4,6,-12,8,10,4,5

   
    for(int i = 0; i < jaggedArray.Length; i++)
    {
        for(int j = 0; j < jaggedArray[i].Length; j++)
        {
            Console.Write(jaggedArray[i][j] + " ");
            //11,2,4,4,5,6,10,8,12
        }
    }
    Console.WriteLine();
    //printing the elements in a spiral, we need 4 loops
    // each for the top, right, bottom, and left corner of the matrix
    //increments the row, 
    int rowIndex = 0;
    //increments the column
    int colIndex = 0;
    //
    int rowSize = jaggedArray.Length - 1;
    int colSize = jaggedArray[0].Length - 1;
    while (rowIndex <= rowSize && colIndex <= colSize)
    {
       
        //print first row
        for(int i =colIndex; i <= colSize; i++)
        {
            Console.Write(jaggedArray[rowIndex][i] + " ");
        }
        //increment the row
        rowIndex++;
        //rowIndex= 1

      
        //print right column
        for (int i = rowIndex; i <= rowSize; i++)
        {
            Console.Write(jaggedArray[i][colSize] + " ");
        }
        colSize--;

        //print bottom row
        for (int i = colSize; i >= colIndex; i--)
        {
            Console.Write(jaggedArray[rowSize][i] + " ");
        }
        rowSize--;

        //print left column
        for(int i = rowSize; i >= rowIndex; i--)
        {
            Console.Write(jaggedArray[i][colIndex] + " ");
        }
        colIndex++;
        


    }

}

static void EvenOddNumberArrangement()
{
    //print the elements in even-odd or odd-even order 
    int[] arr = { 31, 11, 16, 45, 9, 10, 8, 2, 5,12 };
    //output: 31,16,11,10,45,8, 9,2,5,12

    //find all odd elements

    var oddArr = Array.FindAll(arr, x => x%2 != 0);
    var EvenArr = Array.FindAll(arr, x => x%2 == 0);

    for(int i = 0; i < oddArr.Length; i++)
    {
        Console.Write(oddArr[i] + " " + EvenArr[i] + " ");
    }

}

static void SpiralListArrangement()
{
    List<List<int>> sample = new List<List<int>>()
    { 
    new List<int> { 1, 2, 3, 4, 5},
    new List<int>  {16, 17, 18, 19, 6},
    new List<int>  {15, 24, 25, 20, 7},
    new List<int>  {14, 23, 22, 21, 8},
    new List<int>  {13, 12, 11, 10, 9}
    };

    //print elements in a spiral order
    //we use 4 indices for top, left, bottom, right corner

    //top index: tracks the rows from left->right starting from top row
    //, bottom index is the size of the rows
    int top = 0, bottom = sample.Count - 1;

    ///left index: tracks number of columns 
    ///right index is the size of columns
    int left = 0, right = sample[0].Count - 1;

    while (top <= bottom && left <= right)
    {

        //print the top row, increment the column, maintain the row

        for (int i = left; i <= right; i++)
        {
            Console.Write(sample[top][i] + " ");
        }
        //increment the row
        top++;
   

        //print right column, increment the row, maintain column(column size)
        for (int i = top; i <= bottom; i++)
        {
            Console.Write(sample[i][bottom] + " ");
        }
        //decrement the column size
        right--;

        //print the bottom row, decrement the column, maintain row (row size)
        for (int i = right; i >= left; i--)
        {
            Console.Write(sample[bottom][i] + " ");
        }
        //decrement the row
        bottom--;

        //print left column, decrement the row, maintain column
        for (int i = bottom; i >= top; i--)
        {
            Console.Write(sample[i][left] + " ");
        }
        //increment column
        left++;
    }

}

static void AlternateSortAlg()
{
    int[] arr = { 1, 1, 3, 2, 1 };

    //all values are in the range [0...3]

    int[] result = { 0, 0, 0, 0 };
    ///Each time a value occurs in the original array, you increment the counter at that index. At the end, 
    ///run through your counting array, printing the value of each non-zero valued index that number of times.
    int count = 0;

    for(int i = 0; i < arr.Length; i++)
    {

    }

}

internal class Product
{
    public string Name { get; set; }
    public string CategoryID { get; set; }
}

internal class Category
{
    public string Name { get; set; }
    public string ID { get; set; }
}

