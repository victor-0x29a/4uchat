using Newtonsoft.Json;
using SocketIOClient;
using SocketIOClient.Transport;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            //MessageBox.Show("Conectado!", "W3APP");
        }

        public async void SendMessage(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var objeto = new { Content = MessageSender.Text };
                string json = JsonConvert.SerializeObject(objeto);
                await socket.EmitAsync("Message", json);
                MessageSender.Text = "";
                String[] Nothing = { "" };
                MessageSender.Lines = Nothing;
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
                String Content = Environment.NewLine + DataSerialized.From + ": " + DataSerialized.Content;
                Messages.Font = new Font(Messages.Font, FontStyle.Bold);
                Messages.AppendText(DataSerialized.From + "  ");
                Messages.Font = new Font(Messages.Font, FontStyle.Regular);
                Messages.AppendText(DataSerialized.Content + Environment.NewLine);
            });

            socket.On("rejectNick", (data) =>
            {
                MessageBox.Show("Confira o nickname digitado!", AppName);
            });

            socket.On("acceptedNick", (data) =>
            {
                String DataSerialized = JsonConvert.DeserializeObject<String[]>(data.ToString())[0];
                NickName = DataSerialized;
                MessageBox.Show("Nickname alterado!", AppName);
            });

            socket.On("UsersConnecteds", (data) =>
            {
                String DataSerialized = JsonConvert.DeserializeObject<String[]>(data.ToString())[0];
                onlinetext.Text = DataSerialized + " online";
            });

            socket.On("UserConnected", (data) =>
            {
                String DataSerialized = JsonConvert.DeserializeObject<String[]>(data.ToString())[0];
                Messages.AppendText(DataSerialized + " entrou na sala." + Environment.NewLine);
            });

            socket.On("UserDisconnected", (data) =>
            {
                String DataSerialized = JsonConvert.DeserializeObject<String[]>(data.ToString())[0];
                Messages.AppendText(DataSerialized + " saiu da sala." + Environment.NewLine);
            });

            socket.On("UserTyping", async (data) =>
            {
                String SocketID = JsonConvert.DeserializeObject<String[]>(data.ToString())[1];
                String UserName = JsonConvert.DeserializeObject<String[]>(data.ToString())[0];
                if (SocketID != socket.Id.ToString())
                {
                    LabelTyping.Text = UserName + " está digitando...";
                    await Task.Delay(1800);
                    LabelTyping.Text = "";
                }
                

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
            else
            {
                if (datanickname.Text.Length > 25)
                {
                    MessageBox.Show("Confira o nick digitado.", AppName);
                    return;
                }
                await socket.EmitAsync("ChangeNick", datanickname.Text);
            }
        }

        public async void SendTyping(object sender, EventArgs e)
        {
            if (SocketConnected && MessageSender.Text.Length > 2)
            {
                await socket.EmitAsync("Typing");
            }
        }
        public async void ConnectToServer(object Sender, EventArgs e)
        {
            if (NickName.Length < 1 || NickName.Length > 25)
            {
                MessageBox.Show("Confira seu nickname!", AppName);
                return;
            }

            if (SocketConnected)
            {
                await socket.DisconnectAsync();
                connectbutton.Text = "Conectar";
                connectbutton.BackColor = Color.FromArgb(128, 255, 128);
                SocketConnected = false;
                onlinetext.Text = "";
                MessageBox.Show("Desconectado!", AppName);
                return;
            }

            connectbutton.Text = "Desconectar";
            connectbutton.BackColor = Color.Red;

            await On();
        }
    }
}