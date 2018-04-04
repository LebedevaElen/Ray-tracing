using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using static System.Math;

namespace CG_4
{
    public partial class MainForm : Form
    {
        FigureList FList = new FigureList();
        RayTracer RTracer = new RayTracer();
        Scene scn = new Scene();
        LightInfo Light = new LightInfo();
        Matrix4 perspective;

        float[] camera = new float[3];
        const double PiOver180 = PI / 180;
        bool isMouseHold = false;
        Point lastMouseCoordsAfterHolding;
        Point deltaCoords;

        bool isLoaded = false;

        int ChosenFigure;
        bool isChosen = false;
        
        string lastTextBoxText = "";
        TextBox errorTB = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            scn.FList = FList;
            UpdateLightInfo();
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            // set up the clear color
            GL.ClearColor(Color.Black);

            // set up the viewport
            GL.Viewport(0, 0, GLControl.Width, GLControl.Height);

            float width = (float)GLControl.Width;
            float height = (float)GLControl.Height;

            // set up the perspective projection matrix
            GL.MatrixMode(MatrixMode.Projection);
            perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver3,
                width / height, 1f, 10000.0f);
            GL.LoadMatrix(ref perspective);

            Light.Position = new Vector3(30, 30, 30);
            Light.La = new Vector3(1f);
            Light.Ld = new Vector3(1f);
            Light.Ls = new Vector3(1f);

            camera[0] = 33; // phi
            camera[1] = 15; // psi
            camera[2] = 45;

            scn.MaxRecursionLevel = (int)recursionDepth.Value;
            scn.Target = new Vector3(0f, 0f, 0f);
            scn.UpVector = new Vector3(0f, 0f, 1f);
            scn.zNear = 1f;
            scn.Teta = MathHelper.PiOver3;
            scn.Aspect = width / height;
            scn.Light = Light;

