using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double height = double.Parse(txtHeight.Text);
                double weight = double.Parse(txtWeight.Text);
                double bmi = weight / Math.Pow(height, 2);

                double lowerLimit = 18.5 * Math.Pow(height, 2);
                double upperLimit = 24.9 * Math.Pow(height, 2);

                lblNormalRange.Text = $"محدوده ی وزنی مطلوب  : {lowerLimit:0.0}  تا  {upperLimit:0.0}  کیلوگرم است .";

                string bmiCategory;
                if (bmi < 18.5)
                    bmiCategory = "کمبود وزن";
                else if (bmi < 24.9)
                    bmiCategory = "نرمال";
                else if (bmi < 29.9)
                    bmiCategory = "اضافه وزن";
                else
                    bmiCategory = "چاقی";

                lblResult.Text = $"وضعیت فعلی شما در دسته ی {bmiCategory} است.";
            }
            catch {
                DialogResult result = MessageBox.Show("شما هنوز فیلد های مورد نظر را پر نکرده اید!آیا می خواهید از برنامه خارج شوید ؟ ", "warning", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                           Application.Exit();
             }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control allcontrol in Controls)
                {
                    if (allcontrol is TextBox)
                        ((TextBox)allcontrol).Clear();
                    else if (allcontrol is Label && (allcontrol.Name == "lblNormalRange" || allcontrol.Name == "lblResult"))
                        ((Label)allcontrol).Text = string.Empty;
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show("شما هنوز فیلد های مورد نظر را پر نکرده اید!آیا می خواهید از برنامه خارج شوید ؟ ", "warning", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("آیا می خواهید از برنامه خارج شوید ؟", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
   
}
