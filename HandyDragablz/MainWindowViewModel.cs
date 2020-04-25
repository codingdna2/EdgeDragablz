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

        private static bool isFirstVM = false;

        public MainWindowViewModel()
        {
            if (!isFirstVM)
            {
                Documents = new ObservableCollection<Document>()
                {
                    new Document() { Header = "Document 1" },
                    new Document() { Header = "Document 2" },
                    new Document() { Header = "Document 3" },
                    //new Document() { Header = "Document 4" },
                    //new Document() { Header = "Document 5" },
                    //new Document() { Header = "Document 6" },
                    //new Document() { Header = "Document 7" },
                    //new Document() { Header = "Document 8" },
                };
                isFirstVM = true;
            }
            else Documents = new ObservableCollection<Document>();

            counter = Documents.Count;

            AddCommand = new DelegateCommand(() => { Documents.Add(new Document() { Header = $"Document {++counter}" }); });

            RemoveCommand = new DelegateCommand(() => { Documents.Remove(this.Document); });
        }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public Document Document { get; set; }

        public ObservableCollection<Document> Documents { get; }

    }
}
