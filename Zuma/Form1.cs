using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Zuma
{
    public class CACtor
    {
        public int XD, YD;
        public Bitmap im;
        public int XS, YS;
    }
    public class CImages
    {
        public float xs, ys, xe, ye, dx, dy, m, pm, b2, b3, currX, currY, x2, y2, px, py, px2, py2, distancex, distancey,f=0;
        int Speed = 20;

        public PointF S, Y;
        public int W, H;
        public Boolean remove = false;
        public int d;
        public Bitmap im;
        public Graphics g2;
        public float my_t_inForm = 0.000001f;
        public PointF carPoint;
        public int color;
        public Boolean shot = false;
        int pos;

        public void SetVals(float a, float b, float c, float d)
        {
            xs = a;
            ys = b;
            xe = c;
            ye = d;
            
            dx = xe - xs;
            dy = ye - ys;
            m = dy / dx;

            currX = xs;
            currY = ys;
            x2 = currX + dx / 4;
            b2 = -m * xs + ys;
            y2 = m * (x2) + b2;

            pm = -1 / m;
            distancex = Math.Abs(x2 - currX);
            distancey = Math.Abs(y2 - currY);


            px = (Math.Abs(x2 + currX) / 2);
            py = (Math.Abs(y2 + currY) / 2);
            if (distancex > distancey)
            {
                py2 = py + 150;
                b3 = -pm * px + py;
                px2 = (py2 - b3) / pm;
            }
            if (distancex < distancey)
            {
                px2 = px + 150;
                b3 = -pm * px + py;
                py2 = pm * (px2) + b3;
            }
        }
        public void MoveStep(List<CImages> Balls, BezierCurve obj, ref int f4,ref int pos)
        {
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (xs < xe && ys < ye)
                {
                    currX += Speed;
                    currY += m * Speed;
                    x2 += Speed;
                    y2 += m * Speed;
                    px2 += Speed;
                    py2 += m * Speed;
                    px += Speed;
                    py += m * Speed;

                }
                else if (xs < xe && ys > ye)
                {
                    currX += Speed;
                    currY += m * Speed;
                    x2 += Speed;
                    y2 += m * Speed;
                    px2 += Speed;
                    py2 += m * Speed;
                    px += Speed;
                    py += m * Speed;
                }
                else if (xs > xe && ys < ye)
                {
                    currX -= Speed;
                    currY -= m * Speed;
                    x2 -= Speed;
                    y2 -= m * Speed;
                    px2 -= Speed;
                    py2 -= m * Speed;
                    px -= Speed;
                    py -= m * Speed;
                }
                else if (xs > xe && ys > ye)
                {
                    currX -= Speed;
                    currY -= m * Speed;
                    x2 -= Speed;
                    y2 -= m * Speed;
                    px2 -= Speed;
                    py2 -= m * Speed;
                    px -= Speed;
                    py -= m * Speed;
                }
            }
            else
            {
                if (xs < xe && ys < ye)
                {
                    currY += Speed;
                    currX += 1 / m * Speed;
                    y2 += Speed;
                    x2 += 1 / m * Speed;
                    py2 += Speed;
                    px2 += 1 / m * Speed;
                    py += Speed;
                    px += 1 / m * Speed;
                }
                else if (xs < xe && ys > ye)
                {
                    currY -= Speed;
                    currX -= 1 / m * Speed;
                    y2 -= Speed;
                    x2 -= 1 / m * Speed;
                    py2 -= Speed;
                    px2 -= 1 / m * Speed;
                    py -= Speed;
                    px -= 1 / m * Speed;
                }
                else if (xs > xe && ys < ye)
                {
                    currY += Speed;
                    currX += 1 / m * Speed;
                    y2 += Speed;
                    x2 += 1 / m * Speed;
                    py2 += Speed;
                    px2 += 1 / m * Speed;
                    py += Speed;
                    px += 1 / m * Speed;
                }
                else if (xs > xe && ys > ye)
                {
                    currY -= Speed;
                    currX -= 1 / m * Speed;
                    y2 -= Speed;
                    x2 -= 1 / m * Speed;
                    py2 -= Speed;
                    px2 -= 1 / m * Speed;
                    py -= Speed;
                    px -= 1 / m * Speed;
                }
            }
            float space = 0;
            for (int i = 0; i < Balls.Count; i++)
            {
                if (xe < 1060)
                {
                    if (currX >= Balls[i].S.X && currX <= Balls[i].S.X + 50 && Balls[i].shot == false)
                    {
                        if (currY >= Balls[i].S.Y && currY <= Balls[i].S.Y + 50 && Balls[i].shot == false)
                        {
                            f4 = 1;
                            for (int j = 0; j < Balls.Count; j++)
                            {
                                if (Balls[j].shot == true)
                                {
                                    Balls[j].shot = false;
                                    Balls.Insert(i, Balls[j]);
                                    pos = i;
                                    f4 = 1;

                                    Balls.RemoveAt(j + 1);
                                    if (i != 0)
                                    {
                                        Balls[i].my_t_inForm = Balls[i - 1].my_t_inForm;

                                        space = Balls[i].my_t_inForm;
                                        while (space < Balls[i].my_t_inForm + (0.0016f) * 10)
                                        {
                                            for (int z = i - 1; z >= 0; z--)
                                            {
                                                Balls[z].my_t_inForm += 0.0016f;
                                            }
                                            space += 0.0016f;

                                        }
                                    }
                                    else
                                    {
                                        Balls[i].my_t_inForm = Balls[i + 1].my_t_inForm + (0.0016f) * 10;
                                    }

                                }
                            }
                        }
                        
                    }
                    
                }
                else if (xe >= 1060)
                {
                    if (currX + 50 >= Balls[i].S.X && currX + 50 <= Balls[i].S.X + 50 && Balls[i].shot == false)
                    {
                        if (currY + 50 >= Balls[i].S.Y && currY + 50 <= Balls[i].S.Y + 50 && Balls[i].shot == false)
                        {
                            // MessageBox.Show("collision");
                            f4 = 1;
                            for (int j = 0; j < Balls.Count; j++)
                            {
                                if (Balls[j].shot == true)
                                {
                                    Balls[j].shot = false;
                                    Balls.Insert(i, Balls[j]);
                                    pos = i;
                                    Balls.RemoveAt(j + 1);
                                    Balls[i].my_t_inForm = Balls[i + 1].my_t_inForm;
                                    space = Balls[i].my_t_inForm;
                                    while (space > Balls[i].my_t_inForm - (0.0016f) * 10)
                                    {
                                        for (int z = i + 1; z < Balls.Count; z++)
                                        {
                                            Balls[z].my_t_inForm -= 0.0016f;
                                        }
                                        space -= 0.0016f;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
        public void SetToCurve(List<CImages> Balls, BezierCurve obj, ref int f4,ref int ct2)
        {
            if (f4 == 0)
            {
                for (int i = 0; i < obj.curvepoints.Count; i++)
                {
                    if (currX >= obj.curvepoints[i].X && currX <= obj.curvepoints[i].X + 10)
                    {
                        if (currY >= obj.curvepoints[i].Y && currY <= obj.curvepoints[i].Y + 10)
                        {
                            for (int j = 0; j < Balls.Count; j++)
                            {
                                if (Balls[j].shot == true)
                                {
                                    ct2--;
                                    //Balls[j].my_t_inForm = obj.curveT[i];
                                    //Balls[j].shot = false;
                                    Balls.RemoveAt(j);
                                    break;
                                }
                            }
                        }
                    }
                    if (currX + 50 >= obj.curvepoints[i].X && currX + 50 <= obj.curvepoints[i].X + 10)
                    {
                        if (currY >= obj.curvepoints[i].Y && currY <= obj.curvepoints[i].Y + 10)
                        {
                            for (int j = 0; j < Balls.Count; j++)
                            {
                                if (Balls[j].shot == true)
                                {
                                    ct2--;
                                    //Balls[j].my_t_inForm = obj.curveT[i];
                                    //Balls[j].shot = false;
                                    Balls.RemoveAt(j);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void SimilarBalls(List<CImages> Balls,ref int ct2,ref int f4, int pos)
        {
            if (f4 == 1)
            {
                //Balls.Sort((a, b) => {
                //    if (a.my_t_inForm < b.my_t_inForm) return -1;
                //    if (a.my_t_inForm > b.my_t_inForm) return 1;
                //    return 0;
                //});
                int col = Balls[pos].color;
                int count = 1;
                int i;
                for (i = pos + 1; i < Balls.Count; i++)
                {
                    if(Balls[i].color!=col)
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                for (i = pos - 1; i >=0; i--)
                {
                    if (Balls[i].color != col)
                    {
                        i += 1;
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if(i==-1)
                {
                    i = 0;
                }
                if(count>=3)
                {
                    //while(Balls[i].color == col)
                    for (int j = 0; j < count; j++)
                    {
                        Balls.RemoveAt(i);
                        ct2--;
                    }
                    
                }

            }
        }
    }
    public partial class Form1 : Form
    {
        Bitmap off;
        CACtor pnn = new CACtor();
        CImages pnn2 = new CImages();
        CImages pnn3 = new CImages();
        CImages pnn4 = new CImages();
        CImages death = new CImages();

        public List<CImages> Balls = new List<CImages>();
        Timer tt = new Timer();
        float xRef = 1;
        float yRef = 1; 
        double rotationAngle = 0;
        PointF carPoint;
        Graphics g2;
        int last;
        enum Modes { CTRL_POINTS, DRAG };
        Modes CurrentMouseMode = Modes.CTRL_POINTS;
        public BezierCurve obj = new BezierCurve();
        int numOfCtrlPoints = 0;
        public int f = 1, f2 = 0, f4 = 0;
        int ct = 0;
        int ct2 = 0;
        int pos;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Load += Form1_Load1;
            tt.Tick += Tt_Tick;
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.KeyDown += Form1_KeyDown;
            tt.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (f2 == 0)
                {
                    Random rd = new Random();
                    int rand_num = rd.Next(1, 7);
                    Bitmap im = new Bitmap("ball" + rand_num + ".png");
                    im.MakeTransparent(im.GetPixel(0, 0));

                    pnn4 = new CImages();
                    pnn4.im = im;
                    pnn4.S.X = pnn2.S.X + pnn2.W / 2 - 50;
                    pnn4.S.Y = pnn2.S.Y + pnn2.H - 40;
                    pnn4.W = 50;
                    pnn4.H = 50;
                    pnn4.color = rand_num;
                    pnn4.shot = true;
                    f2 = 1;
                }
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (f2 == 1)
            {
                f2 = 0;
                Balls.Add(pnn4);
                pnn4.SetVals(pnn4.S.X, pnn4.S.Y, e.X, e.Y);
                last = Balls.Count -1; 
                ct2++;
                DrawDubb(this.CreateGraphics());
                
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            double y = e.Y;
            double x = e.X;
            double X = pnn2.S.X + pnn2.W / 2;
            double Y = pnn2.S.Y + pnn2.H / 2;
            rotationAngle = (float)(Math.Atan2(y - Y, x - X) * 180 / Math.PI);
            if (f2 == 1)
            {
                pnn4.S.X = (float)(80 * Math.Cos(Math.PI / 180 * rotationAngle) + pnn2.S.X + pnn2.W / 2) - pnn4.W / 2;
                pnn4.S.Y = (float)(80 * Math.Sin(Math.PI / 180 * rotationAngle) + pnn2.S.Y + pnn2.H / 2) - pnn4.H / 2;
            }
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            if(f==1)
            {
                try
                {
                    for (int i = 0; i < Balls.Count; i++)
                    {
                        if (Balls[i].shot == false)
                        {
                            //if (Balls[i].S.Y > 500)
                            {
                                // Balls[i].my_t_inForm += 0.01f;
                            }
                            //else
                            {
                                Balls[i].my_t_inForm += 0.0016f;//0.0031f
                            }
                        }
                        else
                        {
                            Balls[i].MoveStep(Balls, obj, ref f4, ref pos);
                            Balls[i].SetToCurve(Balls, obj, ref f4, ref ct2);
                            if (i < Balls.Count)
                            {
                                Balls[i].SimilarBalls(Balls, ref ct2, ref f4, pos);
                            }
                            f4 = 0;
                        }
                        if (Balls[i].S.X > ClientSize.Width / 2 + ClientSize.Width / 4 + 330)
                        {
                            tt.Stop();
                            MessageBox.Show("Game Over");
                            

                        }
                    }
                }
                catch (Exception){ }
               
                //Balls[0].SimilarBalls(Balls, ref ct2, ref f4, pos);
            }
            
            ct++;
            DrawDubb(this.CreateGraphics());
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            
            SoundPlayer simpleSound = new SoundPlayer(@"ZumasRevenge-introwav.wav"); 
            simpleSound.Play();
            
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            
            pnn.XD = 0;
            pnn.YD = 0;
            pnn.XS = 0;
            pnn.YS = 0;
            pnn.im = new Bitmap("BG3.jpg");
            
            Bitmap im = new Bitmap("frog5.png");
            //im.MakeTransparent(im.GetPixel(0, 0));
            pnn2.im = im;
            pnn2.S.X = (ClientSize.Width / 2) - 125 ;
            pnn2.S.Y = 5;//100
            pnn2.W = 250;
            pnn2.H = 250;
            g2 = Graphics.FromImage(im);

            Bitmap im2 = new Bitmap("death.png");
            //im.MakeTransparent(im.GetPixel(0, 0));
            death.im = im2;
            death.S.X = ClientSize.Width / 2 + ClientSize.Width / 4 + 330;
            death.S.Y = 0;//100
            death.W = 250;
            death.H = 250;
            g2 = Graphics.FromImage(im);

            obj.SetControlPoint(new Point(ClientSize.Width / 4 - 400, 0));
            numOfCtrlPoints++;
            obj.SetControlPoint(new Point(ClientSize.Width / 2, 1500));
            numOfCtrlPoints++;
            obj.SetControlPoint(new Point(ClientSize.Width / 2 + ClientSize.Width / 4 + 400, 0));
            numOfCtrlPoints++;
         
            MessageBox.Show("press space to show the ball then click to shoot");

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        void DrawScene(Graphics g )
        {
            g.Clear(Color.White);

            Rectangle rcDest = new Rectangle(pnn.XD, pnn.YD,
                                               ClientSize.Width, ClientSize.Height);

            Rectangle rcSrc = new Rectangle(pnn.XS, pnn.YS,
                                            pnn.im.Width, pnn.im.Height);
            g.DrawImage(pnn.im,
                        rcDest, rcSrc,
                        GraphicsUnit.Pixel
                        );
            obj.DrawCurve(g);
            
            if (f == 1)
            {
                Random rd = new Random();
                int rand_num = rd.Next(1, 7);
                Bitmap im = new Bitmap("ball"+ rand_num + ".png");
                im.MakeTransparent(im.GetPixel(0, 0));
                if (Balls.Count  < 10 + ct2)
                {
                    if (ct % 10 == 0)
                    {
                        pnn3 = new CImages();
                        pnn3.im = im;
                        pnn3.W = 50;
                        pnn3.H = 50;
                        pnn3.color = rand_num;
                        Balls.Add(pnn3);
                    }
                }
                for(int i=0;i<Balls.Count;i++)
                {
                    if (Balls[i].shot == false)
                    {
                        Balls[i].carPoint = obj.CalcCurvePointAtTime(Balls[i].my_t_inForm);
                        Balls[i].S.X = Balls[i].carPoint.X - 20;
                        Balls[i].S.Y = Balls[i].carPoint.Y;
                    }
                }
                for(int i=0;i<Balls.Count;i++)
                {
                    if (Balls[i].shot == false)
                    {
                        g.DrawImage(Balls[i].im, Balls[i].S.X, Balls[i].S.Y, Balls[i].W, Balls[i].H);
                    }
                    else
                    {
                        g.DrawImage(Balls[i].im, Balls[i].currX, Balls[i].currY, Balls[i].W, Balls[i].H);
                    }
                }
                
            }
            
            //The image you want to rotate
            Bitmap bmp = new Bitmap(pnn2.im.Width + 40, pnn2.im.Height + 40);
            g2 = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            g2.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            g2.RotateTransform((float)rotationAngle - 90);
            //rotationAngle += 10;
            //now we return the transformation we applied
            g2.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            g2.DrawImage(pnn2.im, 0, 0);
            
            
            g.DrawImage(bmp, ClientSize.Width/2 - pnn2.W/2, pnn2.S.Y , pnn2.W,pnn2.H);
            g.DrawImage(death.im, death.S.X, death.S.Y,100,100);
            if (f2 == 1)
            {
                g.DrawImage(pnn4.im, pnn4.S.X, pnn4.S.Y, pnn4.W, pnn4.H);
            }
            //g.FillEllipse(Brushes.Black, pnn2.S.X + pnn2.W / 2 - 10, pnn2.S.Y + pnn2.H / 2 - 10,20,20);
            //g.FillEllipse(Brushes.Black, pnn2.S.X + pnn2.W / 2 - 10, pnn2.S.Y + pnn2.H / 2 - 10, 10, 10);
        }
    }
}