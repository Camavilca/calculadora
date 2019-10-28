using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModel
{
    public class Comandos : ViewModelBase
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        string result;
        public string Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand Onseven { protected set; get; }
        public ICommand Oneight { protected set; get; }
        public ICommand Onnine { protected set; get; }
        public ICommand Onfour { protected set; get; }
        public Comandos()
        {

            Onseven = new Command(() => {
                OnSelectNumber("7");
            });
            Oneight = new Command(() => {
                OnSelectNumber("8");
            });
            Onnine = new Command(() => {
                OnSelectNumber("9");
            });
            Onfour = new Command(() => {
                OnSelectNumber("4");
            });

           

        }


        void OnSelectNumber(string ingresa)
        {
            if(this.Result == "0" || currentState < 0)
            {
                this.Result = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.Result += ingresa;

            double numero;
            if (double.TryParse(this.Result , out numero))
            {
               // this.Result = numero.ToString("NO");
                if(currentState == 1)
                {
                    firstNumber = numero;
                }
                else
                {
                    secondNumber = numero;
                }
            }

        }
        
    }
}
