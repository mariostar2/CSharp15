using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp15
{
    enum JOB 
    {
        Warrior,
        Archor,
        Mage,
        Chief,
    }

    class Item
    {
        public string name;
        public int level;
        public JOB job;
        public int power;

        public Item(string name,int level, JOB job ,int power)
        {
            this.name = name;
            this.level = level;
            this.job = job;
            this.power = power;
            
        }
    }

    internal class ItemDB
    {
        List<Item> itemlist;
        
        public ItemDB()
        {
            itemlist = new List<Item>();
            itemlist.Add(new Item("크레르크세스의 레드카타나", 70, JOB.Warrior,200));
            itemlist.Add(new Item("레드 카타나",30, JOB.Chief,22));
            
            itemlist.Add(new Item("그린 크라페",50,JOB.Chief,20));
            itemlist.Add(new Item("다크 필퍼",30,JOB.Chief,80));
            itemlist.Add(new Item("홍진월갑주",20,JOB.Chief,50));
            
            itemlist.Add(new Item("레드 바르베이" ,15,JOB.Chief,22));
            itemlist.Add(new Item("블루 피에뜨 바지" ,50,JOB.Chief,22));
            itemlist.Add(new Item("레드 로얄마스터" ,100,JOB.Chief,22));
           
        }
        //해당 이름이 포함된 아이템을 배열로 묶어서 반환하는 함수
        public Item[] GetItem(string containStr)
        {
            var search = from item in itemlist
                         where item.name.Contains(containStr)
                         select item;

            return search.ToArray();
        }             
    }
}
