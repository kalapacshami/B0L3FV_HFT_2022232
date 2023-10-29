﻿using B0L3FV_HFT_2022232.Models;
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
using System.Windows.Input;

namespace B0L3FV_HFT_2022232.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Goblin> Goblins { get; set; }
        public RestCollection<Mission> Missions { get; set; }
        public RestCollection<Work> Works { get; set; }

        private Goblin selectedGoblin;

        public Goblin SelectedGoblin
        {
            get { return selectedGoblin; }
            set 
            {
                if (value != null)
                {
                    selectedGoblin = new Goblin()
                    {
                        GoblinID = value.GoblinID,
                        WID = value.WID,
                        GoblinName = value.GoblinName,
                        Level = value.Level,
                        Money = value.Money,
                        Height = value.Height,
                       

                    };
                    OnPropertyChanged();
                    (DeleteGoblinCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateGoblinCommand as RelayCommand).NotifyCanExecuteChanged();
                    
                }
            
            }
        }
        private Mission selectedMission;

        public Mission SelectedMission
        {
            get { return selectedMission; }
            set
            {
                if (value != null)
                {
                    SelectedMission = new Mission()
                    {
                        MissionID = value.MissionID,
                        Date = value.Date,
                        GoblinID = value.GoblinID,
                        Hazard = value.Hazard,
                        MissionCompleted = value.MissionCompleted,
                        MissionDuration = value.MissionDuration,
                        MType = value.MType,
                        Location = value.Location,
                        Kills = value.Kills,
                        Deaths = value.Deaths,
                        Loot = value.Loot
                    };
                    OnPropertyChanged();
                    (DeleteMissionCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteMissionCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        private Work selectedWork;

        public Work SelectedWork
        {
            get { return selectedWork; }
            set
            {
                if (value != null)
                {
                    selectedWork = new Work()
                    {
                        WID = value. WID,
                        WName = value.WName,
                        LocID = value.LocID,
                        Min_Money = value.Min_Money,
                        Max_Money = value.Max_Money,
                        HazardLevel = value.HazardLevel
                    };
                    OnPropertyChanged();
                    (DeleteWorkCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateWorkCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public ICommand CreateGoblinCommand { get; set; }
        public ICommand CreateMissionCommand { get;  set; }
        public ICommand CreateWorkCommand { get;  set; }

        public ICommand DeleteGoblinCommand { get; set; }
        public ICommand DeleteMissionCommand { get;  set; }
        public ICommand DeleteWorkCommand { get;  set; }
        public ICommand UpdateGoblinCommand { get; set; }
        public ICommand UpdateMissionCommand { get; set; }
        public ICommand UpdateWorkCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Goblins = new RestCollection<Goblin>("http://localhost:11828/", "goblin", "hub");
                Missions = new RestCollection<Mission>("http://localhost:11828/", "mission", "hub");
                Works = new RestCollection<Work>("http://localhost:11828/", "work", "hub");
            }
            
        }








    }
}
