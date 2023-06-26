using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DevxControlsSamples.Models
{
    public class ChartTypeOptions
    {
    }

    public class ChartDemoOptions
    {
        bool showLabels;
        object data;

        public bool ShowLabels
        {
            get { return showLabels; }
            set { showLabels = value; }
        }

        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        public ChartDemoOptions()
        {
        }
    }
    public class ChartPieDoughnutDemoOptions : ChartDemoOptions
    {
        static List<string> listExplodeModes = new List<string>(){
            PieExplodeMode.None.ToString(),
            PieExplodeMode.All.ToString(),
            PieExplodeMode.MinValue.ToString(),
            PieExplodeMode.MaxValue.ToString()
        };
        int holeRadiusPercent = 60;
        string explodedPoints = PieExplodeMode.None.ToString();
        string explodePoint;
        PieExplodeMode explodeMode = PieExplodeMode.None;
        PieSeriesLabelPosition labelPosition = PieSeriesLabelPosition.Outside;
        int explodeDistance = 10;
        bool valueAsPercent = true;
        bool showTotalLabel = true;

        public PieSeriesLabelPosition LabelPosition
        {
            get { return labelPosition; }
            set { labelPosition = value; }
        }
        public string ExplodedPoints
        {
            get { return explodedPoints; }
            set
            {
                explodedPoints = value;
                if (listExplodeModes.Contains(value))
                {
                    explodePoint = null;
                    explodeMode = (PieExplodeMode)Enum.Parse(typeof(PieExplodeMode), value);
                }
                else
                    explodePoint = value;
            }
        }
        public int ExplodeDistance
        {
            get { return explodeDistance; }
            set { explodeDistance = value; }
        }
        public string ExplodePoint { get { return explodePoint; } }
        public PieExplodeMode ExplodeMode { get { return explodeMode; } }
        [DisplayName("Value as Percent")]
        public bool ValueAsPercent
        {
            get { return valueAsPercent; }
            set { valueAsPercent = value; }
        }
        [DisplayName("Hole Radius, %")]
        public int HoleRadiusPercent
        {
            get { return holeRadiusPercent; }
            set { holeRadiusPercent = value; }
        }
        public bool ShowTotalLabel
        {
            get { return showTotalLabel; }
            set { showTotalLabel = value; }
        }
    }
}