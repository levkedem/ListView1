using System;
using System.Collections.Generic;
using System.Drawing;
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
    [Activity(Label = "Edit_ListView_Activity")]
    public class Edit_ListView_Activity : Activity
    {
        EditText etname, etage, etg1, etg2;
        Button btSave,btImg;
        Student tempS;

        ImageView img1;

        RadioGroup group1;
        RadioButton m, f;

        Android.Graphics.Bitmap pic;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Edit_Layout);
            

            etname = (EditText)FindViewById(Resource.Id.etname);
            etage = (EditText)FindViewById(Resource.Id.etage);
            etg1 = (EditText)FindViewById(Resource.Id.etg1);
            etg2 = (EditText)FindViewById(Resource.Id.etg2);
            btSave = (Button)FindViewById(Resource.Id.btSave1);
            btImg = (Button)FindViewById(Resource.Id.btImg1);
            img1 = (ImageView)FindViewById(Resource.Id.imageView1);

            group1 = (RadioGroup)FindViewById(Resource.Id.radioGroup1);
            m = (RadioButton)FindViewById(Resource.Id.radioButtonM);
            f = (RadioButton)FindViewById(Resource.Id.radioButtonF);


            if (Intent.GetIntExtra("Position", 0)!=-1)
            {
                tempS = MainActivity.stulst[Intent.GetIntExtra("Position", 0)];
                etname.Text = tempS.GetName();
                etage.Text = "" + tempS.GetAge();
                etg1.Text = "" + tempS.GetGradeA();
                etg2.Text = "" + tempS.GetGradeB();
                img1.SetImageBitmap(tempS.GetBitMap());
                pic = tempS.GetBitMap();

                if (tempS.GetGender()=='m')
                {
                    m.Checked = true;
                }
                else
                {
                    f.Checked = true;
                }
            }
            else
            {
                etname.Text = "name";
                etage.Text = "" + 100;
                etg1.Text = "" +0;
                etg2.Text = "" + 0;
            }


            btSave.Click += BtSave_Click;

            
            btImg.Click += BtImg_Click;

        }

        private void BtImg_Click(object sender, EventArgs e)
        {
            Intent intent2 = new Intent(Android.Provider.MediaStore.ActionImageCapture);
            StartActivityForResult(intent2, 0);
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 0)
            {
                if (resultCode == Result.Ok)
                {
                    this.pic = (Android.Graphics.Bitmap)data.Extras.Get("data");
                    this.img1.SetImageBitmap(pic);
                }
            }
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (Intent.GetIntExtra("Position", 0) != -1)
            {
                Student newStu = new Student(etname.Text, Convert.ToInt32(etage.Text), Convert.ToDouble(etg1.Text), Convert.ToDouble(etg2.Text), pic, tempS.GetGender());
                MainActivity.stulst[Intent.GetIntExtra("Position", 0)] = newStu;
                Finish();
            }
            else
            {
                Android.Graphics.Bitmap boy = BitmapFactory.DecodeResource(Resources, Resource.Drawable.boy);
                Android.Graphics.Bitmap girl = BitmapFactory.DecodeResource(Resources, Resource.Drawable.f);

                Android.Graphics.Bitmap temp;
                char ch;
                if (m.Checked)
                {
                    ch = 'm';
                }
                else
                {
                    ch = 'f';
                }
                if (pic==null)
                {
                    if (m.Checked)
                    {
                        pic = boy;
                        ch = 'm';
                    }
                    else
                    {
                        pic = girl;
                        ch = 'f';
                    }
                }

                Student newStu = new Student(etname.Text, Convert.ToInt32(etage.Text), Convert.ToDouble(etg1.Text), Convert.ToDouble(etg2.Text), pic, ch);
                MainActivity.stulst.Add(newStu);
                Finish();
            }
        }
    }
}