using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace ListView1
{
    public class StudentAdapter: BaseAdapter<Student>
    {
        Context context;
        List<Student> objects;
        public StudentAdapter(Context context,List<Student> obj1)
        {
            this.context = context;
            this.objects = obj1;
        }

        public List<Student> GetList()
        {
            return this.objects;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return this.objects.Count; }
        }
        public override Student this[int position]
        { 
            get { return this.objects[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater layoutInflater = ((MainActivity)context).LayoutInflater;
            View view = layoutInflater.Inflate(Resource.Layout.ListView_Layout1, parent, false);
            TextView tvName = view.FindViewById<TextView>(Resource.Id.textViewName);
            TextView tvAge = view.FindViewById<TextView>(Resource.Id.textViewAge);
            TextView tvGrade1 = view.FindViewById<TextView>(Resource.Id.textViewG1);
            ImageView ivPic = view.FindViewById<ImageView>(Resource.Id.imageView1);

            Student temp = objects[position];
            if (temp!=null)
            {
                ivPic.SetImageBitmap(temp.GetBitMap());
                tvName.Text = tvName.Text + temp.GetName();
                tvAge.Text = tvAge.Text + temp.GetAge();
                tvGrade1.Text = tvGrade1.Text + (temp.GetGradeA()+temp.GetGradeB())/2;
            }
            return view;
        }
    }
}