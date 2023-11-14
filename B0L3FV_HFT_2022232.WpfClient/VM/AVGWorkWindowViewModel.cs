using B0L3FV_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MovieDbApp.RestClient;

namespace B0L3FV_HFT_2022232.WpfClient.VM
{
    public class AVGWorkWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        private string answer;
        public string Answer
        {
            get
            {
                return answer;

            }
            set
            {
                SetProperty(ref answer, value);
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public List<Tool3> AVGWork { get; set; }

        public ICommand AVGWorkCommand { get; set; }

        public AVGWorkWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                AVGWorkCommand = new RelayCommand(() =>
                {
                    AVGWork = new RestService("http://localhost:11828/").Get<Tool3>("tool/AVGWork");

                    foreach (var item in AVGWork)
                    {
                        Answer += "Type of the Work: " + item.Name + ", Avg. Income: " + item.Income + " , Avg. Height: " + item.Height + " , Avg. Hazard: " + item.Hazard+ Environment.NewLine;
                    }
                });
            }
        }
    }
}
