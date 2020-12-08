using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region условие
//Составить описание класса для определения одномерных массивов строк фиксированной длины. Предусмотреть контроль выхода за
//пределы массива, возможность обращения к отдельным строкам массива по индексам, выполнения операций поэлементного сцепления
//двух массивов с образованием нового массива, слияния двух массивов с исключением повторяющихся элементов, а также вывод на экран
//элемента массива по заданному индексу и всего массива.
#endregion
namespace hw_6._12._2020
{
    class ArrayOfString
    {
        
        string[] arrOfString;
        public ArrayOfString(params string[] strs) => arrOfString = (string[])strs.Clone(); //конструктор с параметром
        public string this[int i] //обращениe к отдельным строкам массива по индексам
        {
            get
            {
                try
                {
                    return arrOfString[i];
                }
                catch
                {
                    return "";
                }
            }
            set {                //как понял из условия, класс определяет одномерный массив строк. Длина этих строк не меняется после записи, но чары в них можно перезаписать. Тут это и реализовано
                if (arrOfString[i].Length <= value.Length)    //
                    arrOfString[i] = (string)value.Remove(arrOfString[i].Length);
                else
                {
                    string str = value;
                    for (int k = 0; k < (arrOfString[i].Length - value.Length); ++k)
                    {
                        str += " ";
                        Console.WriteLine(str.Length);
                    }
                    arrOfString[i] = str;
                    Console.WriteLine(arrOfString[i].Length);
                }
            }
        }
        //добавление элемента
        public void addElement(string str)
        {
            string[] newArr = new string[arrOfString.Length + 1];
            arrOfString.CopyTo(newArr, 0);
            newArr[newArr.Length - 1] = str;
            arrOfString = newArr;
        }
        public int getLenght() => arrOfString.Length;
        public void myConcat(ArrayOfString arr1, ArrayOfString arr2) //операция поэлементного сцепления двух массивов с образованием нового массива
        {
            //string[] newArr = new string[arr1.getLenght() > arr2.getLenght() ? arr1.getLenght() : arr2.getLenght()];
            for (int i = 0; i < (arr1.getLenght() > arr2.getLenght() ? arr1.getLenght() : arr2.getLenght()); ++i)
            {
                this.addElement(arr1[i] + arr2[i]);
            }

        }
        public void myConcatNotRepetitive(ArrayOfString arr1, ArrayOfString arr2) //слияния двух массивов с исключением повторяющихся элементов
        {
            for (int i = 0; i < (arr1.getLenght() > arr2.getLenght() ? arr1.getLenght() : arr2.getLenght()); ++i)
            {
                if (String.Compare(arr1[i], arr2[i]) != 0)
                    this.addElement(arr1[i] + arr2[i]);
                else this.addElement(arr1[i]);
            }
        }
        public void showElementOfArr(int index) //вывод на экран элемента массива по заданному индексу
        {
            Console.WriteLine($"Элемент {index} в данном массиве содержит строку {arrOfString[index]}");
        }
        public void showArr()  //вывод на экран всего массива.
        {
            foreach(string i in arrOfString)
                Console.WriteLine(i);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "InnerException";
            string str2 = "Message";
            string str3 = "try";
            ArrayOfString arrOfStr1 = new ArrayOfString(str1, str3, str3);
            ArrayOfString arrOfStr2 = new ArrayOfString(str1, str2, str3, str1, str2, str3);
            arrOfStr2[4] = "0";
            arrOfStr2[4] = "123456789";
            Console.WriteLine(arrOfStr2[4]);
            arrOfStr1.addElement("grety");
            ArrayOfString arrOfStr3 = new ArrayOfString();
            arrOfStr3.myConcat(arrOfStr1, arrOfStr2);
            ArrayOfString arrOfStr4 = new ArrayOfString();
            arrOfStr4.myConcatNotRepetitive(arrOfStr1, arrOfStr2);
            arrOfStr3.showArr();
            arrOfStr4.showElementOfArr(0);
            
            Console.ReadLine();
        }
    }
}
