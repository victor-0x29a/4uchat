using Newtonsoft.Json;
using SocketIOClient;
using SocketIOClient.Transport;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Chatv2
{

    public partial class Form1 : Form
    {

        class Response
        {
            public String From;
            public String Content;
        }

        private readonly static string addressServer = "127.0.0.1:1337";
        private static string websocketAddress = "http://" + addressServer;
        private static SocketIO socket;
        private bool SocketConnected = false;
        private string NickName;
        private readonly static string AppName = "4uChat";


        private static void OnConnectedHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Conectado!", "W3APP");
        }

        public async void SendMessage(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var objeto = new { Content = MessageSender.Text };
                string json = JsonConvert.SerializeObject(objeto);
                await socket.EmitAsync("Message", json);
                MessageSender.Text = "";
            }
        }

        public async Task On()
        {
            var queryParameters = new Dictionary<string, string>
        {
            { "name", NickName }
        };
            var options = new SocketIOOptions
            {
                Query = queryParameters
            };
            socket = new SocketIO(websocketAddress, options);

            socket.OnConnected += OnConnectedHandler;

            socket.On("MessageReceiv", (data) =>
            {

                var DataReceived = data.ToString();
                Response DataSerialized = JsonConvert.DeserializeObject<Response[]>(DataReceived)[0];
                Messages.SelectionFont = new Font(Messages.Font, FontStyle.Bold);
                Messages.AppendText("\n" + DataSerialized.From + "  ");
                Messages.SelectionFont = new Font(Messages.Font, FontStyle.Regular);
                Messages.AppendText(DataSerialized.Content);
            });
            await socket.ConnectAsync();
            SocketConnected = true;

        }

        public Form1()
        {
            InitializeComponent();
        }

        public async void SaveModify(object Sender, EventArgs e)
        {
            if (SocketConnected == false)
            {
                NickName = datanickname.Text;
                MessageBox.Show("Alterações salvas.", AppName);
            }
        }

        public async void ConnectToServer(object Sender, EventArgs e)
        {
            if (datanickname.Text.Length < 1 || datanickname.Text.Length > 25)
            {
                MessageBox.Show("Confira seu nickname!", AppName);
                return;
            }

            if (SocketConnected)
            {
                MessageBox.Show("Você já está conectado.", AppName);
                return;
            }

            await On();
        }
    }
}