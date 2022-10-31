using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp15
{

    class MyClass
    {
        public string name;
        public int age;
        public double height;
         
    }

    class BirthdayInfo
    {
        public string name { get; private set; }
        public DateTime birthday { get; private set; }

        public string Name => name;
        public DateTime Birthday => birthday;

        public int Age => new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
        public BirthdayInfo(string name, DateTime birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
      
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 무명형식
            if (false)
            {

            //프로퍼티를 통해 객체를 초기화하는 방법
            MyClass myClass = new MyClass() { name = "월요일", age = 24 };
            
            //생성자를 통해 객체를 초기화하는 방법
            BirthdayInfo  birthday = new BirthdayInfo("월요일", new DateTime(1999, 1, 1));

            Console.WriteLine($"name : {birthday.name}");
            Console.WriteLine($"birthday:{birthday.birthday.ToShortDateString()}");        
            Console.WriteLine($"Age:{birthday.Age}");

            //무명 형식(Anonymous Type)
            //우리가 잘 아는 기본형식 int ,float같이 형식에는 이름이 있어야한다.
            //하지만 이름이 없는 형식도있다.

            //var 형식
            // =>들어오는 값에 의해 프로그램이 형식을 유추한다.
            var myInstance = new { Name = "월요일",Age =24};
            Console.WriteLine($"Name{myInstance.Name}, Age{myInstance.Age}");

            }
            #endregion

            if (false)
            {


            MyClass[] profiles =
            {
                new MyClass() {name =":월요일", age = 20, height = 170.5f}, 
                new MyClass() {name =":화요일", age = 26, height = 150.8f}, 
                new MyClass() {name =":수요일", age = 17, height = 160.9f}, 
                new MyClass() {name =":목요일", age = 9, height = 124.7f}, 
                new MyClass() {name =":토요일", age = 15, height = 150.6f},             
            };

            var profileList = profiles.Where(p => p.height >= 150f).OrderBy(p => p.height).ToList();
            foreach (var profile in profileList)
                Console.WriteLine($"{profile.name}({profile.height.ToString()}");

            //if문과  List의 
          
                //키가 150 이상인 사람을 뽑아  컬렉션으로 만들기.
                //단 순서는 오름차순으로 만들기 
                //profiles(접근)
                List<MyClass> list = new List<MyClass>();
                for(int i =0; i<profiles.Length; i++)
                {
                    if(profiles[i].height >= 150)
                    {
                        list.Add(profiles[i]);
                    }
                }


                //Sort는 delegate인 Comparison을 매개변수로 받는다.
                //즉 "int Comparison<T>(T,x,T,y)형 함수를 대입해야한다.
                //delegete int Comparison(MyClass x, MyClass y)

                list.Sort((a, b) => {
                    if (a.height < b.height)
                        return -1;
                    else if (a.height > b.height)
                        return 1;
                    else
                        return 0;
                }); 
            
                foreach(MyClass profile in list)
                {
                    Console.WriteLine(profile.name);
                }
            

            //from 절
            // = 시작 부분. 대상을 하나씩 받아온다.

            //where절
            //= 필터,특정 조건에 맞는 변수만 거른다.

            //select절
            //최종적으로 어떠한 데이터를 반환할 것인가. 

            //링크문을 사용하려면 데이터가 IEunumable을 구현하고 있어야 한다.
            
            // pofiles는 Array<T>형이고 IEnumerable<T>를 구현하고 있다,
            //Linq 쿼리문이 마지막으로 반환하는 자료형은 IEnumable<T>다.
          

            var search = from profile in profiles           //profiles배열에서 값을 하나씩 가져온다.
                         where profile.height > 150         //해당 값의 height가 150을 넘어야한다.
                         orderby profile.height             //height를 기준으로 오름차순으로 정렬.
                         select profile;                    //마지막으로  profile 그 자체를 값으로 보낸다.
             foreach(var p in search)
             {
                Console.WriteLine($"name:{p.name},height:{p.height},");
             }
            
            }

            ItemDB itemDB = new ItemDB();
            Item[] searchItems = itemDB.GetItem("카타나");

            string[] name = ();
            int level = 30;
            



            Console.WriteLine($"{name},{level}");
            Console.WriteLine("-----------------------");
            Console.WriteLine($" {name.Length}");


            
        }
    }
}
