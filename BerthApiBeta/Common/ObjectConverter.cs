using BerthApiBeta.DataTransferObjects;
using BerthApiBeta.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerthApiBeta.Common
{
    public class ObjectConverter
    {
        public ObjectConverter()
        {


        }

        //public JObject dayJson(List<RecordAverageDTO> list)
        //{
        //    var obj = new JObject();

            //foreach (var item in list)
            //{
            //    if (item.RecordTime.Day == 1)
            //    {


            //        obj.Add("0", item.People);
            //    }
            //    if (item.HoursAct == 1)
            //    {
            //        obj.Add("1", item.People);
            //    }
            //    if (item.HoursAct == 2)
            //    {
            //        obj.Add("2", item.People);
            //    }
            //    if (item.HoursAct == 3)
            //    {
            //        obj.Add("3", item.People);
            //    }
            //    if (item.HoursAct == 4)
            //    {
            //        obj.Add("4", item.People);
            //    }
            //    if (item.HoursAct == 5)
            //    {
            //        obj.Add("5", item.People);
            //    }
            //    if (item.HoursAct == 6)
            //    {
            //        obj.Add("6", item.People);
            //    }
            //    if (item.HoursAct == 7)
            //    {
            //        obj.Add("7", item.People);
            //    }
            //    if (item.HoursAct == 8)
            //    {
            //        obj.Add("8", item.People);
            //    }
            //    if (item.HoursAct == 9)
            //    {
            //        obj.Add("9", item.People);
            //    }
            //    if (item.HoursAct == 10)
            //    {
            //        obj.Add("10", item.People);
            //    }
            //    if (item.HoursAct == 11)
            //    {
            //        obj.Add("11", item.People);
            //    }
            //    if (item.HoursAct == 12)
            //    {
            //        obj.Add("12", item.People);
            //    }
            //    if (item.HoursAct == 13)
            //    {
            //        obj.Add("13", item.People);
            //    }
            //    if (item.HoursAct == 14)
            //    {
            //        obj.Add("14", item.People);
            //    }
            //    if (item.HoursAct == 15)
            //    {
            //        obj.Add("15", item.People);
            //    }
            //    if (item.HoursAct == 16)
            //    {
            //        obj.Add("16", item.People);
            //    }
            //    if (item.HoursAct == 17)
            //    {
            //        obj.Add("17", item.People);
            //    }
            //    if (item.HoursAct == 18)
            //    {
            //        obj.Add("18", item.People);
            //    }
            //    if (item.HoursAct == 19)
            //    {
            //        obj.Add("19", item.People);
            //    }
            //    if (item.HoursAct == 20)
            //    {
            //        obj.Add("20", item.People);
            //    }
            //    if (item.HoursAct == 21)
            //    {
            //        obj.Add("21", item.People);
            //    }
            //    if (item.HoursAct == 22)
            //    {
            //        obj.Add("22", item.People);
            //    }
            //    if (item.HoursAct == 23)
            //    {
            //        obj.Add("23", item.People);
            //    }
            //}
        //    return obj;
        //}

    }
}
