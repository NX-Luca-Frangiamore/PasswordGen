
using Microsoft.AspNetCore.Http;
using System.Text.Json.Nodes;


namespace WinForms
{

    public partial class Profilo : Form
    {
        private string Token;
        public Profilo(string token, string username)
        {

            this.Token = token.Trim('"');
            this.Token = Token.Trim('/');

            InitializeComponent();
            Username.Text = username;
        }

        private async void ButtonGet_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders
                  .Add("Authorization", (string.Concat("Bearer ", Token)));
            var Response = client.GetAsync($"http://localhost:5034/api/password/get?namePassword={TextPasswordName.Text}");
            var R = await Response.Result.Content.ReadAsStringAsync();

            try
            {
                TextPassword.Text = (string)JsonObject.Parse(R)["password"];
            }
            catch (Exception ex) { MessageBox.Show(Response.Result.StatusCode + "\n" + R); }

        }

        private async void Profilo_Load(object sender, EventArgs e)
        {

        }

        private void TextPasswordName_TextChanged(object sender, EventArgs e)
        {

        }

        private async void ButtonCreate_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders
                  .Add("Authorization", (string.Concat("Bearer ", Token)));
            var Response = client.PutAsync($"http://localhost:5034/api/password/change?namePassword={TextPasswordName.Text}&passwordNew={TextPassword.Text}", null);
            var R = await Response.Result.Content.ReadAsStringAsync();

            MessageBox.Show(Response.Result.StatusCode + "\n" + R);
            TextPassword.Text = "";
        }

        private async void ButtonCreate_Click_1(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders
                  .Add("Authorization", (string.Concat("Bearer ", Token)));
            Task<HttpResponseMessage> Response;
            if (string.IsNullOrEmpty(TextPassword.Text))
                Response = client.PostAsync($"http://localhost:5034/api/password/new/hard?namePassword={TextPasswordName.Text}", null);
            else
                Response = client.PostAsync($"http://localhost:5034/api/password/new?namePassword={TextPasswordName.Text}&password={TextPassword.Text}", null);
            var R = await Response.Result.Content.ReadAsStringAsync();

            MessageBox.Show(Response.Result.StatusCode + "\n" + R);
            TextPassword.Text = "";
        }

        private void LabelPasswordName_Click(object sender, EventArgs e)
        {

        }

        private void TextPasswordName_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void LabelPassword_Click(object sender, EventArgs e)
        {
        }

        private void TextPassword_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
