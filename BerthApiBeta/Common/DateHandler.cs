using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerthApiBeta.Common
{
    public class DateHandler
    {
        public DateHandler()
        {

        }

        //public string ConvertToSqlStringDate(string time)
        //{
        //    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        //    dateTime = dateTime.AddSeconds(unixTime).ToLocalTime();
        //    string date = dateTime.ToShortDateString();

        //    string[] dateSplitted = time.Split('/');
        //    string month = dateSplitted[0];
        //    string day = dateSplitted[1];
        //    string year = dateSplitted[2];

        //    string newDateString = "'" + month + "-" + day + "-" + year + "'";
        //    return newDateString;
        //}

        public string ConvertToSqlStringDate(double unixTime)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTime).ToLocalTime();
            string date = dateTime.ToShortDateString();
            string[] dateSplitted = date.Split('/');
            string month = dateSplitted[0];
            string day = dateSplitted[1];
            string year = dateSplitted[2];

            string newDateString = "'" + month + "-" + day + "-" + year + "'";
            return newDateString;
        }
    }
}
