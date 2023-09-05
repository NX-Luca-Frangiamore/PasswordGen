using System.Net;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LabelPassword_Click(object sender, EventArgs e)
        {

        }

        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var Response = client.PostAsync($"http://localhost:5034/login?username={TextUsername.Text}&password={TextPassword.Text}", null);
            new Profilo(await Response.Result.Content.ReadAsStringAsync(),TextUsername.Text).Show();
        }

        private async void ButtonSignIn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var Response = client.PostAsync($"http://localhost:5034/api/utente/new?username={TextUsername.Text}&password={TextPassword.Text}", null);
            var b = await Response.Result.Content.ReadAsStringAsync();
            MessageBox.Show(b);
        }
    }
}