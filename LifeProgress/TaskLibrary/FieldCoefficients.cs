using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Entity;
using Model2;
using System.Data.Objects;

namespace TaskLibrary
{
    public partial class FieldCoefficients : UserControl
    {
        const int LEFT_OFFSET = 5;
        const int TOP_OFFSET = 5;
        const int BOTTOM_OFFSET = 5;

        //List<FieldMap> _fmCollection;
        List<Control> _trackerCollection;
        CoefficientCalculator _calculator;

        public FieldCoefficients()
        {
            InitializeComponent();
            //_fmCollection = new List<FieldMap>();
            _trackerCollection = new List<Control>();
            _calculator = new CoefficientCalculator();
            DoubleBuffered = true;
        }

        public void addFieldMap(FieldMap fm)
        {
            //_fmCollection.Add(fm);
            addChildControl(fm);
            _calculator.addFieldMap(fm);
        }

        /// <summary>
        /// Adds FieldMap (field with coefficient) to the control;
        /// New tracker appears.
        /// </summary>
        private void addChildControl(FieldMap fm)
        {
            MyTracker newTracker = createTracker(fm, onTrackerChanged);
            _trackerCollection.Add(newTracker);
            newTracker.Top = getBottom();
            newTracker.Left = LEFT_OFFSET;
            grpMain.Controls.Add(newTracker);
            Height = getBottom() + BOTTOM_OFFSET;
            Width = newTracker.Width + 2 * LEFT_OFFSET;
        }

        /// <summary>
        /// Gets bottom border of the bottom (last) component (tracker)
        /// </summary>
        private int getBottom()
        {
            int res = TOP_OFFSET;
            foreach (Control c in _trackerCollection)
                if (c.Bottom > res)
                    res = c.Bottom;
            return res;
        }

        private static MyTracker createTracker(FieldMap fm, ChangeHandler handler)
        {
            MyTracker newTracker = new MyTracker(fm, handler);
            return newTracker;
        }

        public void rejectChanges(ModelEntities model)
        {
            model.Refresh(RefreshMode.StoreWins, getFieldMaps());
            foreach (MyTracker tr in _trackerCollection)
                tr.refresh();
        }

        private IEnumerable<FieldMap> getFieldMaps()
        {
            List<FieldMap> res = new List<FieldMap>();
            foreach (MyTracker tr in _trackerCollection)
                res.Add(tr.FM);
            return res;
        }

        public void saveSettings(ModelEntities model)
        {
            model.SaveChanges();
        }

        /// <summary>
        /// Recalculates other coefficients when one of the coefficients is changed
        /// </summary>
        /// <param name="fm"></param>
        private void onTrackerChanged(FieldMap fm)
        {
            _calculator.coefficientChanged(fm);
            foreach (MyTracker tr in _trackerCollection)
                tr.refresh();
            //grpMain.Text = "12333";
            grpMain.Refresh();
            //Update();
            //ParentForm.Update();
        }

        /// <summary>
        /// remove all field maps and reset all controls
        /// </summary>
        public void reset()
        {
            _trackerCollection.Clear();
            _calculator.reset();
            grpMain.Controls.Clear();
        }
    }
}
