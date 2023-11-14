using B0L3FV_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MovieDbApp.RestClient;

namespace B0L3FV_HFT_2022232.WpfClient.VM
{
    public class KillCountWindowViewModel: ObservableRecipient
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

        public List<Tool5> KillMissions { get; set; }

        public ICommand KillMissionCommand { get; set; }

        public KillCountWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                KillMissionCommand = new RelayCommand(() =>
                {
                    KillMissions = new RestService("http://localhost:11828/").Get<Tool5>("tool/KillCountMissions");

                    foreach (var item in KillMissions)
                    {
                        Answer += "Goblin called: " + item.Name + ", Goblin's work: " + item.Goblin_work + " , Kills: " + item.Kill + " , ID: " + item.Id + Environment.NewLine;
                    }
                });
            }
        }
    }
}
