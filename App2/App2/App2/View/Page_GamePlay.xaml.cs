using App2.Model;
using App2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_GamePlay : ContentPage
    {

     //   public GameInfo EnteredInfo { get; private set; }

        public Page_GamePlay(GameInfo enteredInfo)
        {
            InitializeComponent();

            BindingContext = new VM_GamePlay(enteredInfo);
        }
    }
}