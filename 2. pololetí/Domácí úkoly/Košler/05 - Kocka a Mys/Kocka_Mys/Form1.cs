using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kocka_Mys
{

    public struct Vector2 : IEquatable<Vector2>, IFormattable
    {
        public float X;
        public float Y;

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
        bool IEquatable<Vector2>.Equals(Vector2 other)
        {
            throw new NotImplementedException();
        }

        internal static float Distance(Vector2 value1, Vector2 value2)
        {
            return (float)(Math.Sqrt(Math.Pow(Math.Abs(value1.X - value2.X), 2) + Math.Pow(Math.Abs(value1.Y - value2.Y), 2)));
        }
    }
    public enum mouseState { Chilling, Evading };
    public partial class Form1 : Form
    {
        /*
        private int xMin = 100;
        private int xMax = 1100;
        private int yMin = 100;
        private int yMax = 700;
        */
        private int gameScore;
        private Rectangle rect;

        private Vector2 cursorPos = new Vector2();
        private Vector2 lastCursorPos = new Vector2();
        private int currentMouseQuadrant;
        private int lastMouseQuadrant;

        private Vector2 mousePos = new Vector2();
        private mouseState mouseState;
        private float distanceFromCat;
        private float saveDistanceFromCat = 200;
        private int mouseSize = 15;
        private float maxMouseSpeed = 3f;
        private Vector2 mouseHeading;

        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Start();
            timer2.Interval = 1;
            timer3.Interval = 1;
            timer3.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mousePos.X = Width / 2;
            mousePos.Y = Height / 2;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursorPos.X = e.X;
            cursorPos.Y = e.Y;
        }
        private float GetCurrentMouseSpeed()
        {
            if (distanceFromCat > saveDistanceFromCat)
                return .10f * maxMouseSpeed;
            else if (distanceFromCat > saveDistanceFromCat / (3 / 4))
                return .25f * maxMouseSpeed;
            else if (distanceFromCat > saveDistanceFromCat / 2)
                return .5f * maxMouseSpeed;
            else if (distanceFromCat > saveDistanceFromCat / 4)
                return .75f * maxMouseSpeed;
            else
                return maxMouseSpeed;
        }
        private int GetQuadrant(Vector2 cursor, Vector2 mouse)
        {
            if (cursor.X > mouse.X && cursor.Y > mouse.Y)
                return 1;
            else if (cursor.X < mouse.X && cursor.Y > mouse.Y)
                return 2;
            else if (cursor.X < mouse.X && cursor.Y < mouse.Y)
                return 3;
            else
                return 4;
        }
        private void MouseAI()
        {
            currentMouseQuadrant = GetQuadrant(cursorPos, mousePos);
            /*lastMouseQuadrant = 0;
            if (!(mousePos.X <= xMin || mousePos.X >= xMax || mousePos.Y <= yMin || mousePos.Y >= yMax))
                currentMouseQuadrant = GetQuadrant(cursorPos, mousePos);
            else
            {
                if (mousePos.X <= xMin)
                {
                    currentMouseQuadrant = random.Next(0, 2) < 1 ? 4 : 1;
                    currentMouseQuadrant = mousePos.Y <= yMin ? 1 : 4;
                }
                else if (mousePos.X >= xMax)
                {
                    currentMouseQuadrant = random.Next(0, 2) < 1 ? 3 : 2;
                    currentMouseQuadrant = mousePos.Y <= yMin ? 1 : 4;
                }
                else if (mousePos.Y <= yMin)
                    currentMouseQuadrant = random.Next(0, 2) < 1 ? 1 : 2;
                else if (mousePos.Y >= yMax)
                    currentMouseQuadrant = random.Next(0, 2) < 1 ? 3 : 4;
            }  */
            if (currentMouseQuadrant != lastMouseQuadrant)
            {
                lastMouseQuadrant = currentMouseQuadrant;
                if (currentMouseQuadrant == 1)
                {
                    mouseHeading.X = random.Next(0, 2) < 1 ? 1 : -1;
                    if (mouseHeading.X > 0)
                        mouseHeading.Y = -1;
                    else
                        mouseHeading.Y = random.Next(0, 2) < 1 ? 1 : -1;
                }
                else if (currentMouseQuadrant == 2)
                {
                    mouseHeading.X = random.Next(0, 2) < 1 ? 1 : -1;
                    if (mouseHeading.X > 0)
                        mouseHeading.Y = random.Next(0, 2) < 1 ? 1 : -1;
                    else
                        mouseHeading.Y = -1;
                }
                else if (currentMouseQuadrant == 3)
                {
                    mouseHeading.X = random.Next(0, 2) < 1 ? 1 : -1;
                    if (mouseHeading.X > 0)
                        mouseHeading.Y = random.Next(0, 2) < 1 ? 1 : -1;
                    else
                        mouseHeading.Y = 1;
                }
                else if (currentMouseQuadrant == 4)
                {
                    mouseHeading.X = random.Next(0, 2) < 1 ? 1 : -1;
                    if (mouseHeading.X > 0)
                        mouseHeading.Y = 1;
                    else
                        mouseHeading.Y = random.Next(0, 2) < 1 ? 1 : -1;
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            distanceFromCat = Vector2.Distance(cursorPos, mousePos);
            timer1.Stop();
            MouseAI();
            mousePos.X += mouseHeading.X * GetCurrentMouseSpeed();
            mousePos.Y += mouseHeading.Y * GetCurrentMouseSpeed();
            if (distanceFromCat > saveDistanceFromCat)
            {
                timer1.Start();
                timer2.Stop();
            }
            Invalidate();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            distanceFromCat = Vector2.Distance(cursorPos, mousePos);
            if (cursorPos.X != lastCursorPos.X && cursorPos.Y != lastCursorPos.Y)
            {
                lastCursorPos = cursorPos;
                if (distanceFromCat > saveDistanceFromCat)
                {
                    mouseState = mouseState.Chilling;
                    timer2.Stop();
                }
                else
                {
                    mouseState = mouseState.Evading;
                    timer2.Start();
                }
            }
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            rect = new Rectangle((int)mousePos.X, (int)mousePos.Y, mouseSize+ 1, mouseSize+1);
            Pen pen = new Pen(Color.White, 1);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            e.Graphics.FillEllipse(Brushes.Black, mousePos.X, mousePos.Y, mouseSize, mouseSize);
            e.Graphics.DrawRectangle(pen, rect);
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            label1.Text = String.Format("Mouse X: {0} ,Y: {1}\n" +
                                        "Cursor X: {2} ,Y: {3}\n" +
                                        "Distance from cat: {4}\n" +
                                        "State: {5}\n" +
                                        "MouseSpeed: {6}\n" +
                                        "CursorQuadrant: {7}",
                                        mousePos.X, mousePos.Y, cursorPos.X, cursorPos.Y, distanceFromCat, mouseState, GetCurrentMouseSpeed(), GetQuadrant(cursorPos, mousePos));
            label2.Text = String.Format("Score: {0}", gameScore);
            label2.Text = String.Format("Score: {0}", gameScore);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (rect.Contains(e.Location))
                gameScore += 1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mousePos.X = Width / 2;
            mousePos.Y = Height / 2;
            mouseState = mouseState.Chilling;
        }
    }
}
