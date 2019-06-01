using NApi32;
using System;
using System.Windows.Forms;

namespace LightBulb
{
    public partial class MainForm : Form
    {
        protected Api32Client Client { get; set; }
        protected bool State { get; set; }

        public MainForm()
        {
            InitializeComponent();
            
            Client = new Api32Client("http://192.168.0.100")
                .Authorize("master", "api32secret");

            lblIpAddress.Text = Client.Uri.Host;

            CheckState();

            btnLightBulbCtrl.MouseClick += (o, e) =>
            {
                var req = new LightBulbRequest { State = State ? 0 : 1 };

                Client.DoPostAsync<LightBulbResponse>("/lightbulb", req)
                    .ContinueWith(t =>
                    {
                        if (t.Exception != null)
                        {
                            ShowError(t.Exception.InnerException);
                        }
                        else
                        {
                            ShowState(t.Result.State);
                        }
                    });

            };
        }

        protected void CheckState()
        {
            Client.DoGetAsync<LightBulbResponse>("/lightbulb")
                .ContinueWith(t =>
                {
                    if(t.Exception != null)
                    {
                        ShowError(t.Exception.InnerException);
                    }
                    else
                    {
                        ShowState(t.Result.State);
                    }
                });
        }

        protected void ShowState(int state)
        {
            Invoke((Action)(() =>
            {
                btnLightBulbCtrl.Text = $"Turn {((State = state == 1) ? "OFF" : "ON")}";
                btnLightBulbCtrl.Enabled = true;
            }));
        }

        protected void ShowError(Exception ex)
        {
            Invoke((Action)(() => MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
        }
    }

    public class LightBulbRequest
    {
        public int State { get; set; }
    }
    
    public class LightBulbResponse
    {
        public string Device { get; set; }
        public int State { get; set; }
    }
}
