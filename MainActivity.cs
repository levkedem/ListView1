using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Systems;
using System.Collections.Generic;
using System;
using System.Drawing;
using Android.Graphics;
using Android.Content;
using AlertDialog = Android.App.AlertDialog;

namespace ListView1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static List<Student> stulst { get;set;}
        EditText etname, etage, etg1, etg2;
        Button btAdd, btDisplay, btListShow;

        StudentAdapter adapter;
        ListView lv;

        RadioGroup group1;
        RadioButton m,f;

        AlertDialog.Builder builder;
        int pos2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Android.Graphics.Bitmap boy = BitmapFactory.DecodeResource(Resources, Resource.Drawable.boy);
            Android.Graphics.Bitmap girl = BitmapFactory.DecodeResource(Resources, Resource.Drawable.f);

            
            btAdd = (Button)FindViewById(Resource.Id.btAdd);

            stulst = new List<Student>();
            stulst.Add(new Student("Lev Kedem", 18, 100, 100,boy,'m'));
            stulst.Add(new Student("nehama", 60, 98, 79, girl, 'f'));
            stulst.Add(new Student("yosef", 16, 89, 87, boy, 'm'));

            btAdd.Click += BtAdd_Click;

            adapter = new StudentAdapter(this, stulst);
            lv = (ListView)FindViewById(Resource.Id.listView1);
            lv.Adapter = adapter;

            lv.ItemClick += Lv_ItemClick;
            lv.ItemLongClick += Lv_ItemLongClick;
        }

        private void BtListShow_Click(object sender, EventArgs e)
        {
            adapter = new StudentAdapter(this, stulst);
            lv = (ListView)FindViewById(Resource.Id.listView1);
            lv.Adapter = adapter;

            lv.ItemClick += Lv_ItemClick;
            lv.ItemLongClick += Lv_ItemLongClick;
        }

        private void Lv_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            builder = new AlertDialog.Builder(this);
            builder.SetTitle("delete?");
            builder.SetMessage("yes or no");
            builder.SetCancelable(false);
            builder.SetPositiveButton("yes", OkAction);
            builder.SetNegativeButton("cancel", CancelAction);
            AlertDialog d2 = builder.Create();
            d2.Show();

            pos2 = e.Position;
            
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "canceled", ToastLength.Long).Show();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            if (pos2!=null)
            {
                MainActivity.stulst.RemoveAt(pos2);
                adapter.NotifyDataSetChanged();
            }
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int pos = e.Position;
            Intent intent1 = new Intent(this, typeof(Edit_ListView_Activity));
            intent1.PutExtra("Position",pos);
            StartActivity(intent1);
        }

        private void BtAdd_Click(object sender, System.EventArgs e)
        {
            Intent intent1 = new Intent(this, typeof(Edit_ListView_Activity));
            intent1.PutExtra("Position", -1);
            StartActivity(intent1);
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (adapter!=null)
            {
                adapter.NotifyDataSetChanged();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}