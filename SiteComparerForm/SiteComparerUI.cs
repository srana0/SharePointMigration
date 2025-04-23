using SharePointSiteComparer;
using System;
using System.Net;
using System.Windows.Forms;

namespace SiteComparerForm
{
    public partial class siteComparerForm : Form
    {
        public siteComparerForm()
        {
            InitializeComponent();
        }

        private void siteComparerForm_Load(object sender, EventArgs e)
        {
        }

        private void btnComapreSites_Click(object sender, EventArgs e)
        {
            bool startComparsion = false;
            if (!startComparsion)
            {
                lblStatusMessage.Text = "Please wait... sie comparision is in progress";
                startComparsion = true;
            }

            if (startComparsion)
            {
                try
                {
                    string statusMessage = string.Empty;
                    bool isRecursiveCrawl = false;
                    lblStatusMessage.Text = "Please wait... site comparision is in progress";
                    if (txtSourceUrl.Text == null || txtSourceUrl.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter source Url");
                        return;
                    }
                    if (txtSourceUserName.Text == null || txtSourceUserName.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter source User Name");
                        return;
                    }
                    if (txtSourcePassword.Text == null || txtSourcePassword.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter source Password");
                        return;
                    }
                    if (txtSourceDomain.Text == null || txtSourceDomain.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter source Domain");
                        return;
                    }
                    string sourceUrl = txtSourceUrl.Text.ToString();
                    string sourceUserName = txtSourceUserName.Text.ToString();
                    string sourcePassword = txtSourcePassword.Text.ToString();
                    string sourceDomain = txtSourceDomain.Text.ToString();

                    NetworkCredential sourceCredential = new NetworkCredential(sourceUserName, sourcePassword, sourceDomain);

                    if (txtDestinationUrl.Text == null || txtDestinationUrl.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter destination Url");
                        return;
                    }
                    else if (txtDestinationUserName.Text == null || txtDestinationUserName.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter destination User Name");
                        return;
                    }
                    else if (txtDestinationPassword.Text == null || txtDestinationPassword.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter destination Password");
                        return;
                    }
                    else if (txtDestinationDomain.Text == null || txtDestinationDomain.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter destination Domain");
                        return;
                    }

                    string destinationUrl = txtDestinationUrl.Text.ToString();
                    string destinationUserName = txtDestinationUserName.Text.ToString();
                    string destinnationPassword = txtDestinationPassword.Text.ToString();
                    string destinationDomain = txtDestinationDomain.Text.ToString();

                    NetworkCredential destinationCredential = new NetworkCredential(destinationUserName, destinnationPassword, destinationDomain);

                    if (ckboxDocumentRecursiveStatus.Checked)
                    {
                        isRecursiveCrawl = true;
                    }

                    SiteComparer siteComparer = new SiteComparer(sourceUrl, sourceCredential, destinationUrl, destinationCredential, isRecursiveCrawl);
                    statusMessage = siteComparer.CompareSites();
                    lblStatusMessage.Text = statusMessage;
                }
                catch (Exception ex)
                {
                    lblStatusMessage.Text = ex.Message;
                }
                startComparsion = false;
            }
        }
    }
}