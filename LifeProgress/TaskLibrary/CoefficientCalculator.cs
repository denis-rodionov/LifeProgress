using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model2;

namespace TaskLibrary
{
    class CoefficientCalculator
    {
        List<FieldMap> _fieldMaps;

        public CoefficientCalculator()
        {
            _fieldMaps = new List<FieldMap>();
        }

        public CoefficientCalculator(IEnumerable<FieldMap> fieldMaps)
        {
            _fieldMaps = new List<FieldMap>();
            _fieldMaps.AddRange(fieldMaps);
        }

        public void coefficientChanged(FieldMap fm)
        {
            if (_fieldMaps.Count() == 1)
                fm.Coefficient = 1;

            float sumOthers = calcOthersSum(fm);
            float diff = fm.Coefficient - (1 - sumOthers);

            foreach (FieldMap fmCur in _fieldMaps)
                if (fmCur != fm)
                {
                    float ci = fmCur.Coefficient;
                    if (sumOthers != 0)
                        fmCur.Coefficient = ci - ci * diff / sumOthers;
                    else
                        fmCur.Coefficient -= diff / (_fieldMaps.Count - 1);

                    //if (fmCur.Coefficient < 0)
                    //    fmCur.Coefficient = 0;
                }
        }

        private float calcOthersSum(FieldMap fm)
        {
            float res = 0;
            foreach (FieldMap fmCur in _fieldMaps)
                if (fmCur.ID != fm.ID)
                    res += fmCur.Coefficient;
            return res;
        }

        public void addFieldMap(FieldMap fm)
        {
            _fieldMaps.Add(fm);
        }

        public void reset()
        {
            _fieldMaps.Clear();
        }
    }
}
