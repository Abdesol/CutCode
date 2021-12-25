﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media;
using CutCode.CrossPlatform.Interfaces;
using CutCode.CrossPlatform.ViewModels;
using CutCode.DataBase;
using ReactiveUI;

namespace CutCode.CrossPlatform.ViewModels
{
    public class AddViewModel : PageBaseViewModel
    {
        private IDataBase Database => DataBase;
        public ObservableCollection<CodeCellViewModel?> Cells { get; }
        public AddViewModel()
        {
            Cells = new ObservableCollection<CodeCellViewModel?>();
            Cells.Add(new CodeCellViewModel(this));
            Cells.Add(new CodeCellViewModel(this));
        }

        protected override void OnLightThemeIsSet()
        {
            BackgroundColor =  Color.Parse("#FCFCFC");
            BarBackground =  Color.Parse("#F6F6F6");
            
            TextAreaBackground = Color.Parse("#ECECEC");
            TextAreaForeground = Color.Parse("#000000");
            TextAreaOverlayBackground = Color.Parse("#E2E2E2");
            
            ComboBoxBackground = Color.Parse("#ECECEC");
            ComboBoxBackgroundOnHover = Color.Parse("#E2E2E2");
        }

        protected override void OnDarkThemeIsSet()
        {
            BackgroundColor =  Color.Parse("#36393F");
            BarBackground =  Color.Parse("#303338");
            
            TextAreaBackground = Color.Parse("#2A2E33");
            TextAreaForeground = Color.Parse("#FFFFFF");
            TextAreaOverlayBackground = Color.Parse("#24272B");
            
            ComboBoxBackground = Color.Parse("#2A2E33");
            ComboBoxBackgroundOnHover = Color.Parse("#24272B");
        }
        
        private string _text;
        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }
        
        private Color _backgroundColor;

        public Color BackgroundColor
        {
            get => _backgroundColor;
            set => this.RaiseAndSetIfChanged(ref _backgroundColor, value);
        }
        
        private Color _comboBoxBackground;
        public Color ComboBoxBackground
        {
            get => _comboBoxBackground;
            set =>this.RaiseAndSetIfChanged(ref _comboBoxBackground, value);
            
        }
        
        private Color _comboBoxBackgroundOnHover;
        public Color ComboBoxBackgroundOnHover
        {
            get => _comboBoxBackgroundOnHover;
            set =>this.RaiseAndSetIfChanged(ref _comboBoxBackgroundOnHover, value);
            
        }
        
        private Color _barBackground;

        public Color BarBackground
        {
            get => _barBackground;
            set => this.RaiseAndSetIfChanged(ref _barBackground, value);
        }

        private Color _textAreaBackground;
        public Color TextAreaBackground
        {
            get => _textAreaBackground;
            set => this.RaiseAndSetIfChanged(ref _textAreaBackground, value);
        }

        private Color _textAreaForeground;
        public Color TextAreaForeground
        {
            get => _textAreaForeground;
            set => this.RaiseAndSetIfChanged(ref _textAreaForeground, value);
        }
        
        private Color _textAreaOverlayBackground;
        public Color TextAreaOverlayBackground
        {
            get => _textAreaOverlayBackground;
            set => this.RaiseAndSetIfChanged(ref _textAreaOverlayBackground, value);
        }

        public async void AddCell(AddViewModel vm)
        {
            vm.Cells.Add(new CodeCellViewModel(vm));
        }

        public static void DeleteCell(AddViewModel vm, CodeCellViewModel cell)
        {
            vm.Cells.Remove(cell);
        }
    }
}
