using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SystemResourceReporterService;

namespace ServiceInstaller
{
    public partial class LoginForm : Form
    {
        private readonly MainForm _mainForm;
        private string Token = String.Empty;

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _mainForm.SaveLoginDetails(userNameTextBox.Text, passwordTextBox.Text, Token);
            Dispose();
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
        }

        private async void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    var content =
                        new StringContent(
                            "{" + $"\"userName\": \"{userNameTextBox.Text}\",\"password\": \"{passwordTextBox.Text}\"" +
                            "}",
                            Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(Urls.BaseUrl + Urls.LoginUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var body = await GetBody(response);

                        Token = body.Token;
                        saveButton.Enabled = true;
                    }
                }
            }
            catch { }
        }

        private async Task<ResponseBody> GetBody(HttpResponseMessage response)
        {
            var str = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseBody>(str);
        }
    }
}
