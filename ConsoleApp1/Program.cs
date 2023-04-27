
var lst = new List<int>();
lst.Add(1);
lst.Add(2);
lst.Add(3);
var arr = new int[3];
arr[0] = 7;
arr[1] = 8;
arr[2] = 9;
lst.AddRange(arr);
foreach (int value in lst)
{
    Console.WriteLine("Value : {value}", value);

}



