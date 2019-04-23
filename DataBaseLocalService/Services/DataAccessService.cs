using DataBaseLocalService.Helpers;
using DataBaseLocalService.Models;
using Newtonsoft.Json;
using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        #region Constructors

        public DataAccessService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            int count = _dataAccess.GetList<DrawingResultLocal>(false).Count;
            int countCabalaValues = _dataAccess.GetList<CabalaNumbersLocal>(false).Count;
            int amountWords = _dataAccess.GetList<CabalaWordsLocal>(false).Count;

            #region Loading drawings in SQLite database from  json files

            if (count == 0)
            {

                List<DrawingResult> drawingResultList;

                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataAccessService)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("DataBaseLocalService.Data.dr.json");

                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    drawingResultList = JsonConvert.DeserializeObject<List<DrawingResult>>(json);

                }
                List<DrawingResultLocal> drawingResultLocalList = ConvertDrawinToDrawingLocalList(drawingResultList);
                Save<DrawingResultLocal>(drawingResultLocalList);


            }
            #endregion

            #region Loading data in Cabala database local from json files

            if (countCabalaValues == 0)
            {
                List<Cabala_Number> cabalaNumbers;
                List<Cabala_Word> cabalaWords;

                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataAccessService)).Assembly;
                Stream streamNumber = assembly.GetManifestResourceStream("DataBaseLocalService.Data.cbN.json");
                Stream streamWord = assembly.GetManifestResourceStream("DataBaseLocalService.Data.cbW.json");

                using (var reader = new StreamReader(streamNumber))
                {
                    var json = reader.ReadToEnd();
                    cabalaNumbers = JsonConvert.DeserializeObject<List<Cabala_Number>>(json);

                }
                using (var reader = new StreamReader(streamWord))
                {
                    var json = reader.ReadToEnd();
                    cabalaWords = JsonConvert.DeserializeObject<List<Cabala_Word>>(json);

                }
                List<CabalaNumbersLocal> cabalaNumbersLocal = ConvertNumberToNumberLocalList(cabalaNumbers);
                List<CabalaWordsLocal> cabalaWordsLocal = ConvertWordToWordLocalList(cabalaWords);

                Save<CabalaNumbersLocal>(cabalaNumbersLocal);
                Save<CabalaWordsLocal>(cabalaWordsLocal);



            }

            #endregion



            _numberList = new List<int>()
            {
                101,301,501,701,101,203,405,605,809,705,430,280,990,870,860,450,320,360,350,390,340,260,200,900,700,660,880,110,140,190
            };

        }

        

        #endregion



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

       

        private List<CabalaNumbersLocal> ConvertNumberToNumberLocalList(List<Cabala_Number> cabalaNumbers)
        {
            List<CabalaNumbersLocal> list = new List<CabalaNumbersLocal>();
            foreach (var cabalaNumber in cabalaNumbers)
            {
                list.Add(

                    new CabalaNumbersLocal()
                    {
                        Description = cabalaNumber.Description,
                        Number = cabalaNumber.Number

                    });
            }
            return list;
        }

        private List<CabalaWordsLocal> ConvertWordToWordLocalList(List<Cabala_Word> cabalaWords)
        {
            List<CabalaWordsLocal> list = new List<CabalaWordsLocal>();
            foreach (var cabalaWord in cabalaWords)
            {
                list.Add(

                    new CabalaWordsLocal()
                    {
                       Numbers = cabalaWord.Numbers,
                       Word = cabalaWord.Word

                    });
            }
            return list;
        }

        private Cabala_Number ConvertCabalaNumberLocalToCabalaNumber(CabalaNumbersLocal cabalaNumberLocal)
        {
            return new Cabala_Number()
            {
                Number = cabalaNumberLocal.Number,
                Description = cabalaNumberLocal.Description
            };
        }

        private List<Cabala_Word> ConvertWordLocalListToWordList(List<CabalaWordsLocal> cabalaWordLocalList)
        {
            var list = new List<Cabala_Word>();
            foreach (var wordLocal in cabalaWordLocalList)
            {
                list.Add(
                    new Cabala_Word()
                    {
                        Word = wordLocal.Word,
                        Numbers = wordLocal.Numbers
                    });
            }
            return list;
        }
       
        #endregion

        #region Implementations IDataAccessService

        public List<DrawingResult> GetDrawingResultHistory(DateTime initialDate, DateTime finaldate)
        {
            var drawingResultLocalList = _dataAccess.GetList<DrawingResultLocal>(false)
                       .FindAll(d => d.Date >= initialDate && d.Date <= finaldate);
            List<DrawingResult> drawingResultList = ConvertDrawinLocalToDrawingList(drawingResultLocalList);

            return drawingResultList;
        }

        public Cabala_Number FindByNumber(int number)
        {
            var cabalaNumberLocal = _dataAccess.GetList<CabalaNumbersLocal>(false)
                       .Find(c => c.Number == number);
            return ConvertCabalaNumberLocalToCabalaNumber(cabalaNumberLocal);
        }


        public List<Cabala_Word> FindByWord(string word)
        {
            var cabalaWordLocalList =  _dataAccess.GetList<CabalaWordsLocal>(false)
                                                 .FindAll(c => c.Word.ToLower().Contains(word.ToLower()));
            return ConvertWordLocalListToWordList(cabalaWordLocalList);
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
