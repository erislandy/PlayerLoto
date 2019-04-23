using DataBaseLocalService.Helpers;
using DataBaseLocalService.Models;
using Newtonsoft.Json;
using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DataBaseLocalService.Services
{
    public class DataAccessService : IDataAccessService
    {
        #region Attributes

        private List<int> _numberList;


        #endregion

        #region Services

        IDataAccess _dataAccess;

        #endregion
        public DataAccessService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            int count = _dataAccess.GetList<DrawingResultLocal>(false).Count;

            if(count == 0)
            {
                #region Load values in SQLite database from  json files

                List<DrawingResult> drawingResultList;

                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataAccessService)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("DataBaseLocalService.Data.test1.json");

                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    drawingResultList = JsonConvert.DeserializeObject<List<DrawingResult>>(json);

                }
                List<DrawingResultLocal> drawingResultLocalList = ConvertDrawinToDrawingLocalList(drawingResultList);
                Save<DrawingResultLocal>(drawingResultLocalList);

                #endregion

            }


            _numberList = new List<int>()
            {
                101,301,501,701,101,203,405,605,809,705,430,280,990,870,860,450,320,360,350,390,340,260,200,900,700,660,880,110,140,190
            };

        }

        #region Methods
        private List<DrawingResultLocal> ConvertDrawinToDrawingLocalList(List<DrawingResult> drawingResultList)
        {
            List<DrawingResultLocal> list = new List<DrawingResultLocal>();
            foreach (var drawing in drawingResultList)
            {
                list.Add(

                    new DrawingResultLocal()
                    {
                        Date = drawing.Date,
                        Pick3 = drawing.Pick3,
                        Pick4First = drawing.Pick4First,
                        Pick4Second = drawing.Pick4Second,
                        Type = drawing.Type,

                    });
            }
            return list;
        }
        private List<DrawingResult> ConvertDrawinLocalToDrawingList(List<DrawingResultLocal> drawingResultLocalList)
        {
            List<DrawingResult> list = new List<DrawingResult>();
            foreach (var drawingLocal in drawingResultLocalList)
            {
                list.Add(

                    new DrawingResult()
                    {
                        Date = drawingLocal.Date,
                        Pick3 = drawingLocal.Pick3,
                        Pick4First = drawingLocal.Pick4First,
                        Pick4Second = drawingLocal.Pick4Second,
                        Type = drawingLocal.Type,

                    });
            }
            return list;
        }

        public List<DrawingResult> GetDrawingResultHistory(DateTime initialDate, DateTime finaldate)
        {
            var drawingResultLocalList = _dataAccess.GetList<DrawingResultLocal>(false)
                       .FindAll(d => d.Date >= initialDate && d.Date <= finaldate);
            List<DrawingResult> drawingResultList = ConvertDrawinLocalToDrawingList(drawingResultLocalList);

            return drawingResultList;
        }

      

        #endregion



        public void Save<T>(List<T> list) where T : class
        {
           
                foreach (var record in list)
                {
                    _dataAccess.Insert(record);
                }
           
        }


        public List<int> GetNumberList()
        {
            return _numberList;
        }


    }
}
