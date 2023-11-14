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
    public class AVGGoblinWindowViewModel : ObservableRecipient
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

        public List<Tool4> AVGGoblins { get; set; }

        public ICommand AVGGoblinsCommand { get; set; }

        public AVGGoblinWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                AVGGoblinsCommand = new RelayCommand(() =>
                {
                    AVGGoblins = new RestService("http://localhost:11828/").Get<Tool4>("tool/AVGGoblin");

                    foreach (var item in AVGGoblins)
                    {
                        Answer += "Avg. Loot: " + item.Loot + ", Avg. Kills: " + item.Kill + " , Avg. Deaths: " + item.Death + " Avg Duration: " + item.Duration + Environment.NewLine;
                    }
                });
            }
        }


    }
}
