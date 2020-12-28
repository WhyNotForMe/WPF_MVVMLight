using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WpfDemoCrazyElephant.Model;


namespace WpfDemoCrazyElephant.Service
{
    public class XmlDataService : IDataService
    {
        public  List<Dish> GetAllDishes()
        {   //LINQ查询集合！
            List<Dish> dishList = new List<Dish>();

            string xmlFile = System.IO.Path.Combine(@"Data\Data.xml");
            XDocument xDoc = XDocument.Load(xmlFile);
            var dishes = xDoc.Descendants("Dish");
            foreach (var d in dishes)
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = double.Parse(d.Element("Score").Value);
                dishList.Add(dish);
            }
            return dishList;

        }
    }
}