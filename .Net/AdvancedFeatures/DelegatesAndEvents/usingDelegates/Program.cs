using usingDelegates;

List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var helper = new FilterHelper();
// .net 1.1, yıl olarak tahmini 2001-2003
var filtered1 = helper.Filter(numbers,isEven);
showNumbers(filtered1);




void showNumbers(List<int> filtered1)
{
    foreach (int number in filtered1) 
    {
        Console.WriteLine(number);
    }
}

bool isEven(int number)
{
    return number % 2 == 0;
}