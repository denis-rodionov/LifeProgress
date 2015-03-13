using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model2
{
    public partial class PercentTask
    {
        public void setPercent(double progress, ModelEntities model)
        {
            Current = (int)Math.Round(progress);
            model.SaveChanges();
        }

        public override int limit()
        {
            return 100;
        }
    }
}
