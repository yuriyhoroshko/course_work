using SettingsProvider;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemResourceReporterService;

namespace ServiceInstaller
{
    public partial class MainForm : Form
    {
        private Settings _settings;

        private readonly Serializer _serializer;

        private string token = string.Empty;

        public MainForm()
        {
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);

                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    MessageBox.Show("Admin rights needed", "Not enough rights", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Dispose();
                }
            }

            InitializeComponent();

            _serializer = new Serializer();

            var readedSettings = _serializer.ReadSettings();

            if (readedSettings != null)
            {
                _settings = readedSettings;
                LoadDataFromSettings();
            }
            else 
                _settings = new Settings();
        }

        public bool AddNewCounter(CounterIdentifier counterIdentifier)
        {
            try
            {
                if (!_settings.CounterIdentifiers.Contains(counterIdentifier))
                {
                    _settings.CounterIdentifiers.Add(counterIdentifier);

                    addedList.Items.Add(counterIdentifier);

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public void SaveLoginDetails(string userName, string password, string token)
        {
            _settings.UserName = userName;
            _settings.Password = password;
            loginLabel.Text = $"Hi, {userName}";

            this.token = token;
        }

        private void addCounterButton_Click(object sender, EventArgs e)
        {
            var addCounterForm = new ChooseCounterForm(this);
            addCounterForm.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _settings.CollectionCycleSeconds = (int)((NumericUpDown) sender).Value;
        }

        private void dataUploadMinutes_ValueChanged(object sender, EventArgs e)
        {
            _settings.UploadCycleMinutes = (int)((NumericUpDown)sender).Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dirBrowser = new FolderBrowserDialog())
            {
                var result = dirBrowser.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _settings.FolderPath = dirBrowser.SelectedPath;
                    dirLabel.Text = dirBrowser.SelectedPath;
                }
            }
        }

        private async void installBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsAllSettingsSpecified())
                {
                    MessageBox.Show("Not all settings were set", "Not all settings specified", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                _serializer.StoreSettings(_settings);
                var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (await RegisterServer())
                {

                    var process = Process.Start(location + @"\SystemResourceReporterService.exe", "-install");
                    process.WaitForExit();
                }
                else
                {
                    MessageBox.Show(
                        "Registering server is not succeeded, nothing was installed, but your settings were stored, launch install tool again",
                        "Error registering server",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                Dispose();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message,
                    "Error while installing service",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDataFromSettings()
        {
            addedList.Items.AddRange(_settings.CounterIdentifiers.Select(c => c.ToString()).ToArray());
            collectionSeconds.Value = _settings.CollectionCycleSeconds;
            dataUploadMinutes.Value = _settings.UploadCycleMinutes;
            dirLabel.Text = _settings.FolderPath;
            pcNameTextBox.Text = _settings.ServerName;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(this);
            loginForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _settings.ServerName = (sender as TextBox).Text;
        }

        private async Task<bool> RegisterServer()
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent("{" + $"\"ipAddress\": \"{GetComputerIp()}\",\"serverName\": \"{_settings.ServerName}\"" + "}", Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", this.token);

                var response = await client.PostAsync(Urls.BaseUrl + Urls.AddServerUrl, content);

                return response.IsSuccessStatusCode;
            }
        }

        private string GetComputerIp()
        {
            return Dns.GetHostName();
        }

        private bool IsAllSettingsSpecified()
        {
            return _settings.GetType().GetProperties().Select(prop => prop.GetValue(_settings))
                .All(propValue => propValue != null);
        }
    }
}
