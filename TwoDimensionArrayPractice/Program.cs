// See https://aka.ms/new-console-template for more information
using TwoDimensionArrayPractice;

int[,] data = new int[,]
{
{0,1,2},
{3,4,5},
};

Console.WriteLine("20220618.10 寫一個 iterator class ,能簡單的遍歷每一個元素");

var iterator = new TwoDimensionArrayIterator<int>(data);
while (iterator.HasNext())
{
    var item = iterator.Next();
    Console.WriteLine(item.ToString()); // 應該顯示 0, 1, 2, 3, 4, 5
}

Console.WriteLine();
Console.WriteLine("20220618.10 第二題實作一個可以在二維陣列裡移動位置的功能");

var helper = new LocationHelper<int>(data);
var current = helper.SetCurrentLocation(1, 1); // 設定目前位置在[1,1],value=4
Console.WriteLine($"設定目前位置在 {current}");

ArrayItem<int> item1 = helper.MoveRight(1); // 傳回一個表示[1,2], value=5的物件
Console.WriteLine($"在這裡,必需能顯示item1 所在位置, {item1.Location.ToString()}"); // 在這裡,必需能顯示item1 所在位置
Console.WriteLine($"顯示其值,{item1.Value}"); // 顯示其值,5

current = helper.SetCurrentLocation(0, 2); // 設定目前位置在[0,2],value=2
Console.WriteLine($"設定目前位置在 {current}");
bool canMoveUp = helper.CanMoveUp(); // 傳回 false, 因為位置[0,2]已經無法再向上移動
Console.WriteLine($"canMoveUp = {canMoveUp}");
bool canMoveRight = helper.CanMoveRight(); // 傳回 false, 因為位置[0,2]已經無法再向右移動
Console.WriteLine($"canMoveRight = {canMoveRight}");

Console.WriteLine($"回到左上 : {helper.SetCurrentLocation(0, 0)}");
Console.WriteLine($"MoveRight:");
while (helper.CanMoveRight())
    Console.WriteLine(helper.MoveRight());

Console.WriteLine($"MoveDown");
while (helper.CanMoveDown())
    Console.WriteLine(helper.MoveDown());

Console.WriteLine($"MoveLeft");
while (helper.CanMoveLeft())
    Console.WriteLine(helper.MoveLeft());

Console.WriteLine($"MoveUp");
while (helper.CanMoveUp())
    Console.WriteLine(helper.MoveUp());

