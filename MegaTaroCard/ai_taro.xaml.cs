using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using MegaTaroCard;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace MagicApp
{
    public partial class ai_taro : Page
    {
        private static readonly HttpClient client = new HttpClient();

        public ai_taro()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            InitializeComponent();

        }

        private async void OnGetAnswerClick(object sender, RoutedEventArgs e)
        {
            string question = QuestionInput.Text;
            if (string.IsNullOrWhiteSpace(question))
            {
                MessageBox.Show("Введите вопрос.");
                return;
            }

            try
            {
                LoadingImage.Visibility = Visibility.Visible; // Показываем изображение загрузки

                string token = await GetAccessTokenAsync();
                if (string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Не удалось получить токен доступа.");
                    return;
                }

                string apiUrl = "https://gigachat.devices.sberbank.ru/api/v1/chat/completions";
                var payload = new
                {
                    model = "GigaChat-Pro",
                    messages = new[]
                    {
                new
                {
                    role = "user",
                    content = $"Ты — гадалка на таро. Первой строкой ответа выведи рандомную карту из таро (больше ничего, только название карты). Название карты напиши с большой буквы (Каждое слово в названии карты с большой буквы). Не более 40 слов. А на следующей строке ответь на этот вопрос по карте которую написал ранее, ответь подробно на вопрос: {question}"
                }
            },
                    stream = false,
                    repetition_penalty = 1
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<dynamic>(responseBody);

                string assistantResponse = json.choices[0].message.content?.ToString();
                AnswerOutput.Text = assistantResponse;

                // Извлечение названия карты
                string cardName = ExtractCardName(assistantResponse);
                if (!string.IsNullOrEmpty(cardName))
                {
                    ShowCardImage(cardName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                LoadingImage.Visibility = Visibility.Collapsed;
            }
        }
        private void ShowCardImage(string cardName)
        {


            string imagePath = $"./fook/{cardName}.jpg";

            if (System.IO.File.Exists(imagePath))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute); // Убедитесь, что путь абсолютный
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // Загружаем изображение сразу
                bitmap.EndInit();

                Image cardImage = new Image
                {
                    Source = bitmap,
                    Width = 200,
                    Height = 330
                };

                CardImagePanel.Children.Clear();
                CardImagePanel.Children.Add(cardImage);
            }
            else
            {
                MessageBox.Show("Изображение карты не найдено: " + cardName);
            }
        }
        private string ExtractCardName(string response)
        {
            var lines = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0)
            {
                return lines[0].Trim().ToLower();
            }
            return null;
        }


        private async Task<string> GetAccessTokenAsync()
        {
            try
            {
                string tokenUrl = "https://ngw.devices.sberbank.ru:9443/api/v2/oauth";
                var requestContent = new StringContent("scope=GIGACHAT_API_PERS", Encoding.UTF8, "application/x-www-form-urlencoded");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("RqUID", Guid.NewGuid().ToString());
                client.DefaultRequestHeaders.Add("Authorization", "Basic YTRlZjdiM2MtYTFlMi00MzlmLWE4NjUtNzFmNjQ4ZTU0OWFhOjU4Zjk3OTY4LTdkMzUtNDBmMS1iMzEzLTcwMTkyMGZlZTMwOQ==");

                var response = await client.PostAsync(tokenUrl, requestContent);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<dynamic>(responseBody);
                return json.access_token?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении токена: {ex}");
                return null;
            }
        }

        private void OnNewQuestionClick(object sender, RoutedEventArgs e)
        {
            QuestionInput.Clear();
            AnswerOutput.Text = string.Empty;
        }


        private void GoBack(object sender, RoutedEventArgs e)
        {
            ((Main)Application.Current.MainWindow).MainFrame.Navigate(new MainWindow());
        }

        private void QuestionInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
