using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace VTEP_Teszt
{
    /*
     * Torekedtem MVC pattern menten dolgozni. 
     * 
     */

    public partial class VTEPForm : Form
    {
        private Controller Controller;
        private System.Windows.Forms.Timer ResponseProcess;
        private bool Started = false;
        public VTEPForm()
        {
            Controller = new Controller();
            ResponseProcess = new System.Windows.Forms.Timer();
            ResponseProcess.Interval = (100);
            ResponseProcess.Tick += ResponseProcessing;
            InitializeComponent();
        }


        /*

        A Model Queue.jabol kiolvasni a es feldolgozni a visszateresi ertekeket. Ha menetkozben modosul a Queue akkor sem all meg a feldolgozas.

         */
        private void ResponseProcessing(object sender, EventArgs e)
        {


            ref Queue<string> ResponseQueue = ref Controller.GetQueue();

            while (ResponseQueue.Count != 0)
            {
                string ErrorCode = ResponseQueue.Dequeue();
                if (Controller.Validate(ErrorCode))
                {
                    txtResponseModify(ErrorCode + " Megfelelõ");
                }
                else
                {
                    txtResponseModify(ErrorCode + " NEM Megfelelõ");
                }

            }



        }

        private void txtResponseModify(string Text)
        {
            txtResponse.AppendText(Text + Environment.NewLine);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Started)
            {
                Controller.Stop();
                btnStart.Text = "START";
                ResponseProcess.Stop();
                Started = false;
                lbStatus.Text = "Lekérés megállítva.";

            }
            else
            {
                Controller.Start();
                btnStart.Text = "STOP";
                ResponseProcess.Start();
                Started = true;
                lbStatus.Text = "Lekérés elindítva.";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Mentés megkezdése.";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text féjl|*.txt|Log fájl|*.log";
            saveFileDialog1.Title = "Eredmény mentése";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                Controller.Save(txtResponse.Text, saveFileDialog1.FileName);
            }
        }

        public void SetStatus(string Status)
        {
            lbStatus.Text = Status;
        }

    }
}