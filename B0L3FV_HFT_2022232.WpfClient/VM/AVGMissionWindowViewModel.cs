using B0L3FV_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MovieDbApp.RestClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace B0L3FV_HFT_2022232.WpfClient.VM
{
    public class AVGMissionWindowViewModel : ObservableRecipient
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

        public List<Tool1> AVGMissions { get; set; }

        public ICommand AVGMissionsCommand { get; set; }

        public AVGMissionWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                AVGMissionsCommand = new RelayCommand(() =>
                {
                    AVGMissions = new RestService("http://localhost:11828/").Get<Tool1>("tool/AVGMission");

                    foreach (var item in AVGMissions)
                    {
                        Answer += "Avg. Height: " + item.avg_Height+", Avg. Hazard: "+ item.avg_Hazard +  " , Avg. Level: " + item.avg_level + Environment.NewLine;
                    }
                });
            }
        }




    }
}
