using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BerthApiBeta.Models;
using Microsoft.AspNetCore.Cors;
using System.Data.SqlClient;
using NetTopologySuite.Geometries;
using BerthApiBeta.DataReaders;
using BerthApiBeta.Common;
using BerthApiBeta.DataTransferObjects;
using Newtonsoft.Json.Linq;

namespace BerthApiBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class RecordsController : ControllerBase
    {

        private readonly BerthApiBetaContext _context;

        private static string connectionString = "Server=tcp:berthapibeta20181025031131dbserver.database.windows.net,1433;Initial Catalog=BerthApiBeta_db;Persist Security Info=False;User ID=mario;Password=Abcd1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public RecordsController(BerthApiBetaContext context)
        {
            _context = context;
        }


        // GET: api/Records
        [HttpGet]
        public IEnumerable<Record> GetRecord()
        {
            return _context.Record;
        }


        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await _context.Record.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }


        // GET: api/Records/filterbydate/userid/fromdate/todate
        //[HttpGet("filterbydate/{userid}/{fromdate}/{todate}")]
        //public IEnumerable<Record> FilterByDate([FromRoute] int userId, double fromDate, double toDate)
        //{

        //    DateHandler dateHandler = new DateHandler();

        //    string dateFrom = dateHandler.ConvertToSqlStringDate(fromDate);
        //    string dateTo = dateHandler.ConvertToSqlStringDate(toDate);



        //    string _selectString = "SELECT * FROM \"Record\" WHERE \"UserId\" = " + userId + " AND \"RecordTime\" BETWEEN " + dateFrom + " AND " + dateTo + "";

        //    using (var conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (var cmd = new SqlCommand(_selectString, conn))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                List<Record> RecordList = new List<Record>();

        //                while (reader.Read())
        //                {
        //                    DataReader dataReader = new DataReader();


        //                    Record mtc = dataReader.ReadRecord(reader);
        //                    RecordList.Add(mtc);
        //                }
        //                return RecordList;
        //            }
        //        }
        //    }
        //}


        // GET: api/Records/filterbydate/userid/fromdate/todate
        [HttpGet("filterbydate/{userid}/{fromdate}/{todate}")]
        public IEnumerable<RecordAverageDTO> FilterByDate([FromRoute] int userId, double fromDate, double toDate)
        {

            DateHandler dateHandler = new DateHandler();

            string dateFrom = dateHandler.ConvertToSqlStringDate(fromDate);
            string dateTo = dateHandler.ConvertToSqlStringDate(toDate);


            string _selectString = "SELECT Datepart(\"Day\", \"RecordTime\") as \"DayDate\", Datepart(\"Month\", \"RecordTime\") as \"MonthDate\", avg(\"BPSystolic\") as \"BpSystolicAvg\", avg(\"BPDiastolic\") as \"BpDiastolicAvg\", avg(\"BodyTemperature\") as \"BodyTemperature\", avg(\"HeartBeatPerSecond\") as \"HeartBeatPerSecond\", avg(\"Dust\") as \"Dust\", avg(\"Sulphur\") as \"Sulphur\", avg(\"Nitrogen\") as \"Nitrogen\", avg(\"Fluor\") as \"Fluor\", avg(\"CarbonMonoxide\") as \"CarbonMonoxide\", avg(\"Ozone\") as \"Ozone\", avg(\"RaspberryRecord\".\"Temperature\") as \"Temperature\", avg(\"RaspberryRecord\".\"Pressure\") as \"Pressure\", avg(\"RaspberryRecord\".\"Humudity\") as \"Humidity\" FROM \"Record\" INNER JOIN \"RaspberryRecord\" ON \"Record\".\"UserID\" = \"RaspberryRecord\".\"UserId\" WHERE \"Record\".\"UserID\" = " + userId + " AND \"RecordTime\" BETWEEN " + dateFrom + " AND " + dateTo + " group by Datepart (\"Day\", \"RecordTime\"), Datepart (\"Month\", \"RecordTime\")";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<RecordAverageDTO> RecordList = new List<RecordAverageDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            RecordAverageDTO mtc = dataReader.ReadRecordAverageDTO(reader);
                            RecordList.Add(mtc);
                        }

                        //ObjectConverter objConverted = new ObjectConverter();
                        //JObject jObject = objConverted.dayJson(RecordList);
                        return RecordList;
                    }
                }
            }
        }


        // GET: api/Records/filterbydate/userid/fromdate/todate
        //[HttpGet("filterbydate/{userid}/{fromdate}/{todate}")]
        //public IEnumerable<Record> FilterByDate([FromRoute] int userId, string fromDate, string toDate)
        //{

        //    DateHandler dateHandler = new DateHandler();

        //    string dateFrom = dateHandler.ConvertToSqlStringDate(fromDate);
        //    string dateTo = dateHandler.ConvertToSqlStringDate(toDate);



        //    string _selectString = "SELECT * FROM \"Record\" WHERE \"UserId\" = " + userId + " AND \"RecordTime\" BETWEEN " + dateFrom + " AND " + dateTo + "";

        //    using (var conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (var cmd = new SqlCommand(_selectString, conn))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                List<Record> RecordList = new List<Record>();

        //                while (reader.Read())
        //                {
        //                    DataReader dataReader = new DataReader();


        //                    Record mtc = dataReader.ReadRecord(reader);
        //                    RecordList.Add(mtc);
        //                }
        //                return RecordList;
        //            }
        //        }
        //    }
        //}























        // PUT: api/Records/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord([FromRoute] int id, [FromBody] Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != record.RecordId)
            {
                return BadRequest();
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Records
        [HttpPost]
        public async Task<IActionResult> PostRecord([FromBody] Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Record.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecord", new { id = record.RecordId }, record);
        }

        // POST: api/Records/SubmitForm/
        //[HttpPost]
        //public async Task<IActionResult> SubmitForm([FromBody] Record record)
        //{
        //    string _selectString = "SELECT * from \"Mtcs\" limit 3";

        //    using (var conn = new NpgsqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (var cmd = new SqlCommand(_selectString, conn))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                List<Record> MtcList = new List<Record>();

        //                while (reader.Read())
        //                {
        //                    Record mtc = ReadMtc(reader);
        //                    MtcList.Add(mtc);
        //                }
        //                return MtcList;
        //            }
        //        }
        //    }
        //    return null;
        //}



        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await _context.Record.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Record.Remove(record);
            await _context.SaveChangesAsync();

            return Ok(record);
        }

        private bool RecordExists(int id)
        {
            return _context.Record.Any(e => e.RecordId == id);
        }
    }
}
