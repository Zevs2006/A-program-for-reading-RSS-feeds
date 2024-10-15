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

        // Список для хранения добавленных RSS-лент
        private BindingSource feedList = new BindingSource();

        // HttpClient для загрузки страниц
        private HttpClient httpClient = new HttpClient();

        // Обработчик нажатия кнопки "Добавить"
        private async void btnAddFeed_Click(object sender, EventArgs e)
        {
            string feedUrl = txtFeedUrl.Text.Trim();

            if (string.IsNullOrEmpty(feedUrl)) // Исправлено
            {
                MessageBox.Show("Введите корректный URL-адрес ленты.");
                return;
            }

            try
            {
                // Загружаем HTML-страницу по указанному URL
                var html = await httpClient.GetStringAsync(feedUrl);

                // Парсим HTML-документ
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); // Исправлено
                document.LoadHtml(html);

                // Ищем RSS-элементы (например, <item> или <entry>)
                var rssItems = document.DocumentNode.SelectNodes("//item");

                if (rssItems == null || rssItems.Count == 0)
                {
                    MessageBox.Show("RSS-элементы не найдены.");
                    return;
                }

                // Добавляем заголовки ленты в список
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

                MessageBox.Show("Лента успешно добавлена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить ленту: " + ex.Message);
            }
        }

        // Обработчик изменения выбранного элемента в списке лент
        private async void lstRSSFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRSSFeeds.SelectedItem == null) return;

            // Очищаем содержимое
            txtFeedContent.Clear();

            try
            {
                string feedUrl = txtFeedUrl.Text.Trim();
                var html = await httpClient.GetStringAsync(feedUrl);

                // Парсим HTML-документ
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); // Исправлено
                document.LoadHtml(html);

                // Ищем RSS-элементы (например, <item> или <entry>)
                var rssItems = document.DocumentNode.SelectNodes("//item");

                if (rssItems != null && lstRSSFeeds.SelectedIndex < rssItems.Count) // Исправлено
                {
                    var selectedItem = rssItems[lstRSSFeeds.SelectedIndex];

                    // Извлекаем контент выбранной статьи
                    var titleNode = selectedItem.SelectSingleNode("title");
                    var linkNode = selectedItem.SelectSingleNode("link");
                    var descriptionNode = selectedItem.SelectSingleNode("description");

                    txtFeedContent.AppendText("Заголовок: " + titleNode?.InnerText + Environment.NewLine);
                    txtFeedContent.AppendText("Ссылка: " + linkNode?.InnerText + Environment.NewLine);
                    txtFeedContent.AppendText("Описание: " + descriptionNode?.InnerText + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке содержимого: " + ex.Message);
            }
        }
    }
}