            Timer.Start();
        }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (isLoaded)
            {
                float r = camera[2];
                float CosPhi = (float)Cos(camera[0] * PiOver180),
                    CosPsi = (float)Cos(camera[1] * PiOver180),
                    SinPhi = (float)Sin(camera[0] * PiOver180),
                    SinPsi = (float)Sin(camera[1] * PiOver180);
                float[] lookAt = { r * CosPhi * CosPsi, r * SinPhi * CosPsi, r * SinPsi };

                if (!isTraced.Checked)
                {
                    GL.Enable(EnableCap.DepthTest);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref perspective);

                    GL.MatrixMode(MatrixMode.Modelview);
                    Matrix4 modelview = Matrix4.LookAt(lookAt[0], lookAt[1], lookAt[2], 0, 0, 0, 0, 0, 1);
                    GL.LoadMatrix(ref modelview);

                    foreach (var figure in FList)
                    {
                        figure.Draw();
                    }
                    if (isChosen)
                        FList[ChosenFigure].Choose();

                    GL.Disable(EnableCap.DepthTest);
                }
                else
                {
                    scn.Eye = new Vector3(lookAt[0], lookAt[1], lookAt[2]);
                    scn.Light = Light;
                    Cursor.Current = Cursors.WaitCursor;
                    RTracer.RayTrace(scn, GLControl.Width, GLControl.Height, 1);
                    Cursor.Current = Cursors.Default;
                }
            }

            GLControl.SwapBuffers();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Render();
            Timer.Stop();
        }

        private void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseHold && !isTraced.Checked)
            {
                camera[0] += deltaCoords.X - Cursor.Position.X;
                camera[1] += Cursor.Position.Y - deltaCoords.Y;
                camera[0] %= 360;
                if (camera[1] > 90) camera[1] = 90;
                if (camera[1] < -90) camera[1] = -90;
                deltaCoords = Cursor.Position;

                Render();
            }
        }

        private void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isTraced.Checked)
            {
                isMouseHold = false;
                Cursor.Show();
                Cursor.Position = lastMouseCoordsAfterHolding;

                Render();
            }
        }

        private void GLControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!isTraced.Checked)
            {
                if (e.Delta < 0 && camera[2] < 1000)
                    camera[2] *= 1.5f;
                else if (camera[2] > 1)
                    camera[2] /= 1.5f;

                Render();
            }
        }

        private void GLControl_MouseDown(object sender, MouseEventArgs e)
        {

            if (!isTraced.Checked)
            {
                isMouseHold = true;
                Cursor.Hide();
                lastMouseCoordsAfterHolding = Cursor.Position;
                deltaCoords = Cursor.Position;
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (FList.Count != 0)
            {
                string message = "Текущие объекты будут удалены. Чтобы добавить новые объекты, не удаляя существующие, возпользуйтесь кнопкой \"Добавить объекты\". \nПродолжить?";
                string caption = "Внимание";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                if (MessageBox.Show(message, caption, buttons) == DialogResult.Yes)
                    FList.Clear();
                else return;
            }

            addBtn_Click(sender, e);
        }

        private void isTraced_CheckedChanged(object sender, EventArgs e)
        {
            deleteBtn.Enabled = !deleteBtn.Enabled;
            Render();
        }

        private void recursionDepth_ValueChanged(object sender, EventArgs e)
        {
            scn.MaxRecursionLevel = (int)recursionDepth.Value;
            Render();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                isLoaded = true;
                FList.Input(openFileDialog.FileName);
            }

            Render();
        }

        private void deleteBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (deleteBtn.Checked && FList.Count > 0)
            {
                ChosenFigure = 0;
                isChosen = true;
                isTraced.Checked = false;
                tracingGroupBox.Enabled = false;
            }
            else
            {
                isChosen = false;
                tracingGroupBox.Enabled = true;
            }

            Render();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ActiveControl = GLControl;

            if (isChosen)
            {
                if (keyData == Keys.Right)
                {
                    if (FList.Count > 0)
                        ChosenFigure = (ChosenFigure + 1) % FList.Count;
                }
                else if (keyData == Keys.Left)
                {
                    if (FList.Count > 0)
                        ChosenFigure = ChosenFigure > 0 ? ChosenFigure - 1 : FList.Count - 1;
                }
                else if (keyData == Keys.Delete)
                {
                    if (FList.Count > 0)
                    {
                        FList.RemoveAt(ChosenFigure);
                        if (FList.Count == 0)
                            isChosen = false;
                        else
                            ChosenFigure = ChosenFigure > 0 ? ChosenFigure - 1 : FList.Count - 1;
                    }
                }
                Render();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lightPropertiesChanged(object sender, EventArgs e)
        {
            saveLightBtn.Enabled = true;
            lastTextBoxText = ((TextBox)sender).Text;
        }

        private void textboxLeave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(" ", "");
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace('.', ',');
            while (((TextBox)sender).Text.Contains(",,"))
                ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(",,", ",");

            float value, upperBound = 1, lowerBound = 0;
            if (!float.TryParse(((TextBox)sender).Text, out value))
            {
                if (errorTB != null)
                    errorTB.BackColor = Color.White;
                errorTB = (TextBox)sender;
                errorTB.Text = lastTextBoxText;
                errorTB.BackColor = Color.Red;
                tmrLimiter.Start();
            }
            else
            {
                if (((TextBox)sender).Parent == groupBox3)
                {
                    upperBound = float.MaxValue;
                    lowerBound = float.MinValue;
                }

                if (value > upperBound)
                {
                    if (errorTB != null)
                        errorTB.BackColor = Color.White;
                    errorTB = (TextBox)sender;
                    errorTB.Text = upperBound.ToString();
                    errorTB.BackColor = Color.Red;
                    tmrLimiter.Start();
                }
                else if (value < lowerBound)
                {
                    if (errorTB != null)
                        errorTB.BackColor = Color.White;
                    errorTB = (TextBox)sender;
                    errorTB.Text = lowerBound.ToString();
                    errorTB.BackColor = Color.Red;
                    tmrLimiter.Start();
                }
            }
        }

        private void saveLightBtn_Click(object sender, EventArgs e)
        {
            Light.Position = new Vector3(float.Parse(lightX.Text),
                float.Parse(lightY.Text), float.Parse(lightZ.Text));

            Light.La = new Vector3(float.Parse(LaR.Text), float.Parse(LaG.Text), float.Parse(LaB.Text));
            Light.Ld = new Vector3(float.Parse(LdR.Text), float.Parse(LdG.Text), float.Parse(LdB.Text));
            Light.Ls = new Vector3(float.Parse(LsR.Text), float.Parse(LsG.Text), float.Parse(LsB.Text));

            saveLightBtn.Enabled = false;

            Render();
        }

        private void UpdateLightInfo()
        {
            lightX.Text = Light.Position.X.ToString();
            lightY.Text = Light.Position.Y.ToString();
            lightZ.Text = Light.Position.Z.ToString();

            LaR.Text = Light.La.X.ToString();
            LaG.Text = Light.La.Y.ToString();
            LaB.Text = Light.La.Z.ToString();

            LdR.Text = Light.Ld.X.ToString();
            LdG.Text = Light.Ld.Y.ToString();
            LdB.Text = Light.Ld.Z.ToString();

            LsR.Text = Light.Ls.X.ToString();
            LsG.Text = Light.Ls.Y.ToString();
            LsB.Text = Light.Ls.Z.ToString();
        }

        private void tmrLimiter_Tick(object sender, EventArgs e)
        {
            if (errorTB.BackColor.G < 255)
                errorTB.BackColor = Color.FromArgb(255, (255 + errorTB.BackColor.G) / 2 + 1, (255 + errorTB.BackColor.B) / 2 + 1);
            else
                tmrLimiter.Stop();
        }
    }
}
