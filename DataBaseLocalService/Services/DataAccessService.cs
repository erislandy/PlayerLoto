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
    public class DataAccessService
    {
        #region Attributes

        private List<DrawingResult> _drawingResultList;
        private List<int> _numberList;

        #endregion
        public DataAccessService()
        {
            _drawingResultList = new List<DrawingResult>();

            #region Load Data json

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataAccessService)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("DataBaseLocalService.Data.test1.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                _drawingResultList = JsonConvert.DeserializeObject<List<DrawingResult>>(json);
               
            }

            #endregion

            _numberList = new List<int>()
            {
                101,301,501,701,101,203,405,605,809,705,430,280,990,870,860,450,320,360,350,390,340,260,200,900,700,660,880,110,140,190
            };

        }

        public List<DrawingResult> GetDrawingResultHistory()
        {
            return _drawingResultList;
        }

        public List<int> GetNumberList()
        {
            return _numberList;
        }


    }
}
