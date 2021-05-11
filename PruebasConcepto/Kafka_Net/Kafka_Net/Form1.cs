using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kafka_Net
{
    public partial class Form1 : Form
    {
        Uri uri = new Uri("http://localhost:9092");
        string topic = "chat-message";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text ==string.Empty)
            {
                MessageBox.Show("Please Enter Message","Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            string payload = txtMessage.Text.Trim();
            var sendMessage = new Thread(() => {
                KafkaNet.Protocol.Message msg = new KafkaNet.Protocol.Message(payload);
                var options = new KafkaOptions(uri);
                var router = new BrokerRouter(options);
                var client = new Producer(router);
                client.SendMessageAsync(topic, new List<KafkaNet.Protocol.Message> { msg }).Wait();
            });
            sendMessage.Start();
            this.Clear();
        }
        void Clear()
        {
            this.txtMessage.Text = string.Empty;
            this.txtMessage.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
