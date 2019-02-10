using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLoto.Domain;

namespace PlayerLoto.Services.FilterOperation
{
    public class DrawingResultFilterByParameter : IDrawingResultFilter
    {
        IDrawingResultFilter _drawing;
        int? _parameter;
        ParameterType _parameterType;
        public DrawingResultFilterByParameter(IDrawingResultFilter drawing, int? parameter, ParameterType parameterType)
        {
            _parameter = parameter;
            _drawing = drawing;
            _parameterType = parameterType;

        }
        public List<DrawingResult> Filter()
        {
            var list = _drawing.Filter();
            var listResult = new List<DrawingResult>();

            if(_parameter != null)
            {
                switch (_parameterType)
                {
                    case ParameterType.FijoCentena:
                        {
                            list.RemoveAll(d => d.Pick3 != _parameter);
                            listResult = list;
                            break;
                        }
                    case ParameterType.FijoDecena:
                        {
                            foreach (var drawing in list)
                            {
                               
                                if (Pick3TenExist(drawing, _parameter))
                                {
                                    listResult.Add(drawing);
                                }
                            }
                            break;
                        }
                    case ParameterType.Corrido:
                        {
                            foreach (var drawing in list)
                            {
                                if (CorrTenExist(drawing, _parameter))
                                {
                                    listResult.Add(drawing);
                                }
                            }
                            break;
                        }
                }
               

            }
            else
            {
                listResult = list;
            }
            return listResult;
        }

        private bool CorrTenExist(DrawingResult drawing, int? parameter)
        {
            int result;
            var decenaFijo = Math.DivRem(drawing.Pick3, 100, out result);
            return (result == parameter) ||
                   (drawing.Pick4First == parameter) ||
                   (drawing.Pick4Second == parameter);
        }

        private bool Pick3TenExist(DrawingResult drawing, int? parameter)
        {
            int result;
            var decenaFijo = Math.DivRem(drawing.Pick3, 100, out result);
            return (result == parameter);
                   
        }

    }
}
