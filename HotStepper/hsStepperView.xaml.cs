using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace HotStepper
{
    public partial class hsStepperView : ContentView
    {

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(
             propertyName: "Text",
              returnType: typeof(int),
              declaringType: typeof(hsStepperView),
              defaultValue: 1,
              defaultBindingMode: BindingMode.TwoWay);

        public int? Max { get; set; }

        public int Increment { get; set; } = 1;

        public int Text
        {
            get { return (int)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Color ButtonColor { get; set; } = Color.Black;

        public Color LabelColor { get; set; } = Color.Black;

        public hsStepperView()
        {
            InitializeComponent();
            lblValue.SetBinding(Label.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
        }

        void btnPlus_Clicked(object sender, System.EventArgs e)
        {
            if (Max == null)
            {
                Text += Increment;
            }
            else if (Text < Max)
            {
                Text += Increment;
            }

        }

        void btnMinus_Clicked(object sender, System.EventArgs e)
        {
            if ((Text - Increment) > 1)
                Text -= Increment;
            else
                Text = 0;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextProperty.PropertyName)
            {
                lblValue.Text = Text.ToString();
            }
        }
    }
}
