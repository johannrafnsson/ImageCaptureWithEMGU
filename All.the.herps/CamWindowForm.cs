using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using DirectShowLib;
using Emgu.CV;
using Emgu.CV.UI;

namespace All.the.herps
{
    public partial class CamWindowForm : Form
    {
        private VideoCapture _capture;
        private DsDevice[] _SystemCameras;
        private ImageViewer viewer;

        public CamWindowForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void createImageViewer()
        {
            viewer = new ImageViewer
            {
                Location = new Point(200, 21),
                Width = 640,
                Height = 480,
                BackColor = Color.DeepPink,
                TopLevel = false
            };

            viewer.VisibleChanged += viewerVisibleChange;

            Controls.Add(viewer);
        }

        private void viewerVisibleChange(object sender, EventArgs e)
        {
            if (!viewer.Visible)
            {
                //TODO: trigger stop on the active camera button or some shit
            }
        }
         /// <summary>
         /// gets a list of the connected cams
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void btnGetCams_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> ListCamerasData = new List<KeyValuePair<int, string>>();

            _SystemCameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            int _DeviceIndex = 0;
            foreach (DsDevice _Camera in _SystemCameras)
            {
                ListCamerasData.Add(new KeyValuePair<int, string>(_DeviceIndex, _Camera.Name));
                _DeviceIndex++;
            }

            if (!ListCamerasData.Any())
            {
                MessageBox.Show("No cameras available, you twat");
                return;
            }
            
            int startTop = 62;
            foreach (var cam in ListCamerasData)
            {
                Button btn = new Button
                {
                    Text = cam.Value,
                    Name = $"camBtn{cam.Key}",
                    Location = new Point(12, startTop),
                    Size = new Size(116, 38),
                    TabIndex = cam.Key + 1,
                    UseVisualStyleBackColor = true
                };
                btn.Click += camBtnClick;
                Controls.Add(btn);

                startTop += 30;
            }
        }

        /// <summary>
        /// when camera button clicked. Duh ...
        /// Only tested this with one integrated cam on laptop. Could jsut as well blow to shits if more cams are connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void camBtnClick(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var camIndex = Convert.ToInt32(btn.Name.Replace("camBtn", ""));
            var orgCamBtnText = _SystemCameras[camIndex].Name;

            if (btn.Text != "STOP")
            {

                createImageViewer();

                viewer.Show();
                btnScreenshot.Show();

                _capture = new VideoCapture(camIndex);
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.XiFramerate, 30);
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);

                btn.Text = "STOP";

                Application.Idle += captureFrame;
            }
            else
            {
                viewer.Hide();
                btnScreenshot.Hide();

                Application.Idle -= captureFrame;

                btn.Text = orgCamBtnText;

                _capture.Stop();

                _capture?.Dispose();
            }
        }

        private void captureFrame(object sender, EventArgs e)
        {
            viewer.Image = _capture.QueryFrame();
        }

        /// <summary>
        /// grabs a screenshot from the imageviewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            Image renaultCaptur = viewer.Image.Bitmap;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                
                renaultCaptur.Save(string.IsNullOrEmpty(ext) ? $"{sfd.FileName}.jpg" : sfd.FileName, format);
            }
        }
    }
}
