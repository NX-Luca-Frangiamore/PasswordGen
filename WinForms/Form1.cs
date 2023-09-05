using System.Net;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LabelPassword_Click(object sender, EventArgs e)
        {

        }

        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var Response=client.PostAsync($"http://localhost:5034/login?username={TextUser.Text}&password={TextPassword.Text}",null);
            var b=await Response.Result.Content.ReadAsStringAsync();
            MessageBox.Show(b);
        }
    }
}