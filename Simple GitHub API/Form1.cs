using Octokit;
using System.Windows.Forms;

namespace Simple_GitHub_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.MouseDown += TextBox1_MouseDown;
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = System.Drawing.Color.Black;
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
            string uName = textBox1.Text;
            if (uName.Equals("") || uName.Equals("Enter GitHub User Name"))
            {
                textBox1.ForeColor = System.Drawing.Color.Red;
                label2.Text = "Error:";
                label1.Text = "Please enter user name.";
            }
            else
            {
                label2.Text = "User Info:";
                label1.Text = "Please wait...";
                try
                {
                    var github = new GitHubClient(new ProductHeaderValue("SimpleGitHubAPI"));
                    var user = await github.User.Get(uName);
                    label3.Text = "Notes:"
                        + "\n1. Date format: MM/DD/YYYY"
                        + "\n2. Info not provided by the user will not be displayed."
                        + "\n3. If E-mail ID of user is private, then if will not be displayed."
                        + "\n4. If account type is Orgainization, \n     then value of followers and following may be zero.";
                    label2.Text = user.Login + "'s Info:";
                    label1.Text = "Name: " + user.Name
                        + "\nSystem-wide ID: " + user.Id
                        + "\nE-mail: " + user.Email
                        + "\nAccount Type: " + user.Type
                        + "\nFollowers: " + user.Followers
                        + "\nFollowing: " + user.Following
                        + "\nTotal Public Repos: " + user.PublicRepos
                        + "\nTotal Private Repos: " + user.TotalPrivateRepos
                        + "\nCreated at: " + user.CreatedAt;
                }
                catch
                {
                    label2.Text = "Error:";
                    label1.Text = "1. Please check internet connection."
                        + "\n2. Please check the user name.";
                }
            }
        }
    }
}
