using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MegaTaroCard
{
    /// <summary>
    /// Логика взаимодействия для gl.xaml
    /// </summary>
    public partial class gl : Page
    {
        private static readonly HttpClient client = new HttpClient();

        public gl()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            ((Main)Application.Current.MainWindow).MainFrame.Navigate(new MainWindow());
        }

        private async void OnGetAnswerClick(object sender, RoutedEventArgs e)
        {
            string question = QuestionInput.Text; // Убедитесь, что QuestionInput определен в XAML
            if (string.IsNullOrWhiteSpace(question))
            {
                MessageBox.Show("Введите вопрос.");
                return;
            }

            try
            {
                LoadingImage.Visibility = Visibility.Visible; // Показать индикатор загрузки

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
                            content = $"Ты — гадалка. Вычисли кармический код человека, вычислив ее по указанной дате рождения и имени. Расскажи человеку красиво о его предназначении. Не более 100 слов. {question}"
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
                AnswerOutput.Text = assistantResponse; // Убедитесь, что AnswerOutput определен в XAML
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                LoadingImage.Visibility = Visibility.Collapsed; // Скрыть индикатор загрузки
            }
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
        } // Закрывающая скобка для GetAccessTokenAsync

        private void OnNewQuestionClick(object sender, RoutedEventArgs e)
            {
                QuestionInput.Clear(); // Убедитесь, что QuestionInput определен в XAML
                AnswerOutput.Text = string.Empty; // Убедитесь, что AnswerOutput определен в XAML
            }

            private void QuestionInput_TextChanged(object sender, TextChangedEventArgs e)
            {

            }
        }
    }
