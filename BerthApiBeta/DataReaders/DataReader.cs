using BerthApiBeta.DataTransferObjects;
using BerthApiBeta.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace BerthApiBeta.DataReaders
{
    public class DataReader
    {
        public DataReader ()
        {

        }

        public RecordDTO ReadRecordDTO (IDataRecord reader)
        {
            var obj = new JObject();

            int recordId = reader.GetInt32(0);
            int heartBeatPerSecond = reader.GetInt32(1);

            RecordDTO recordDTO = new RecordDTO
            {
                RecordId = recordId,
                HeartBeatPerSecond = heartBeatPerSecond
            };

            return recordDTO;

        }

        public Record ReadRecord (IDataRecord reader)
        {
            var obj = new JObject();

            int recordId = reader.GetInt32(0);                                    
            double bPSystolic = reader.GetDouble(1);
            double bPDiastolic = reader.GetDouble(2);
            DateTime recordTime = reader.GetDateTime(3);
            double bodyTemperature = reader.GetDouble(4);
            int heartBeatPerSecond = reader.GetInt32(5);
            double dust = reader.GetDouble(6);
            double sulphur = reader.GetDouble(7);
            double nitrogen = reader.GetDouble(8);
            double fluor = reader.GetDouble(9);
            double carbonMonoxide = reader.GetDouble(10);
            double ozone = reader.GetDouble(11);
            int userID = reader.GetInt32(12);
            double longitude = reader.GetDouble(13);
            double lat = reader.GetDouble(14);


            Record record = new Record
            {
                RecordId = recordId,          
                RecordTime = recordTime,
                BPSystolic = bPSystolic,
                BPDiastolic = bPDiastolic,
                BodyTemperature = bodyTemperature,
                HeartBeatPerSecond = heartBeatPerSecond,
                Dust = dust,
                Sulphur = sulphur,
                Nitrogen = nitrogen,
                Fluor = fluor,
                CarbonMonoxide = carbonMonoxide,
                Ozone = ozone,
                UserID = userID,
                Long = longitude,
                Lat = lat
            };

            return record;        
        }

        public RecordAverageDTO ReadRecordAverageDTO(IDataRecord reader)
        {
            var obj = new JObject();

            int dayDate = reader.GetInt32(0);
            int monthDate = reader.GetInt32(1);
            double bPSystolic = reader.GetDouble(2);
            double bPDiastolic = reader.GetDouble(3);           
            double bodyTemperature = reader.GetDouble(4);
            double heartBeatPerSecond = reader.GetInt32(5);
            double dust = reader.GetDouble(6);
            double sulphur = reader.GetDouble(7);
            double nitrogen = reader.GetDouble(8);
            double fluor = reader.GetDouble(9);
            double carbonMonoxide = reader.GetDouble(10);
            double ozone = reader.GetDouble(11);
            double temperature = reader.GetDouble(12);
            double pressure = reader.GetDouble(13);
            double humidity = reader.GetDouble(14);

            RecordAverageDTO recordAvergageDTO = new RecordAverageDTO
            {
                DayDate = dayDate,
                MonthDate = monthDate,
                BPSystolic = bPSystolic,
                BPDiastolic = bPDiastolic,
                BodyTemperature = bodyTemperature,
                HeartBeatPerSecond = heartBeatPerSecond,
                Dust = dust,
                Sulphur = sulphur,
                Nitrogen = nitrogen,
                Fluor = fluor,
                CarbonMonoxide = carbonMonoxide,
                Ozone = ozone,
                Temperature = temperature,
                Pressure = pressure,
                Humidity = humidity
            };

            return recordAvergageDTO;
        }
    }
}
