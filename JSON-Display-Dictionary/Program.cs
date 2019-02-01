using System;
using JKJsonDecode;

namespace JSON_Display_Dictionary
{
    class Program
    {
        public static string[] Links = new string[]
        {
            "http://uinames.com/api/?amount=3", //Simple List
            "https://reqres.in/api/users?page=2", //Dictionary
            "https://jsonplaceholder.typicode.com/users" //Complex List
        };

        static void Main(string[] args)
        {
            DemoList(Links[0]);
            DemoDict(Links[1]);
            DemoList(Links[2]);
        }

        public static void DemoDict(string url)
        {
            //Dictionary

            //View raw JSON
            Console.WriteLine(JKJson.Deserialized(url));

            //Its a dictionary, you can loop through this now and find keys and values
            Console.WriteLine(JKJson.DictOut(JKJson.Deserialized(url)));

            //See...
            //First check what property holds the array - then treat it like a list, because it is one
            //Access the properties, by accessing the index of the list and then the property
            Console.WriteLine(JKJson.DictOut(JKJson.Deserialized(url))["data"][0]["first_name"]);
        }

        public static void DemoList(string url)
        {
            //List

            //View raw JSON
            Console.WriteLine(JKJson.Deserialized(url));

            //Its a list, you can loop through this now
            Console.WriteLine(JKJson.ListOut(JKJson.Deserialized(url)));

            //See...
            //Access the properties, by accessing the index of the list and then the property
            Console.WriteLine(JKJson.ListOut(JKJson.Deserialized(url))[0]["name"]);
        }
    }
}
