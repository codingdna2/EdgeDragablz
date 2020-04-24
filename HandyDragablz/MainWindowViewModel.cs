using Dragablz;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;

namespace HandyDragablz
{
    public class MainWindowViewModel
    {
        private int counter;

        public MainWindowViewModel()
        {
            InterTabClient = new DefaultInterTabClient();

            Documents = new ObservableCollection<Document>()
            {
                new Document() { Header = "Document 1", Background = PickBrush() },
                new Document() { Header = "Document 2", Background = PickBrush() },
                new Document() { Header = "Document 3", Background = PickBrush() },
                //new Document() { Header = "Document 4", Background = PickBrush() },
                //new Document() { Header = "Document 5", Background = PickBrush() },
                //new Document() { Header = "Document 6", Background = PickBrush() },
                //new Document() { Header = "Document 7", Background = PickBrush() },
                //new Document() { Header = "Document 8", Background = PickBrush() },

            };

            counter = Documents.Count;

            AddCommand = new DelegateCommand(() => { Documents.Add(new Document() { Header = $"Document {++counter}", Background = PickBrush() }); });

            RemoveCommand = new DelegateCommand(() => { Documents.Remove(this.Document); });
        }

        private Brush PickBrush()
        {
            Brush result;
            Random rnd = new Random();
            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public Document Document { get; set; }

        public ObservableCollection<Document> Documents { get; }

        public IInterTabClient InterTabClient { get; }

    }
}
