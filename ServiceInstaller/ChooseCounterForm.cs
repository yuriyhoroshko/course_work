using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingsProvider;

namespace ServiceInstaller
{
    public partial class ChooseCounterForm : Form
    {
        private string CounterName;
        private string CategoryName;
        private string InstanceName;
        private string CustomName;
        private int CustomDivider = 1;

        private readonly CounterProvider _counterProvider;
        private readonly MainForm _mainForm;

        private Thread _pollingThread;

        public ChooseCounterForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
            _counterProvider = new CounterProvider();
            
            instancesList.Enabled = false;
            countersList.Enabled = false;
            testCounterButton.Enabled = false;
            errorLabel.Visible = false;

            categoriesDropBox.Items.AddRange(_counterProvider.GetCategoriesList(categoriesDropBox.Text).ToArray());
        }

        private new void Dispose()
        {
            _pollingThread?.Abort();

            base.Dispose();
        }

        private void categoriesDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryName = (string)((ComboBox) sender).SelectedItem;

            instancesList.Items.Clear();
            instancesList.Items.AddRange(_counterProvider.GetInstancesList(CategoryName).ToArray());
            instancesList.Enabled = true;
            testCounterButton.Enabled = false;
            errorLabel.Visible = false;
            saveButton.Enabled = false;
        }

        private void categoriesDropBox_TextChanged(object sender, EventArgs e)
        {
            categoriesDropBox.Items.Clear();
            categoriesDropBox.Items.AddRange(_counterProvider.GetCategoriesList(categoriesDropBox.Text).ToArray());
        }

        private void instancesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            countersList.Enabled = true;
            testCounterButton.Enabled = false;
            errorLabel.Visible = false;
            saveButton.Enabled = false;
            countersList.Items.Clear();

            InstanceName = (string)((ComboBox) sender).SelectedItem;

            countersList.Items.AddRange(_counterProvider.GetCountersList(CategoryName, InstanceName).ToArray());
        }

        private void countersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CounterName = (string) ((ComboBox) sender).SelectedItem;
            _counterProvider.ChooseCounter(CategoryName, CounterName, InstanceName);

            testCounterButton.Enabled = true;
            saveButton.Enabled = true;
            errorLabel.Visible = false;
        }

        private void testCounterButton_Click(object sender, EventArgs e)
        {
            _pollingThread = new Thread(Poll);
            _pollingThread.Start();
        }

        private void Poll()
        {
            while (testCounterButton.Enabled && !this.IsDisposed)
            {
                counterValue.Invoke((MethodInvoker) delegate()
                {
                    counterValue.Text = _counterProvider.GetNextCounterValue().ToString();
                });

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var counter = new CounterIdentifier
            {
                Category = CategoryName,
                Counter = CounterName,
                Instance = InstanceName,
                CustomName = CustomName,
                CustomDivider = CustomDivider
            };

            if (_mainForm.AddNewCounter(counter))
            {
                Dispose();
            }

            errorLabel.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CustomName = ((TextBox) sender).Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CustomDivider = (int)((NumericUpDown) sender).Value;
        }
    }
}
