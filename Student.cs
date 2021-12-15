using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace ListView1
{
    public class Student
    {
        private string name;
        private int age;
        private double gradA;
        private double gradB;
        private Bitmap bitmap;
        private char g;

        public Student(string name, int age, double gradA, double gradB, Bitmap b, char g)
        {
            this.name = name;
            this.age = age;
            this.gradA = gradA;
            this.gradB = gradB;
            this.bitmap = b;
            this.g = g;
        }
        public string GetName()
        {
            return this.name;
        }
        public int GetAge()
        {
            return this.age;
        }
        public Bitmap GetBitMap()
        {
            return this.bitmap;
        }
        public char GetGender()
        {
            return this.g;
        }
        public double GetGradeA()
        {
            return this.gradA;
        }
        public double GetGradeB()
        {
            return this.gradB;
        }

    }
}