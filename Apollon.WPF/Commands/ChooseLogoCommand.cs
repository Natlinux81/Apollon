using Apollon.WPF.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace Apollon.WPF.Commands
{
    public class ChooseLogoCommand : CommandBase
    {

        private readonly AddEditDetailsViewModel _addEditDetailsViewModel;

        public ChooseLogoCommand(AddEditDetailsViewModel addEditDetailsViewModel)
        {
            _addEditDetailsViewModel = addEditDetailsViewModel;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Logo wählen",
                Filter = "Picture (.jpg) | *.jpg",
                
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {      
                _addEditDetailsViewModel.Logo = openFileDialog.FileName;
            }
        }
    }
}
