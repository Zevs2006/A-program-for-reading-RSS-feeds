using System;
using System.Net.Http;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace A_program_for_reading_RSS_feeds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ������ ��� �������� ����������� RSS-����
        private BindingSource feedList = new BindingSource();

        // HttpClient ��� �������� �������
        private HttpClient httpClient = new HttpClient();

        // ���������� ������� ������ "��������"
        private async void btnAddFeed_Click(object sender, EventArgs e)
        {
            string feedUrl = txtFeedUrl.Text.Trim();

            if (string.IsNullOrEmpty(feedUrl)) // ����������
            {
                MessageBox.Show("������� ���������� URL-����� �����.");
                return;
            }

            try
            {
                // ��������� HTML-�������� �� ���������� URL
                var html = await httpClient.GetStringAsync(feedUrl);

                // ������ HTML-��������
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); // ����������
                document.LoadHtml(html);

                // ���� RSS-�������� (��������, <item> ��� <entry>)
                var rssItems = document.DocumentNode.SelectNodes("//item");

                if (rssItems == null || rssItems.Count == 0)
                {
                    MessageBox.Show("RSS-�������� �� �������.");
                    return;
                }

                // ��������� ��������� ����� � ������
                feedList.Clear();
                foreach (var item in rssItems)
                {
                    var titleNode = item.SelectSingleNode("title");
                    if (titleNode != null)
                    {
                        feedList.Add(titleNode.InnerText);
                    }
                }

                lstRSSFeeds.DataSource = null;
                lstRSSFeeds.DataSource = feedList;

                MessageBox.Show("����� ������� ���������.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("�� ������� ��������� �����: " + ex.Message);
            }
        }

        // ���������� ��������� ���������� �������� � ������ ����
        private async void lstRSSFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRSSFeeds.SelectedItem == null) return;

            // ������� ����������
            txtFeedContent.Clear();

            try
            {
                string feedUrl = txtFeedUrl.Text.Trim();
                var html = await httpClient.GetStringAsync(feedUrl);

                // ������ HTML-��������
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); // ����������
                document.LoadHtml(html);

                // ���� RSS-�������� (��������, <item> ��� <entry>)
                var rssItems = document.DocumentNode.SelectNodes("//item");

                if (rssItems != null && lstRSSFeeds.SelectedIndex < rssItems.Count) // ����������
                {
                    var selectedItem = rssItems[lstRSSFeeds.SelectedIndex];

                    // ��������� ������� ��������� ������
                    var titleNode = selectedItem.SelectSingleNode("title");
                    var linkNode = selectedItem.SelectSingleNode("link");
                    var descriptionNode = selectedItem.SelectSingleNode("description");

                    txtFeedContent.AppendText("���������: " + titleNode?.InnerText + Environment.NewLine);
                    txtFeedContent.AppendText("������: " + linkNode?.InnerText + Environment.NewLine);
                    txtFeedContent.AppendText("��������: " + descriptionNode?.InnerText + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� �������� �����������: " + ex.Message);
            }
        }
    }
}
