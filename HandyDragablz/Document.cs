using System;
using System.Windows.Media;

namespace HandyDragablz
{
    public class Document
    {
        public Document()
        {
            Background = PickBrush();
        }

        public string Header { get; set; }

        public Brush Background { get; set; }

        private Brush PickBrush()
        {
            Brush result;
            Random rnd = new Random();
            
            var brushesType = typeof(Brushes);
            var properties = brushesType.GetProperties();
            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

    }
}
